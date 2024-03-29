﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.Infrastructure.CommitFailureHandler
// Assembly: EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 000F5452-2AD1-45BF-987B-3043022F9799
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll

using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Sql;
using System.Data.Entity.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Entity.Infrastructure
{
  /// <summary>
  /// A transaction handler that allows to gracefully recover from connection failures
  /// during transaction commit by storing transaction tracing information in the database.
  /// It needs to be registered by using <see cref="M:System.Data.Entity.DbConfiguration.SetDefaultTransactionHandler(System.Func{System.Data.Entity.Infrastructure.TransactionHandler})" />.
  /// </summary>
  /// <remarks>
  /// This transaction handler uses <see cref="P:System.Data.Entity.Infrastructure.CommitFailureHandler.TransactionContext" /> to store the transaction information
  /// the schema used can be configured by creating a class derived from <see cref="P:System.Data.Entity.Infrastructure.CommitFailureHandler.TransactionContext" />
  /// that overrides DbContext.OnModelCreating(DbModelBuilder) and passing it to the constructor of this class.
  /// </remarks>
  public class CommitFailureHandler : TransactionHandler
  {
    private readonly Dictionary<DbTransaction, TransactionRow> _transactions = new Dictionary<DbTransaction, TransactionRow>();
    private readonly HashSet<TransactionRow> _rowsToDelete = new HashSet<TransactionRow>();
    private readonly Func<DbConnection, TransactionContext> _transactionContextFactory;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.CommitFailureHandler" /> class using the default <see cref="P:System.Data.Entity.Infrastructure.CommitFailureHandler.TransactionContext" />.
    /// </summary>
    /// <remarks>
    /// One of the Initialize methods needs to be called before this instance can be used.
    /// </remarks>
    public CommitFailureHandler()
      : this((Func<DbConnection, TransactionContext>) (c => new TransactionContext(c)))
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Data.Entity.Infrastructure.CommitFailureHandler" /> class.
    /// </summary>
    /// <param name="transactionContextFactory">The transaction context factory.</param>
    /// <remarks>
    /// One of the Initialize methods needs to be called before this instance can be used.
    /// </remarks>
    public CommitFailureHandler(
      Func<DbConnection, TransactionContext> transactionContextFactory)
    {
      Check.NotNull<Func<DbConnection, TransactionContext>>(transactionContextFactory, nameof (transactionContextFactory));
      this._transactionContextFactory = transactionContextFactory;
    }

    /// <summary>Gets the transaction context.</summary>
    /// <value>The transaction context.</value>
    protected internal TransactionContext TransactionContext { get; private set; }

    /// <inheritdoc />
    public override void Initialize(ObjectContext context)
    {
      base.Initialize(context);
      this.Initialize(((EntityConnection) this.ObjectContext.Connection).StoreConnection);
    }

    /// <inheritdoc />
    public override void Initialize(DbContext context, DbConnection connection)
    {
      base.Initialize(context, connection);
      this.Initialize(connection);
    }

    private void Initialize(DbConnection connection)
    {
      this.TransactionContext = this._transactionContextFactory(connection);
      if (this.TransactionContext == null)
        return;
      this.TransactionContext.Configuration.LazyLoadingEnabled = false;
      this.TransactionContext.Configuration.AutoDetectChangesEnabled = false;
    }

    /// <summary>
    /// Gets the number of transactions to be executed on the context before the transaction log will be cleaned.
    /// The default value is 20.
    /// </summary>
    protected virtual int PruningLimit
    {
      get
      {
        return 20;
      }
    }

    /// <inheritdoc />
    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
    protected override void Dispose(bool disposing)
    {
      if (!this.IsDisposed && disposing && this.TransactionContext != null)
      {
        if (this._rowsToDelete.Any<TransactionRow>())
        {
          try
          {
            this.PruneTransactionHistory(true, false);
          }
          catch (Exception ex)
          {
          }
        }
        this.TransactionContext.Dispose();
      }
      base.Dispose(disposing);
    }

    /// <inheritdoc />
    public override string BuildDatabaseInitializationScript()
    {
      if (this.TransactionContext == null)
        return (string) null;
      IEnumerable<MigrationStatement> migrationStatements = TransactionContextInitializer<TransactionContext>.GenerateMigrationStatements(this.TransactionContext);
      StringBuilder sqlBuilder = new StringBuilder();
      MigratorScriptingDecorator.BuildSqlScript(migrationStatements, sqlBuilder);
      return sqlBuilder.ToString();
    }

    /// <summary>
    /// Stores the tracking information for the new transaction to the database in the same transaction.
    /// </summary>
    /// <param name="connection">The connection that began the transaction.</param>
    /// <param name="interceptionContext">Contextual information associated with the call.</param>
    /// <seealso cref="M:System.Data.Entity.Infrastructure.Interception.IDbConnectionInterceptor.BeganTransaction(System.Data.Common.DbConnection,System.Data.Entity.Infrastructure.Interception.BeginTransactionInterceptionContext)" />
    public override void BeganTransaction(
      DbConnection connection,
      BeginTransactionInterceptionContext interceptionContext)
    {
      if (this.TransactionContext == null || !this.MatchesParentContext(connection, (DbInterceptionContext) interceptionContext) || interceptionContext.Result == null)
        return;
      Guid transactionId = Guid.NewGuid();
      bool flag1 = false;
      bool flag2 = false;
      ObjectContext objectContext = ((IObjectContextAdapter) this.TransactionContext).ObjectContext;
      ((EntityConnection) objectContext.Connection).UseStoreTransaction(interceptionContext.Result);
      while (!flag1)
      {
        TransactionRow entity = new TransactionRow()
        {
          Id = transactionId,
          CreationTime = DateTime.Now
        };
        this._transactions.Add(interceptionContext.Result, entity);
        this.TransactionContext.Transactions.Add(entity);
        try
        {
          objectContext.SaveChangesInternal(SaveOptions.AcceptAllChangesAfterSave, true);
          flag1 = true;
        }
        catch (UpdateException ex1)
        {
          this._transactions.Remove(interceptionContext.Result);
          this.TransactionContext.Entry<TransactionRow>(entity).State = EntityState.Detached;
          if (flag2)
          {
            throw;
          }
          else
          {
            try
            {
              if (this.TransactionContext.Transactions.AsNoTracking<TransactionRow>().WithExecutionStrategy<TransactionRow>((IDbExecutionStrategy) new DefaultExecutionStrategy()).FirstOrDefault<TransactionRow>((Expression<Func<TransactionRow, bool>>) (t => t.Id == transactionId)) != null)
                transactionId = Guid.NewGuid();
              else
                throw;
            }
            catch (EntityCommandExecutionException ex2)
            {
              this.TransactionContext.Database.Initialize(true);
              flag2 = true;
            }
          }
        }
      }
    }

    /// <summary>
    /// If there was an exception thrown checks the database for this transaction and rethrows it if not found.
    /// Otherwise marks the commit as succeeded and queues the transaction information to be deleted.
    /// </summary>
    /// <param name="transaction">The transaction that was commited.</param>
    /// <param name="interceptionContext">Contextual information associated with the call.</param>
    /// <seealso cref="M:System.Data.Entity.Infrastructure.Interception.IDbTransactionInterceptor.Committed(System.Data.Common.DbTransaction,System.Data.Entity.Infrastructure.Interception.DbTransactionInterceptionContext)" />
    public override void Committed(
      DbTransaction transaction,
      DbTransactionInterceptionContext interceptionContext)
    {
      TransactionRow transactionRow;
      if (this.TransactionContext == null || interceptionContext.Connection != null && !this.MatchesParentContext(interceptionContext.Connection, (DbInterceptionContext) interceptionContext) || !this._transactions.TryGetValue(transaction, out transactionRow))
        return;
      this._transactions.Remove(transaction);
      if (interceptionContext.Exception != null)
      {
        TransactionRow transactionRow1 = (TransactionRow) null;
        try
        {
          transactionRow1 = this.TransactionContext.Transactions.AsNoTracking<TransactionRow>().WithExecutionStrategy<TransactionRow>((IDbExecutionStrategy) new DefaultExecutionStrategy()).SingleOrDefault<TransactionRow>((Expression<Func<TransactionRow, bool>>) (t => t.Id == transactionRow.Id));
        }
        catch (EntityCommandExecutionException ex)
        {
        }
        if (transactionRow1 != null)
        {
          interceptionContext.Exception = (Exception) null;
          this.PruneTransactionHistory(transactionRow);
        }
        else
          this.TransactionContext.Entry<TransactionRow>(transactionRow).State = EntityState.Detached;
      }
      else
        this.PruneTransactionHistory(transactionRow);
    }

    /// <summary>Stops tracking the transaction that was rolled back.</summary>
    /// <param name="transaction">The transaction that was rolled back.</param>
    /// <param name="interceptionContext">Contextual information associated with the call.</param>
    /// <seealso cref="M:System.Data.Entity.Infrastructure.Interception.IDbTransactionInterceptor.RolledBack(System.Data.Common.DbTransaction,System.Data.Entity.Infrastructure.Interception.DbTransactionInterceptionContext)" />
    public override void RolledBack(
      DbTransaction transaction,
      DbTransactionInterceptionContext interceptionContext)
    {
      TransactionRow entity;
      if (this.TransactionContext == null || interceptionContext.Connection != null && !this.MatchesParentContext(interceptionContext.Connection, (DbInterceptionContext) interceptionContext) || !this._transactions.TryGetValue(transaction, out entity))
        return;
      this._transactions.Remove(transaction);
      this.TransactionContext.Entry<TransactionRow>(entity).State = EntityState.Detached;
    }

    /// <summary>Stops tracking the transaction that was disposed.</summary>
    /// <param name="transaction">The transaction that was disposed.</param>
    /// <param name="interceptionContext">Contextual information associated with the call.</param>
    /// <seealso cref="M:System.Data.Entity.Infrastructure.Interception.IDbTransactionInterceptor.Disposed(System.Data.Common.DbTransaction,System.Data.Entity.Infrastructure.Interception.DbTransactionInterceptionContext)" />
    public override void Disposed(
      DbTransaction transaction,
      DbTransactionInterceptionContext interceptionContext)
    {
      this.RolledBack(transaction, interceptionContext);
    }

    /// <summary>Removes all the transaction history.</summary>
    /// <remarks>
    /// This method should only be invoked when there are no active transactions to remove any leftover history
    /// that was not deleted due to catastrophic failures
    /// </remarks>
    public virtual void ClearTransactionHistory()
    {
      foreach (TransactionRow transaction in (IEnumerable<TransactionRow>) this.TransactionContext.Transactions)
        this.MarkTransactionForPruning(transaction);
      this.PruneTransactionHistory(true, true);
    }

    /// <summary>Asynchronously removes all the transaction history.</summary>
    /// <remarks>
    /// This method should only be invoked when there are no active transactions to remove any leftover history
    /// that was not deleted due to catastrophic failures
    /// </remarks>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task ClearTransactionHistoryAsync()
    {
      return this.ClearTransactionHistoryAsync(CancellationToken.None);
    }

    /// <summary>Asynchronously removes all the transaction history.</summary>
    /// <remarks>
    /// This method should only be invoked when there are no active transactions to remove any leftover history
    /// that was not deleted due to catastrophic failures
    /// </remarks>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public virtual async Task ClearTransactionHistoryAsync(CancellationToken cancellationToken)
    {
      await this.TransactionContext.Transactions.ForEachAsync<TransactionRow>(new Action<TransactionRow>(this.MarkTransactionForPruning), cancellationToken).WithCurrentCulture();
      await this.PruneTransactionHistoryAsync(true, true, cancellationToken).WithCurrentCulture();
    }

    /// <summary>
    /// Adds the specified transaction to the list of transactions that can be removed from the database
    /// </summary>
    /// <param name="transaction">The transaction to be removed from the database.</param>
    protected virtual void MarkTransactionForPruning(TransactionRow transaction)
    {
      Check.NotNull<TransactionRow>(transaction, nameof (transaction));
      if (this._rowsToDelete.Contains(transaction))
        return;
      this._rowsToDelete.Add(transaction);
    }

    /// <summary>Removes the transactions marked for deletion.</summary>
    public void PruneTransactionHistory()
    {
      this.PruneTransactionHistory(true, true);
    }

    /// <summary>
    /// Asynchronously removes the transactions marked for deletion.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task PruneTransactionHistoryAsync()
    {
      return this.PruneTransactionHistoryAsync(CancellationToken.None);
    }

    /// <summary>
    /// Asynchronously removes the transactions marked for deletion.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task PruneTransactionHistoryAsync(CancellationToken cancellationToken)
    {
      return this.PruneTransactionHistoryAsync(true, true, cancellationToken);
    }

    /// <summary>
    /// Removes the transactions marked for deletion if their number exceeds <see cref="P:System.Data.Entity.Infrastructure.CommitFailureHandler.PruningLimit" />.
    /// </summary>
    /// <param name="force">
    /// if set to <c>true</c> will remove all the old transactions even if their number does not exceed <see cref="P:System.Data.Entity.Infrastructure.CommitFailureHandler.PruningLimit" />.
    /// </param>
    /// <param name="useExecutionStrategy">
    /// if set to <c>true</c> the operation will be executed using the associated execution strategy
    /// </param>
    protected virtual void PruneTransactionHistory(bool force, bool useExecutionStrategy)
    {
      if (this._rowsToDelete.Count <= 0 || !force && this._rowsToDelete.Count <= this.PruningLimit)
        return;
      foreach (TransactionRow entity in this.TransactionContext.Transactions.ToList<TransactionRow>())
      {
        if (this._rowsToDelete.Contains(entity))
          this.TransactionContext.Transactions.Remove(entity);
      }
      ObjectContext objectContext = ((IObjectContextAdapter) this.TransactionContext).ObjectContext;
      try
      {
        objectContext.SaveChangesInternal(SaveOptions.None, !useExecutionStrategy);
        this._rowsToDelete.Clear();
      }
      finally
      {
        objectContext.AcceptAllChanges();
      }
    }

    /// <summary>
    /// Removes the transactions marked for deletion if their number exceeds <see cref="P:System.Data.Entity.Infrastructure.CommitFailureHandler.PruningLimit" />.
    /// </summary>
    /// <param name="force">
    /// if set to <c>true</c> will remove all the old transactions even if their number does not exceed <see cref="P:System.Data.Entity.Infrastructure.CommitFailureHandler.PruningLimit" />.
    /// </param>
    /// <param name="useExecutionStrategy">
    /// if set to <c>true</c> the operation will be executed using the associated execution strategy
    /// </param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    protected virtual async Task PruneTransactionHistoryAsync(
      bool force,
      bool useExecutionStrategy,
      CancellationToken cancellationToken)
    {
      if (this._rowsToDelete.Count <= 0 || !force && this._rowsToDelete.Count <= this.PruningLimit)
        return;
      foreach (TransactionRow entity in this.TransactionContext.Transactions.ToList<TransactionRow>())
      {
        if (this._rowsToDelete.Contains(entity))
          this.TransactionContext.Transactions.Remove(entity);
      }
      ObjectContext objectContext = ((IObjectContextAdapter) this.TransactionContext).ObjectContext;
      try
      {
        int num = await ((IObjectContextAdapter) this.TransactionContext).ObjectContext.SaveChangesInternalAsync(SaveOptions.None, !useExecutionStrategy, cancellationToken).WithCurrentCulture<int>();
        this._rowsToDelete.Clear();
      }
      finally
      {
        objectContext.AcceptAllChanges();
      }
    }

    private void PruneTransactionHistory(TransactionRow transaction)
    {
      this.MarkTransactionForPruning(transaction);
      try
      {
        this.PruneTransactionHistory(false, false);
      }
      catch (DataException ex)
      {
      }
    }

    /// <summary>
    /// Gets the <see cref="T:System.Data.Entity.Infrastructure.CommitFailureHandler" /> associated with the <paramref name="context" /> if there is one;
    /// otherwise returns <c>null</c>.
    /// </summary>
    /// <param name="context">The context</param>
    /// <returns>The associated <see cref="T:System.Data.Entity.Infrastructure.CommitFailureHandler" />.</returns>
    public static CommitFailureHandler FromContext(DbContext context)
    {
      Check.NotNull<DbContext>(context, nameof (context));
      return CommitFailureHandler.FromContext(((IObjectContextAdapter) context).ObjectContext);
    }

    /// <summary>
    /// Gets the <see cref="T:System.Data.Entity.Infrastructure.CommitFailureHandler" /> associated with the <paramref name="context" /> if there is one;
    /// otherwise returns <c>null</c>.
    /// </summary>
    /// <param name="context">The context</param>
    /// <returns>The associated <see cref="T:System.Data.Entity.Infrastructure.CommitFailureHandler" />.</returns>
    public static CommitFailureHandler FromContext(ObjectContext context)
    {
      Check.NotNull<ObjectContext>(context, nameof (context));
      return context.TransactionHandler as CommitFailureHandler;
    }
  }
}

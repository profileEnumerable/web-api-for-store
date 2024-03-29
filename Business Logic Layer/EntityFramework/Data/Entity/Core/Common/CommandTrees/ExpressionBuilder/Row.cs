﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Row
// Assembly: EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 000F5452-2AD1-45BF-987B-3043022F9799
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Common.Utils;
using System.Data.Entity.Utilities;

namespace System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder
{
  /// <summary>
  /// Provides a constructor-like means of calling
  /// <see cref="M:System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.DbExpressionBuilder.NewRow(System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String,System.Data.Entity.Core.Common.CommandTrees.DbExpression}})" />
  /// .
  /// </summary>
  public sealed class Row
  {
    private readonly ReadOnlyCollection<KeyValuePair<string, DbExpression>> arguments;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Row" /> class with the specified first column value and optional successive column values.
    /// </summary>
    /// <param name="columnValue">A key-value pair that provides the first column in the new row instance. (required)</param>
    /// <param name="columnValues">A key-value pairs that provide any subsequent columns in the new row instance. (optional)</param>
    public Row(
      KeyValuePair<string, DbExpression> columnValue,
      params KeyValuePair<string, DbExpression>[] columnValues)
    {
      this.arguments = new ReadOnlyCollection<KeyValuePair<string, DbExpression>>((IList<KeyValuePair<string, DbExpression>>) Helpers.Prepend<KeyValuePair<string, DbExpression>>(columnValues, columnValue));
    }

    /// <summary>
    /// Creates a new <see cref="T:System.Data.Entity.Core.Common.CommandTrees.DbNewInstanceExpression" /> that constructs a new row based on the columns contained in this Row instance.
    /// </summary>
    /// <returns>A new DbNewInstanceExpression that constructs a row with the same column names and DbExpression values as this Row instance.</returns>
    public DbNewInstanceExpression ToExpression()
    {
      return DbExpressionBuilder.NewRow((IEnumerable<KeyValuePair<string, DbExpression>>) this.arguments);
    }

    /// <summary>
    /// Converts the given Row instance into an instance of <see cref="T:System.Data.Entity.Core.Common.CommandTrees.DbExpression" />
    /// </summary>
    /// <param name="row">The Row instance.</param>
    /// <returns> A DbExpression based on the Row instance </returns>
    /// <exception cref="T:System.ArgumentNullException">
    /// <paramref name="row" />
    /// is null.
    /// </exception>
    /// <seealso cref="M:System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Row.ToExpression" />
    public static implicit operator DbExpression(Row row)
    {
      Check.NotNull<Row>(row, nameof (row));
      return (DbExpression) row.ToExpression();
    }
  }
}

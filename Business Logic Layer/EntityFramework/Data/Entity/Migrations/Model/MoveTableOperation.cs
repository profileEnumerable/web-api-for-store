﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.Migrations.Model.MoveTableOperation
// Assembly: EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 000F5452-2AD1-45BF-987B-3043022F9799
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll

using System.Data.Entity.Utilities;
using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Migrations.Model
{
  /// <summary>
  /// Represents moving a table from one schema to another.
  /// 
  /// Entity Framework Migrations APIs are not designed to accept input provided by untrusted sources
  /// (such as the end user of an application). If input is accepted from such sources it should be validated
  /// before being passed to these APIs to protect against SQL injection attacks etc.
  /// </summary>
  public class MoveTableOperation : MigrationOperation
  {
    private readonly string _name;
    private readonly string _newSchema;

    /// <summary>
    /// Initializes a new instance of the MoveTableOperation class.
    /// 
    /// Entity Framework Migrations APIs are not designed to accept input provided by untrusted sources
    /// (such as the end user of an application). If input is accepted from such sources it should be validated
    /// before being passed to these APIs to protect against SQL injection attacks etc.
    /// </summary>
    /// <param name="name"> Name of the table to be moved. </param>
    /// <param name="newSchema"> Name of the schema to move the table to. </param>
    /// <param name="anonymousArguments"> Additional arguments that may be processed by providers. Use anonymous type syntax to specify arguments e.g. 'new { SampleArgument = "MyValue" }'. </param>
    [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
    public MoveTableOperation(string name, string newSchema, object anonymousArguments = null)
      : base(anonymousArguments)
    {
      Check.NotEmpty(name, nameof (name));
      this._name = name;
      this._newSchema = newSchema;
    }

    /// <summary>Gets the name of the table to be moved.</summary>
    public virtual string Name
    {
      get
      {
        return this._name;
      }
    }

    /// <summary>Gets the name of the schema to move the table to.</summary>
    public virtual string NewSchema
    {
      get
      {
        return this._newSchema;
      }
    }

    /// <summary>
    /// Gets an operation that moves the table back to its original schema.
    /// </summary>
    public override MigrationOperation Inverse
    {
      get
      {
        DatabaseName databaseName = DatabaseName.Parse(this._name);
        return (MigrationOperation) new MoveTableOperation(new DatabaseName(databaseName.Name, this.NewSchema).ToString(), databaseName.Schema, (object) null)
        {
          IsSystem = this.IsSystem
        };
      }
    }

    /// <inheritdoc />
    public override bool IsDestructiveChange
    {
      get
      {
        return false;
      }
    }

    /// <summary>
    /// Used when altering the migrations history table so that data can be moved to the new table.
    /// </summary>
    /// <value>The context key for the model.</value>
    public string ContextKey { get; internal set; }

    /// <summary>
    /// Gets a value that indicates whether this is a system table.
    /// </summary>
    /// <returns>
    /// true if the table is a system table; otherwise, false.
    /// </returns>
    public bool IsSystem { get; internal set; }

    /// <summary>
    /// Used when altering the migrations history table so that the table can be rebuilt rather than just dropping and adding the primary key.
    /// </summary>
    /// <value>
    /// The create table operation for the migrations history table.
    /// </value>
    public CreateTableOperation CreateTableOperation { get; internal set; }
  }
}

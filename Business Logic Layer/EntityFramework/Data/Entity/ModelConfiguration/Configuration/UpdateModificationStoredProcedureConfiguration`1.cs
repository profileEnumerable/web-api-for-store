﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.ModelConfiguration.Configuration.UpdateModificationStoredProcedureConfiguration`1
// Assembly: EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 000F5452-2AD1-45BF-987B-3043022F9799
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Spatial;
using System.Data.Entity.Utilities;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Data.Entity.ModelConfiguration.Configuration
{
  /// <summary>
  /// Allows configuration to be performed for a stored procedure that is used to update entities.
  /// </summary>
  /// <typeparam name="TEntityType">The type of the entity that the stored procedure can be used to update.</typeparam>
  public class UpdateModificationStoredProcedureConfiguration<TEntityType> : ModificationStoredProcedureConfigurationBase
    where TEntityType : class
  {
    internal UpdateModificationStoredProcedureConfiguration()
    {
    }

    /// <summary> Configures the name of the stored procedure. </summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="procedureName"> The stored procedure name. </param>
    public UpdateModificationStoredProcedureConfiguration<TEntityType> HasName(
      string procedureName)
    {
      Check.NotEmpty(procedureName, nameof (procedureName));
      this.Configuration.HasName(procedureName);
      return this;
    }

    /// <summary>Configures the name of the stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="procedureName">The stored procedure name.</param>
    /// <param name="schemaName">The schema name.</param>
    public UpdateModificationStoredProcedureConfiguration<TEntityType> HasName(
      string procedureName,
      string schemaName)
    {
      Check.NotEmpty(procedureName, nameof (procedureName));
      Check.NotEmpty(schemaName, nameof (schemaName));
      this.Configuration.HasName(procedureName, schemaName);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <typeparam name="TProperty">The type of the property to configure.</typeparam>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="parameterName">The name of the parameter.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter<TProperty>(
      Expression<Func<TEntityType, TProperty>> propertyExpression,
      string parameterName)
      where TProperty : struct
    {
      Check.NotNull<Expression<Func<TEntityType, TProperty>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(parameterName, nameof (parameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), parameterName, (string) null, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <typeparam name="TProperty">The type of the property to configure.</typeparam>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="parameterName">The name of the parameter.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter<TProperty>(
      Expression<Func<TEntityType, TProperty?>> propertyExpression,
      string parameterName)
      where TProperty : struct
    {
      Check.NotNull<Expression<Func<TEntityType, TProperty?>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(parameterName, nameof (parameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), parameterName, (string) null, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="parameterName">The name of the parameter.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, string>> propertyExpression,
      string parameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, string>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(parameterName, nameof (parameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), parameterName, (string) null, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="parameterName">The name of the parameter.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, byte[]>> propertyExpression,
      string parameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, byte[]>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(parameterName, nameof (parameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), parameterName, (string) null, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="parameterName">The name of the parameter.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, DbGeography>> propertyExpression,
      string parameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, DbGeography>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(parameterName, nameof (parameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), parameterName, (string) null, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="parameterName">The name of the parameter.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, DbGeometry>> propertyExpression,
      string parameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, DbGeometry>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(parameterName, nameof (parameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), parameterName, (string) null, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <typeparam name="TProperty">The type of the property to configure.</typeparam>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="currentValueParameterName">The current value parameter name.</param>
    /// <param name="originalValueParameterName">The original value parameter name.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter<TProperty>(
      Expression<Func<TEntityType, TProperty>> propertyExpression,
      string currentValueParameterName,
      string originalValueParameterName)
      where TProperty : struct
    {
      Check.NotNull<Expression<Func<TEntityType, TProperty>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(currentValueParameterName, nameof (currentValueParameterName));
      Check.NotEmpty(originalValueParameterName, nameof (originalValueParameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), currentValueParameterName, originalValueParameterName, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <typeparam name="TProperty">The type of the property to configure.</typeparam>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="currentValueParameterName">The current value parameter name.</param>
    /// <param name="originalValueParameterName">The original value parameter name.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter<TProperty>(
      Expression<Func<TEntityType, TProperty?>> propertyExpression,
      string currentValueParameterName,
      string originalValueParameterName)
      where TProperty : struct
    {
      Check.NotNull<Expression<Func<TEntityType, TProperty?>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(currentValueParameterName, nameof (currentValueParameterName));
      Check.NotEmpty(originalValueParameterName, nameof (originalValueParameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), currentValueParameterName, originalValueParameterName, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="currentValueParameterName">The current value parameter name.</param>
    /// <param name="originalValueParameterName">The original value parameter name.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, string>> propertyExpression,
      string currentValueParameterName,
      string originalValueParameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, string>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(currentValueParameterName, nameof (currentValueParameterName));
      Check.NotEmpty(originalValueParameterName, nameof (originalValueParameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), currentValueParameterName, originalValueParameterName, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="currentValueParameterName">The current value parameter name.</param>
    /// <param name="originalValueParameterName">The original value parameter name.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, byte[]>> propertyExpression,
      string currentValueParameterName,
      string originalValueParameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, byte[]>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(currentValueParameterName, nameof (currentValueParameterName));
      Check.NotEmpty(originalValueParameterName, nameof (originalValueParameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), currentValueParameterName, originalValueParameterName, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="currentValueParameterName">The current value parameter name.</param>
    /// <param name="originalValueParameterName">The original value parameter name.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, DbGeography>> propertyExpression,
      string currentValueParameterName,
      string originalValueParameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, DbGeography>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(currentValueParameterName, nameof (currentValueParameterName));
      Check.NotEmpty(originalValueParameterName, nameof (originalValueParameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), currentValueParameterName, originalValueParameterName, false);
      return this;
    }

    /// <summary>Configures a parameter for this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the parameter for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="currentValueParameterName">The current value parameter name.</param>
    /// <param name="originalValueParameterName">The original value parameter name.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Parameter(
      Expression<Func<TEntityType, DbGeometry>> propertyExpression,
      string currentValueParameterName,
      string originalValueParameterName)
    {
      Check.NotNull<Expression<Func<TEntityType, DbGeometry>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(currentValueParameterName, nameof (currentValueParameterName));
      Check.NotEmpty(originalValueParameterName, nameof (originalValueParameterName));
      this.Configuration.Parameter(propertyExpression.GetComplexPropertyAccess(), currentValueParameterName, originalValueParameterName, false);
      return this;
    }

    /// <summary>
    /// Configures a column of the result for this stored procedure to map to a property.
    /// This is used for database generated columns.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property to configure.</typeparam>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the result for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="columnName">The name of the result column.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Result<TProperty>(
      Expression<Func<TEntityType, TProperty>> propertyExpression,
      string columnName)
      where TProperty : struct
    {
      Check.NotNull<Expression<Func<TEntityType, TProperty>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(columnName, nameof (columnName));
      this.Configuration.Result(propertyExpression.GetSimplePropertyAccess(), columnName);
      return this;
    }

    /// <summary>
    /// Configures a column of the result for this stored procedure to map to a property.
    /// This is used for database generated columns.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property to configure.</typeparam>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the result for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="columnName">The name of the result column.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Result<TProperty>(
      Expression<Func<TEntityType, TProperty?>> propertyExpression,
      string columnName)
      where TProperty : struct
    {
      Check.NotNull<Expression<Func<TEntityType, TProperty?>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(columnName, nameof (columnName));
      this.Configuration.Result(propertyExpression.GetSimplePropertyAccess(), columnName);
      return this;
    }

    /// <summary>
    /// Configures a column of the result for this stored procedure to map to a property.
    /// This is used for database generated columns.
    /// </summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the result for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="columnName">The name of the result column.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Result(
      Expression<Func<TEntityType, string>> propertyExpression,
      string columnName)
    {
      Check.NotNull<Expression<Func<TEntityType, string>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(columnName, nameof (columnName));
      this.Configuration.Result(propertyExpression.GetSimplePropertyAccess(), columnName);
      return this;
    }

    /// <summary>
    /// Configures a column of the result for this stored procedure to map to a property.
    /// This is used for database generated columns.
    /// </summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the result for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="columnName">The name of the result column.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Result(
      Expression<Func<TEntityType, byte[]>> propertyExpression,
      string columnName)
    {
      Check.NotNull<Expression<Func<TEntityType, byte[]>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(columnName, nameof (columnName));
      this.Configuration.Result(propertyExpression.GetSimplePropertyAccess(), columnName);
      return this;
    }

    /// <summary>
    /// Configures a column of the result for this stored procedure to map to a property.
    /// This is used for database generated columns.
    /// </summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the result for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="columnName">The name of the result column.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Result(
      Expression<Func<TEntityType, DbGeography>> propertyExpression,
      string columnName)
    {
      Check.NotNull<Expression<Func<TEntityType, DbGeography>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(columnName, nameof (columnName));
      this.Configuration.Result(propertyExpression.GetSimplePropertyAccess(), columnName);
      return this;
    }

    /// <summary>
    /// Configures a column of the result for this stored procedure to map to a property.
    /// This is used for database generated columns.
    /// </summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="propertyExpression"> A lambda expression representing the property to configure the result for. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="columnName">The name of the result column.</param>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Result(
      Expression<Func<TEntityType, DbGeometry>> propertyExpression,
      string columnName)
    {
      Check.NotNull<Expression<Func<TEntityType, DbGeometry>>>(propertyExpression, nameof (propertyExpression));
      Check.NotEmpty(columnName, nameof (columnName));
      this.Configuration.Result(propertyExpression.GetSimplePropertyAccess(), columnName);
      return this;
    }

    /// <summary>Configures the output parameter that returns the rows affected by this stored procedure.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="parameterName">The name of the parameter.</param>
    public UpdateModificationStoredProcedureConfiguration<TEntityType> RowsAffectedParameter(
      string parameterName)
    {
      Check.NotEmpty(parameterName, nameof (parameterName));
      this.Configuration.RowsAffectedParameter(parameterName);
      return this;
    }

    /// <summary>Configures parameters for a relationship where the foreign key property is not included in the class.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="navigationPropertyExpression"> A lambda expression representing the navigation property for the relationship. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="associationModificationStoredProcedureConfigurationAction">A lambda expression that performs the configuration.</param>
    /// <typeparam name="TPrincipalEntityType">The type of the principal entity in the relationship.</typeparam>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Navigation<TPrincipalEntityType>(
      Expression<Func<TPrincipalEntityType, TEntityType>> navigationPropertyExpression,
      Action<AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType>> associationModificationStoredProcedureConfigurationAction)
      where TPrincipalEntityType : class
    {
      Check.NotNull<Expression<Func<TPrincipalEntityType, TEntityType>>>(navigationPropertyExpression, nameof (navigationPropertyExpression));
      Check.NotNull<Action<AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType>>>(associationModificationStoredProcedureConfigurationAction, nameof (associationModificationStoredProcedureConfigurationAction));
      AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType> procedureConfiguration = new AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType>(navigationPropertyExpression.GetSimplePropertyAccess().Single<PropertyInfo>(), this.Configuration);
      associationModificationStoredProcedureConfigurationAction(procedureConfiguration);
      return this;
    }

    /// <summary>Configures parameters for a relationship where the foreign key property is not included in the class.</summary>
    /// <returns> The same configuration instance so that multiple calls can be chained. </returns>
    /// <param name="navigationPropertyExpression"> A lambda expression representing the navigation property for the relationship. C#: t =&gt; t.MyProperty VB.Net: Function(t) t.MyProperty </param>
    /// <param name="associationModificationStoredProcedureConfigurationAction">A lambda expression that performs the configuration.</param>
    /// <typeparam name="TPrincipalEntityType">The type of the principal entity in the relationship.</typeparam>
    [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
    public UpdateModificationStoredProcedureConfiguration<TEntityType> Navigation<TPrincipalEntityType>(
      Expression<Func<TPrincipalEntityType, ICollection<TEntityType>>> navigationPropertyExpression,
      Action<AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType>> associationModificationStoredProcedureConfigurationAction)
      where TPrincipalEntityType : class
    {
      Check.NotNull<Expression<Func<TPrincipalEntityType, ICollection<TEntityType>>>>(navigationPropertyExpression, nameof (navigationPropertyExpression));
      Check.NotNull<Action<AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType>>>(associationModificationStoredProcedureConfigurationAction, nameof (associationModificationStoredProcedureConfigurationAction));
      AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType> procedureConfiguration = new AssociationModificationStoredProcedureConfiguration<TPrincipalEntityType>(navigationPropertyExpression.GetSimplePropertyAccess().Single<PropertyInfo>(), this.Configuration);
      associationModificationStoredProcedureConfigurationAction(procedureConfiguration);
      return this;
    }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString()
    {
      return base.ToString();
    }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object obj)
    {
      return base.Equals(obj);
    }

    /// <inheritdoc />
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode()
    {
      return base.GetHashCode();
    }

    /// <inheritdoc />
    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Type GetType()
    {
      return base.GetType();
    }
  }
}

﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", Target = "System.Data.Entity.ModelConfiguration.Conventions.Sets.V1ConventionSet.#.cctor()")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#_parserOptions")]
[assembly: AssemblyProduct("Microsoft Entity Framework")]
[assembly: Extension]
[assembly: AssemblyFileVersion("6.1.40302.0")]
[assembly: AssemblyInformationalVersion("6.1.3-40302")]
[assembly: SatelliteContractVersion("6.0.0.0")]
[assembly: InternalsVisibleTo("Microsoft.Data.Entity.Design.VersioningFacade, PublicKey=002400000480000094000000060200000024000052534131000400000100010007D1FA57C4AED9F0A32E84AA0FAEFD0DE9E8FD6AEC8F87FB03766C834C99921EB23BE79AD9D5DCC1DD9AD236132102900B723CF980957FC4E177108FC607774F29E8320E92EA05ECE4E821C0A5EFE8F1645C4C0C93C1AB99285D622CAA652C1DFAD63D745D6F2DE5F17E5EAF0FC4963D261C8A12436518206DC093344D5AD293")]
[assembly: AssemblyTitle("EntityFramework")]
[assembly: AssemblyDescription("EntityFramework.dll")]
[assembly: AssemblyDefaultAlias("EntityFramework.dll")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Mapping.ViewGeneration")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Migrations.Sql")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.ModelConfiguration")]
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Validation")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Migrations.Utilities")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Migrations.History")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Migrations.Builders")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.ModelConfiguration.Edm")]
[assembly: SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "System.Data.Entity.ModelConfiguration.Conventions.ForeignKeyDiscoveryConvention.#System.Data.Entity.ModelConfiguration.Conventions.IEdmConvention`1<System.Data.Entity.Edm.AssociationType>.Apply(System.Data.Entity.Edm.AssociationType,System.Data.Entity.Edm.EdmModel)")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.EdmModelSyntacticValidationRules.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.EdmModelSemanticValidationRules.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.EdmModelSemanticValidationRules.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.EdmModelSemanticValidationRules.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Console.WriteLine(System.String)", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#dump_stacks(System.Int32)")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Data.Entity.Core.SchemaObjectModel.ScalarType.ConvertToByteArray(System.String)", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.MetadataAssemblyHelper.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Data.Entity.Core.Query.PlanCompiler.PlanCompiler.Assert(System.Boolean,System.String)", Scope = "member", Target = "System.Data.Entity.Core.Query.PlanCompiler.PreProcessor.#ExpandView(System.Data.Entity.Core.Query.InternalTrees.Node,System.Data.Entity.Core.Query.InternalTrees.ScanTableOp,System.Data.Entity.Core.Query.InternalTrees.IsOfOp&)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "Def", Scope = "resource", Target = "System.Data.Entity.Properties.Resources.resources")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "dddddddd-dddd-dddd-dddd-dddddddddddd", Scope = "resource", Target = "System.Data.Entity.Properties.Resources.resources")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "Deref", Scope = "resource", Target = "System.Data.Entity.Properties.Resources.resources")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", Target = "System.Data.Entity.Core.Mapping.StorageMappingItemCollection+ViewDictionary.#GetGeneratedView(System.Data.Entity.Core.Metadata.Edm.EntitySetBase,System.Data.Entity.Core.Metadata.Edm.MetadataWorkspace,System.Data.Entity.Core.Mapping.StorageMappingItemCollection)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#yy_double(System.Char[])")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#yy_error(System.Int32,System.Boolean)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#IsCanonicalFunctionCall(System.String,System.Char)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`17(System.Linq.Expressions.Expression`1<System.Func`17<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9,!!10,!!11,!!12,!!13,!!14,!!15,!!16>>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`16(System.Linq.Expressions.Expression`1<System.Func`16<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9,!!10,!!11,!!12,!!13,!!14,!!15>>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`15(System.Linq.Expressions.Expression`1<System.Func`15<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9,!!10,!!11,!!12,!!13,!!14>>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`14(System.Linq.Expressions.Expression`1<System.Func`14<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9,!!10,!!11,!!12,!!13>>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`13(System.Linq.Expressions.Expression`1<System.Func`13<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9,!!10,!!11,!!12>>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`12(System.Linq.Expressions.Expression`1<System.Func`12<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9,!!10,!!11>>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`11(System.Linq.Expressions.Expression`1<System.Func`11<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9,!!10>>)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Scope = "member", Target = "System.Data.Entity.Core.Objects.CompiledQuery.#Compile`10(System.Linq.Expressions.Expression`1<System.Func`10<!!0,!!1,!!2,!!3,!!4,!!5,!!6,!!7,!!8,!!9>>)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#yy_error_string")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#yyrule")]
[assembly: SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "code", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#yy_error(System.Int32,System.Boolean)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#YYMAJOR")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#YYMINOR")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#yybegin(System.Int32)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#yylength()")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#debug(System.String)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#dump_stacks(System.Int32)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#yylexdebug(System.Int32,System.Int32)")]
[assembly: SuppressMessage("Microsoft.Performance", "CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Member", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer.#yy_nxt")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#yyparse()")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Mapping")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Objects.SqlClient")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Common.EntitySql")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder.Spatial")]
[assembly: SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type", Target = "System.Data.Entity.Core.Common.EntitySql.CqlLexer")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#yyparse()")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", Target = "System.Data.Entity.Core.Common.EntitySql.CqlParser.#yyparse()")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Scope = "member", Target = "System.Data.Entity.QueryableExtensions.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1505:AvoidUnmaintainableCode", Scope = "member", Target = "System.Data.Entity.QueryableExtensions.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "schemaname", Scope = "resource", Target = "System.Data.Entity.Properties.Resources.resources")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "objectname", Scope = "resource", Target = "System.Data.Entity.Properties.Resources.resources")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "URIs", Scope = "resource", Target = "System.Data.Entity.Properties.Resources.resources")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.ComponentModel.DataAnnotations")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Edm")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.ModelConfiguration.Configuration.Properties")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.ModelConfiguration.Configuration.Properties.Navigation")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.ModelConfiguration.Configuration.Types")]
[assembly: SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "System.Data.Entity.Core.Objects.ObjectParameterCollection.#System.Collections.Generic.ICollection`1<System.Data.Entity.Core.Objects.ObjectParameter>.IsReadOnly")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.ObjectItemLoadingSessionData.#.ctor(System.Data.Entity.Core.Metadata.Edm.KnownAssembliesSet,System.Data.Entity.Core.Metadata.Edm.LockedAssemblyCache,System.Data.Entity.Core.Metadata.Edm.EdmItemCollection,System.Action`1<System.String>,System.Object)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.EdmItemCollection.#Create(System.Collections.Generic.IEnumerable`1<System.Xml.XmlReader>,System.Collections.ObjectModel.ReadOnlyCollection`1<System.String>,System.Collections.Generic.IList`1<System.Data.Entity.Core.Metadata.Edm.EdmSchemaError>&)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "4#", Scope = "member", Target = "System.Data.Entity.Core.Mapping.StorageMappingItemCollection.#Create(System.Data.Entity.Core.Metadata.Edm.EdmItemCollection,System.Data.Entity.Core.Metadata.Edm.StoreItemCollection,System.Collections.Generic.IEnumerable`1<System.Xml.XmlReader>,System.Collections.Generic.IList`1<System.String>,System.Collections.Generic.IList`1<System.Data.Entity.Core.Metadata.Edm.EdmSchemaError>&)")]
[assembly: SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "3#", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.StoreItemCollection.#Create(System.Collections.Generic.IEnumerable`1<System.Xml.XmlReader>,System.Collections.ObjectModel.ReadOnlyCollection`1<System.String>,System.Data.Entity.Infrastructure.DependencyResolution.IDbDependencyResolver,System.Collections.Generic.IList`1<System.Data.Entity.Core.Metadata.Edm.EdmSchemaError>&)")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pluralization", Scope = "namespace", Target = "System.Data.Entity.Infrastructure.Pluralization")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Infrastructure.Pluralization")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "type", Target = "System.Data.Entity.Core.EntityClient.Internal.EntityCommandDefinition")]
[assembly: SuppressMessage("Microsoft.Naming", "CA1703:ResourceStringsShouldBeSpelledCorrectly", MessageId = "ms", Scope = "resource", Target = "System.Data.Entity.Properties.Resources.resources")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Infrastructure.MappingViews")]
[assembly: SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Data.Entity.Core.SchemaObjectModel.ScalarType.ConvertToByteArray(System.String)", Scope = "member", Target = "System.Data.Entity.Core.Metadata.Edm.AspProxy.#.cctor()")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.ComponentModel.DataAnnotations.Schema")]
[assembly: SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace", Target = "System.Data.Entity.Utilities")]
[assembly: SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Scope = "member", Target = "System.Data.Entity.Core.Objects.ELinq.ExpressionConverter+StringTranslatorUtil.#ConvertToString(System.Data.Entity.Core.Objects.ELinq.ExpressionConverter,System.Linq.Expressions.Expression)")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyCopyright("© Microsoft Corporation.  All rights reserved.")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("6.0.0.0")]
[assembly: TypeForwardedTo(typeof (MaxLengthAttribute))]
[assembly: TypeForwardedTo(typeof (MinLengthAttribute))]
[assembly: TypeForwardedTo(typeof (ColumnAttribute))]
[assembly: TypeForwardedTo(typeof (ComplexTypeAttribute))]
[assembly: TypeForwardedTo(typeof (DatabaseGeneratedAttribute))]
[assembly: TypeForwardedTo(typeof (DatabaseGeneratedOption))]
[assembly: TypeForwardedTo(typeof (ForeignKeyAttribute))]
[assembly: TypeForwardedTo(typeof (InversePropertyAttribute))]
[assembly: TypeForwardedTo(typeof (NotMappedAttribute))]
[assembly: TypeForwardedTo(typeof (TableAttribute))]

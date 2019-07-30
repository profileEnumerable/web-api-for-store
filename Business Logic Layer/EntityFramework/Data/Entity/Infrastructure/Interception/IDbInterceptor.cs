﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.Infrastructure.Interception.IDbInterceptor
// Assembly: EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 000F5452-2AD1-45BF-987B-3043022F9799
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll

using System.Diagnostics.CodeAnalysis;

namespace System.Data.Entity.Infrastructure.Interception
{
  /// <summary>
  /// This is the base interface for all interfaces that provide interception points for various
  /// different types and operations. For example, see <see cref="T:System.Data.Entity.Infrastructure.Interception.IDbCommandInterceptor" />.
  /// Interceptors are registered on the <see cref="T:System.Data.Entity.Infrastructure.Interception.DbInterception" /> class.
  /// </summary>
  [SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces")]
  public interface IDbInterceptor
  {
  }
}
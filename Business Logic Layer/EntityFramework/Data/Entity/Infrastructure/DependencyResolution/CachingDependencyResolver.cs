﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.Infrastructure.DependencyResolution.CachingDependencyResolver
// Assembly: EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 000F5452-2AD1-45BF-987B-3043022F9799
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.dll

using System.Collections.Concurrent;
using System.Collections.Generic;

namespace System.Data.Entity.Infrastructure.DependencyResolution
{
  internal class CachingDependencyResolver : IDbDependencyResolver
  {
    private readonly ConcurrentDictionary<Tuple<Type, object>, object> _resolvedDependencies = new ConcurrentDictionary<Tuple<Type, object>, object>();
    private readonly ConcurrentDictionary<Tuple<Type, object>, IEnumerable<object>> _resolvedAllDependencies = new ConcurrentDictionary<Tuple<Type, object>, IEnumerable<object>>();
    private readonly IDbDependencyResolver _underlyingResolver;

    public CachingDependencyResolver(IDbDependencyResolver underlyingResolver)
    {
      this._underlyingResolver = underlyingResolver;
    }

    public virtual object GetService(Type type, object key)
    {
      return this._resolvedDependencies.GetOrAdd(Tuple.Create<Type, object>(type, key), (Func<Tuple<Type, object>, object>) (k => this._underlyingResolver.GetService(type, key)));
    }

    public IEnumerable<object> GetServices(Type type, object key)
    {
      return this._resolvedAllDependencies.GetOrAdd(Tuple.Create<Type, object>(type, key), (Func<Tuple<Type, object>, IEnumerable<object>>) (k => this._underlyingResolver.GetServices(type, key)));
    }
  }
}
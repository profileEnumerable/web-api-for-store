﻿// Decompiled with JetBrains decompiler
// Type: System.Data.Entity.SqlServer.Utilities.FuncExtensions
// Assembly: EntityFramework.SqlServer, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: 0025BC3E-2252-4BA9-A352-D7F62FAA5B3F
// Assembly location: C:\Users\suckt\source\repos\Epam_Lab_Task\packages\EntityFramework.6.1.3\lib\net45\EntityFramework.SqlServer.dll

namespace System.Data.Entity.SqlServer.Utilities
{
  internal static class FuncExtensions
  {
    internal static TResult NullIfNotImplemented<TResult>(this Func<TResult> func)
    {
      try
      {
        return func();
      }
      catch (NotImplementedException ex)
      {
        return default (TResult);
      }
    }
  }
}
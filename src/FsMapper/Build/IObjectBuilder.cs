using System;
using System.Linq.Expressions;

namespace FsMapper.Build
{
    public interface IObjectBuilder
    {
        Func<TSource, TDest> GetActivator<TSource, TDest>();
    }
}
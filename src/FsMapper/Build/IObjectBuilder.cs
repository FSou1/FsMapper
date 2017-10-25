using System;
using System.Linq.Expressions;

namespace FsMapper.Build
{
    public interface IObjectBuilder
    {
        Func<TDest> GetActivator<TDest>();
    }
}
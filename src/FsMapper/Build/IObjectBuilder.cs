using System;
using System.Linq.Expressions;

namespace FsMapper.Build
{
    public interface IObjectBuilder
    {
        Expression<Func<TDest>> GetActivator<TDest>();
    }
}
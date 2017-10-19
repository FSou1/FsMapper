using System;
using System.Linq.Expressions;

namespace FsMapper.Build
{
    public interface IObjectActivator
    {
        Expression<Func<TDest>> GetActivator<TDest>();
    }
}
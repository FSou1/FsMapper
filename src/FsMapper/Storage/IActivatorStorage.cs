using System;
using System.Linq.Expressions;

namespace FsMapper.Storage
{
    public interface IActivatorStorage
    {
        bool Exist<TDest>();

        void Add<TDest>(Expression<Func<TDest>> activator) where TDest : class;

        Func<TDest> Get<TDest>();
    }
}
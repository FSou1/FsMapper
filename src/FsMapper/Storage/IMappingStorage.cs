using System;
using System.Linq.Expressions;

namespace FsMapper.Storage
{
    public interface IMappingStorage
    {
        bool Exist<TSource, TDest>();

        void Add<TSource, TDest>(Expression<Func<object, object>> activator);

        Func<object, object> Get<TSource, TDest>();
    }
}
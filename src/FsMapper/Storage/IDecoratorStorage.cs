using System;

namespace FsMapper.Storage
{
    public interface IDecoratorStorage
    {
        void Add<TSource, TDest>(Action<object, object> decorator);
        Action<object, object> Get<TSource, TDest>();
    }
}
using System;
using System.Collections.Generic;

namespace FsMapper.Storage
{
    public class DictionaryDecoratorStorage : IDecoratorStorage
    {
        public void Add<TSource, TDest>(Action<object, object> decorator)
        {
            var key = (typeof(TSource), typeof(TDest));
            _source[key] = decorator;
        }

        public Action<object, object> Get<TSource, TDest>()
        {
            return _source[(typeof(TSource), typeof(TDest))];
        }

        private readonly IDictionary<(Type, Type), Action<object, object>> _source
            = new Dictionary<(Type, Type), Action<object, object>>();
    }
}
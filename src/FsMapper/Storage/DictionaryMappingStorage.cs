using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FsMapper.Storage
{
    public class DictionaryMappingStorage : IMappingStorage
    {
        public bool Exist<TSource, TDest>()
        {
            return _source.ContainsKey((typeof(TSource), typeof(TDest)));
        }

        public void Add<TSource, TDest>(Expression<Func<object, object>> activator)
        {
            var key = (typeof(TSource), typeof(TDest));
            _source[key] = activator.Compile();
        }

        public Func<object, object> Get<TSource, TDest>()
        {
            var key = (typeof(TSource), typeof(TDest));
            return _source[key];
        }

        private readonly IDictionary<(Type, Type), Func<object, object>> _source
            = new Dictionary<(Type, Type), Func<object, object>>();
    }
}
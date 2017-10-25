using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FsMapper.Storage
{
    public class DictionaryActivatorStorage : IActivatorStorage
    {
        public bool Exist<TDest>()
        {
            return _source.ContainsKey(typeof(TDest));
        }

        public void Add<TDest>(Func<TDest> activator) where TDest : class
        {
            var key = typeof(TDest);
            _source[key] = activator;
        }

        public Func<object> Get<TDest>()
        {
            return _source[typeof(TDest)];
        }

        private readonly IDictionary<Type, Func<object>> _source
            = new Dictionary<Type, Func<object>>();
    }
}
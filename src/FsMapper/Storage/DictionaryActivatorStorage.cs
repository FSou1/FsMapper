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

        public void Add<TDest>(Expression<Func<TDest>> activator) where TDest : class
        {
            var key = typeof(TDest);
            _source[key] = activator.Compile();
        }

        public Func<TDest> Get<TDest>()
        {
            var activator = _source[typeof(TDest)];
            return () => (TDest)activator();
        }

        private readonly IDictionary<Type, Func<object>> _source
            = new Dictionary<Type, Func<object>>();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using FsMapper.Build;

namespace FsMapper
{
    public class Mapper : IMapper
    {
        public void Register<TSource, TDest>()
        {
            var activator = _objectBuilder.GetActivator<TSource, TDest>();
            var key = new TypeTuple(typeof(TSource), typeof(TDest));
            AddMap(key, activator);
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            var key = new TypeTuple(typeof(TSource), typeof(TDest));
            var activator = GetMap(key);
            return ((Func<TSource, TDest>)activator)(source);
        }

        internal void AddMap<TSource, TDest>(TypeTuple key, Func<TSource, TDest> activator)
        {
            _source[key] = activator;
        }

        internal Delegate GetMap(TypeTuple key)
        {
            return _source[key];
        }

        private readonly Dictionary<TypeTuple, Delegate> _source = new Dictionary<TypeTuple, Delegate>();

        private readonly IObjectBuilder _objectBuilder = new ExpressionNewObjectBuilder();
    }

    public interface IMapper
    {
        void Register<TSource, TDest>();
        
        TDest Map<TSource, TDest>(TSource source);
    }
}

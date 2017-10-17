using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace FsMapper
{
    public class FsMapper : IFsMapper
    {
        private IDictionary<(Type, Type), Func<object, object>> dict = new Dictionary<(Type, Type), Func<object, object>>();

        public void Register<TSource, TDest>(Func<TSource, TDest> func) 
            where TSource : class
            where TDest : class
        {
            var key = (typeof(TSource), typeof(TDest));
            if (!dict.ContainsKey(key))
            {
                dict[key] = (source) => func((TSource)source);
            }
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            if (dict.TryGetValue((typeof(TSource), typeof(TDest)), out var func))
            {
                return (TDest) func(source);
            }
            
            throw new NotSupportedException();
        }
    }

    public interface IFsMapper
    {
        void Register<TSource, TDest>(Func<TSource, TDest> func) where TSource : class where TDest : class;

        TDest Map<TSource, TDest>(TSource source);
    }
}

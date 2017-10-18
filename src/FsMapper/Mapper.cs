using System;
using System.Collections.Generic;

namespace FsMapper
{
    public class Mapper : IMapper
    {
        private IDictionary<(Type, Type), Func<object, object>> dict 
            = new Dictionary<(Type, Type), Func<object, object>>();

        public void Register<TSource, TDest>()
        {
            throw new NotImplementedException();
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

    public interface IMapper
    {
        void Register<TSource, TDest>();
        
        TDest Map<TSource, TDest>(TSource source);
    }
}

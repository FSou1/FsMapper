using System;
using System.Linq;
using System.Reflection;

namespace FsMapper.Decorate
{
    public class ReflectionObjectDecorator : IObjectDecorator
    {
        public Action<object, object> GetDecorator<TSource, TDest>()
        {
            var destProps = typeof(TDest).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sourceProps = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var methods = destProps.Join(sourceProps, x => x.Name, y => y.Name, 
                (dest, src) => (src.GetGetMethod(), dest.GetSetMethod()));
            return (fSource, fDest) =>
            {
                foreach (var pair in methods)
                {
                    pair.Item2.Invoke(fDest, new[] {pair.Item1.Invoke(fSource, null)});
                }
            };
        }
    }
}

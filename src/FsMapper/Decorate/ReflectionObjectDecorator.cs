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
            var intersect = destProps.Join(sourceProps, x => x.Name, y => y.Name, (dest, src) => (src, dest));
            return (fSource, fDest) =>
            {
                foreach (var prop in intersect)
                {
                    prop.Item2.SetValue(fDest, prop.Item1.GetValue(fSource));
                }
            };
        }
    }
}

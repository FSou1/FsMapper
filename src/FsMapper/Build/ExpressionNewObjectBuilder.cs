using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FsMapper.Build
{
    public class ExpressionNewObjectBuilder : IObjectBuilder
    {
        public Func<TSource, TDest> GetActivator<TSource, TDest>()
        {
            var ctor = typeof(TDest).GetConstructor(Type.EmptyTypes);
            if (ctor == null) throw new MissingMemberException(string.Format(Resources.MissingDefaultConstructor, typeof(TDest).Name));

            var orig = Expression.Parameter(typeof(TSource), "orig");

            var getProps = typeof(TSource).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var setProps = typeof(TDest).GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var intersect = from gp in getProps
                join sp in setProps on gp.Name equals sp.Name
                select (gp, sp);
            var props = intersect
                .Select(kv => (MemberBinding)Expression.Bind(kv.Item2, Expression.Property(orig, kv.Item1)));

            var body = Expression.MemberInit(
                Expression.New(typeof(TDest)), props
            );

            return Expression.Lambda<Func<TSource, TDest>>(body, orig).Compile();
        }
    }
}
using System;
using System.Linq.Expressions;

namespace FsMapper.Build
{
    public class ExpressionCtorObjectBuilder : IObjectBuilder
    {
        public Expression<Func<TDest>> GetActivator<TDest>()
        {
            var ctor = typeof(TDest).GetConstructor(new Type[0]);
            if (ctor == null) throw new InvalidOperationException(string.Format(Resources.MissingDefaultConstructor, typeof(TDest).Name));
            return Expression.Lambda<Func<TDest>>(Expression.New(ctor));
        }
    }
}
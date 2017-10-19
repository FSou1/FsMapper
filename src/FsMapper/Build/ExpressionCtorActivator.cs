using System;
using System.Linq.Expressions;

namespace FsMapper.Build
{
    public class ExpressionCtorActivator : IObjectActivator
    {
        public Expression<Func<TDest>> GetActivator<TDest>()
        {
            //var funcType = typeof(Func<>).MakeGenericType(typeof(TDest));
            var ctor = typeof(TDest).GetConstructor(new Type[0]);
            var lamda = Expression.Lambda<Func<TDest>>(Expression.New(ctor));
            return lamda;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using FsMapper.Extensions;

namespace FsMapper.Build
{
    public class ActivatorCreateInstanceObjectBuilder : IObjectBuilder
    {
        public Expression<Func<TDest>> GetActivator<TDest>()
        {
            var ctor = typeof(TDest).GetDefaultConstructor();
            if (ctor == null) throw new MissingMemberException(string.Format(Resources.MissingDefaultConstructor, typeof(TDest).Name));
            return () => Activator.CreateInstance<TDest>();
        }
    }
}

using System;
using FsMapper.Extensions;

namespace FsMapper.Build
{
    public class ActivatorCreateInstanceObjectBuilder : IObjectBuilder
    {
        public Func<TDest> GetActivator<TDest>()
        {
            var ctor = typeof(TDest).GetDefaultConstructor();
            if (ctor == null) throw new MissingMemberException(string.Format(Resources.MissingDefaultConstructor, typeof(TDest).Name));
            return Activator.CreateInstance<TDest>;
        }
    }
}

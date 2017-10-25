using System;
using System.Reflection;
using System.Reflection.Emit;
using FsMapper.Extensions;

namespace FsMapper.Build
{
    public class DynamicMethodObjectBuilder : IObjectBuilder
    {
        public Func<TDest> GetActivator<TDest>()
        {
            var ctor = typeof(TDest).GetDefaultConstructor();
            if (ctor == null) throw new MissingMemberException(string.Format(Resources.MissingDefaultConstructor, typeof(TDest).Name));
            return BuildConstructor<TDest>(ctor);
        }

        public Func<TDest> BuildConstructor<TDest>(ConstructorInfo ctorInfo)
        {
            var dynamicMethod = new DynamicMethod("Create_" + ctorInfo.Name, ctorInfo.DeclaringType, new[] { typeof(object[]) });
            var ilgen = dynamicMethod.GetILGenerator();
            ilgen.Emit(OpCodes.Newobj, ctorInfo);
            ilgen.Emit(OpCodes.Ret);
            return (Func<TDest>) dynamicMethod.CreateDelegate(typeof(Func<TDest>));
        }
    }
}
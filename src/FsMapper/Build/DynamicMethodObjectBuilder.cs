using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using FsMapper.Extensions;
using System.Runtime;

namespace FsMapper.Build
{
    public class DynamicMethodObjectBuilder : IObjectBuilder
    {
        public Expression<Func<TDest>> GetActivator<TDest>()
        {
            var ctor = typeof(TDest).GetDefaultConstructor();
            if (ctor == null) throw new MissingMemberException(string.Format(Resources.MissingDefaultConstructor, typeof(TDest).Name));
            var activator = BuildConstructor<TDest>(ctor);
            return () => activator();
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
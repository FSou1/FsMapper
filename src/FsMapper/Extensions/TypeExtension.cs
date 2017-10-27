using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FsMapper.Extensions
{
    public static class TypeExtension
    {
        public static ConstructorInfo GetDefaultConstructor(this Type self)
            => self.GetConstructor(Type.EmptyTypes);
    }
}
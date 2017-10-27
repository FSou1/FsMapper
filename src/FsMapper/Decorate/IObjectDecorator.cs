using System;
using System.Collections.Generic;
using System.Text;

namespace FsMapper.Decorate
{
    public interface IObjectDecorator
    {
        Action<object, object> GetDecorator<TSource, TDest>();
    }
}

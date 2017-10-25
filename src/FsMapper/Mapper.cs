using FsMapper.Build;
using FsMapper.Storage;

namespace FsMapper
{
    public class Mapper : IMapper
    {
        public void Register<TSource, TDest>() where TDest : class
        {
            _storage.Add(_builder.GetActivator<TDest>());
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            return (TDest)_storage.Get<TDest>()();
        }
        
        private readonly IObjectBuilder _builder = new ExpressionNewObjectBuilder();
        private readonly IActivatorStorage _storage = new DictionaryActivatorStorage();
    }

    public interface IMapper
    {
        void Register<TSource, TDest>() where TDest : class;
        
        TDest Map<TSource, TDest>(TSource source);
    }
}

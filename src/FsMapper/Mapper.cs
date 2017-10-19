using FsMapper.Build;
using FsMapper.Storage;

namespace FsMapper
{
    public class Mapper : IMapper
    {
        public void Register<TSource, TDest>()
        {
            var expression = _activator.GetActivator<TDest>();
            _storage.Add<TSource, TDest>(expression);
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            var activator = _storage.Get<TSource, TDest>();
            return (TDest) activator(source);
        }
        
        private readonly IObjectActivator _activator = new ExpressionCtorActivator();
        private readonly IMappingStorage _storage = new DictionaryMappingStorage();
    }

    public interface IMapper
    {
        void Register<TSource, TDest>();
        
        TDest Map<TSource, TDest>(TSource source);
    }
}

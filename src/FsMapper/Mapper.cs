using FsMapper.Build;
using FsMapper.Decorate;
using FsMapper.Storage;

namespace FsMapper
{
    public class Mapper : IMapper
    {
        public void Register<TSource, TDest>() where TDest : class
        {
            _activatorStorage.Add(_objectBuilder.GetActivator<TDest>());
            _decoratorStorage.Add<TSource, TDest>(_objectDecorator.GetDecorator<TSource, TDest>());
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            var activator = _activatorStorage.Get<TDest>();
            var decorator = _decoratorStorage.Get<TSource, TDest>();
            var instance = activator();
            decorator(source, instance);
            return (TDest)instance;
        }
        
        private readonly IObjectBuilder _objectBuilder = new ExpressionNewObjectBuilder();
        private readonly IObjectDecorator _objectDecorator = new ReflectionObjectDecorator();
        private readonly IActivatorStorage _activatorStorage = new DictionaryActivatorStorage();
        private readonly IDecoratorStorage _decoratorStorage = new DictionaryDecoratorStorage();
    }

    public interface IMapper
    {
        void Register<TSource, TDest>() where TDest : class;
        
        TDest Map<TSource, TDest>(TSource source);
    }
}

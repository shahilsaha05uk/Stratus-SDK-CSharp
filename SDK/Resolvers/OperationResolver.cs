
namespace StratusSDK
{
    public abstract class OperationResolver
    {
        public abstract T Resolve<T>() where T : BaseOperation;
    }
}
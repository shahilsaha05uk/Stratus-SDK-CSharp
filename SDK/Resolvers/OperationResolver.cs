
using StratusSDK.Core.Operation;
using StratusSDK;

namespace StratusSDK.Resolvers
{
    public abstract class OperationResolver
    {
        public abstract T Resolve<T>() where T : BaseOperation;
    }
}
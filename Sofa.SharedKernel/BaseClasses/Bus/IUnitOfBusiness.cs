using System.Threading.Tasks;

namespace Sofa.SharedKernel.BaseClasses
{
    public interface IUnitOfBusiness<TMessage, TResult>
    {
        Task<TResult> Do(TMessage message);
    }
}

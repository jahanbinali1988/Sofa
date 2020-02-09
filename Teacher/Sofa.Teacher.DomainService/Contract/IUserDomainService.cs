using Sofa.Teacher.Model;
using System.Threading.Tasks;

namespace Sofa.Teacher.DomainService
{
    public interface IUserDomainService
    {
        Task CanAdd(User user);
        Task<bool> Existance(string phoneNumber);
    }
}

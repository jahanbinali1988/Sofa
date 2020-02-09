using System.Threading.Tasks;

namespace Sofa.Teacher.ApplicationService.Service
{
    public interface IUserService
    {
        Task<AddUserResponse> AddUser(AddUserRequest request);
        Task<ExistedUserResponse> ExistedUser(ExistedUserRequest request);
        Task<GetUserByIdResponse> Get(GetUserByIdRequest request);
        Task<GetUserByPhoneNumberResponse> GetByPhoneNumber(GetUserByPhoneNumberRequest request);
    }
}

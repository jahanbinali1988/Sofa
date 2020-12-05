using MassTransit;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.Teacher.DomainService;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.ApplicationService.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDomainService _userDomainService;
        private readonly IBusControl _bus;
        private readonly ILogger _logger;
        public UserService(IUnitOfWork unitOfWork, IUserDomainService userDomainService, IBusControl bus, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._userDomainService = userDomainService;
            this._bus = bus;
            this._logger = logger;
        }

        public async Task<ExistedUserResponse> ExistedUser(ExistedUserRequest request)
        {
            try
            {
                var result = await _userDomainService.Existance(request.PhoneNumber);

                return new ExistedUserResponse(true, "شماره وارد شده در سیستم وجود دارد") { Existed = result };
            }
            catch (BusinessException e)
            {
                this._logger.Error("Teacher-User service-Existed user-BusinessException ", e.Message);
                return new ExistedUserResponse(true, e.Message) { Existed = false };
            }
            catch (Exception e)
            {
                this._logger.Error("Teacher-User service-Existed user-Exception ", e.Message);
                return new ExistedUserResponse(false, e.Message);
            }
        }

        public async Task<AddUserResponse> AddUser(AddUserRequest request)
        {
            try
            {
                var user = User.CreateInstance(null, request.FirstName, request.LastName, request.Email, request.UserName, request.Level,
                    request.PhoneNumber, true, null, request.Description);
                await _userDomainService.CanAdd(user);

                _unitOfWork.userRepository.Add(user);
                _unitOfWork.Commit();

                //await _bus.Publish<RegisteredUserEvent>(new RegisteredUserEvent()
                //{
                //    Description = "Created in Teacher Bot",
                //    Email = user.Email,
                //    FirstName = user.FirstName,
                //    Id = user.Id,
                //    IsActive = true,
                //    LastName = user.LastName,
                //    PasswordHash = SHA256HashGenerator.GenerateSHA256Hash(user.PhoneNumber),
                //    PhoneNumber = user.PhoneNumber,
                //    Role = (short)UserRoleEnum.Student,
                //    UserName = user.UserName
                //});

                return new AddUserResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = user.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Error("Teacher-User service-Add user-BusinessException ", e.Message);
                return new AddUserResponse(false, e.Message);
            }
            catch (Exception e)
            {
                this._logger.Error("Teacher-User service-Add user-Exception ", e.Message);
                return new AddUserResponse(false, e.Message);
            }
        }

        public async Task<GetUserByIdResponse> Get(GetUserByIdRequest request)
        {
            try
            {
                var user = await _unitOfWork.userRepository.GetAsync(request.UserId);

                return new GetUserByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { User = user.Convert() };
            }
            catch (BusinessException e)
            {
                this._logger.Error("Teacher-User service-Get user-BusinessException ", e.Message);
                return new GetUserByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Teacher-User service-Get user-Exception ", e.Message);
                return new GetUserByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public async Task<GetUserByPhoneNumberResponse> GetByPhoneNumber(GetUserByPhoneNumberRequest request)
        {
            try
            {
                var user = await _unitOfWork.userRepository.QueryAsync(c => c.PhoneNumber.Equals(request.PhoneNumber));

                return new GetUserByPhoneNumberResponse(true, "عملیات خواندن با موفقیت انجام شد", "")
                {
                    User = user.FirstOrDefault().Convert()
                };
            }
            catch (BusinessException e)
            {
                this._logger.Error("Teacher-User service-GetByPhoneNumber user-BusinessException ", e.Message);
                return new GetUserByPhoneNumberResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Teacher-User service-GetByPhoneNumber user-Exception ", e.Message);
                return new GetUserByPhoneNumberResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}

using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.User;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Log;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDomainService _userDomainService;
        private IBusControl _busControl;
        public UserService(IUnitOfWork unitOfWork, IUserDomainService userDomainService, IBusControl busControl)
        {
            this._unitOfWork = unitOfWork;
            this._userDomainService = userDomainService;
            this._busControl = busControl;
        }

        public AddUserResponse AddUser(AddUserRequest request)
        {
            try
            {
                request.Validate();

                var user = User.DefaultFactory(request.FirstName, request.LastName, request.Password, request.Email, request.UserName,
                    (UserRoleEnum)request.Role, request.PhoneNumber, request.IsActive);
                this._userDomainService.CanAdd(user);
                
                this._unitOfWork.userRepository.Add(user);
                this._unitOfWork.Commit();

                this._busControl.Publish<RegisteredUserEvent>(new RegisteredUserEvent() {
                    Description = "Created in CourseManagement Module",
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    IsActive = user.IsActive,
                    LastName= user.LastName,
                    PasswordHash = user.PasswordHash,
                    PhoneNumber = user.PhoneNumber,
                    Role= (short)user.Role,
                    UserName = user.UserName,
                    Level = (short)user.Level
                });
                return new AddUserResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = user.Id };
            }
            catch (BusinessException e)
            {
                Logger.Log("BusinessException", "CourseManagement", "User", "AddUser", e.Message);
                return new AddUserResponse(false, e.Message);
            }
            catch (Exception e)
            {
                Logger.Log("Exception", "CourseManagement", "User", "AddUser", e.Message);
                return new AddUserResponse(false, e.Message);
            }
        }

        public GetUserByIdResponse Get(GetUserByIdRequest request)
        {
            try
            {
                request.Validate();

                var user = this._unitOfWork.userRepository.Get(request.UserId);
                return new GetUserByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { User = user.Convert() };
            }
            catch (BusinessException e)
            {
                Logger.Log("BusinessException", "CourseManagement", "User", "Get", e.Message);
                return new GetUserByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                Logger.Log("Exception", "CourseManagement", "User", "Get", e.Message);
                return new GetUserByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }
    }
}

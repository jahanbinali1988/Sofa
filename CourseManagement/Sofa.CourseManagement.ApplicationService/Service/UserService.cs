using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.User;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Validation;
using System;
using Sofa.SharedKernel;

namespace Sofa.CourseManagement.ApplicationService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserDomainService _userDomainService;
        private IBusControl _busControl;
        private readonly ILogger _logger;
        public UserService(IUnitOfWork unitOfWork, IUserDomainService userDomainService, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            this._userDomainService = userDomainService;
            this._busControl = busControl;
            this._logger = logger;
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
                return new AddUserResponse(true, "ثبت با موفقیت انجام شد", null) { NewRecordedId = user.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Users Service-Add User ", e.Message);
                return new AddUserResponse(false, "ثبت با مشکل مواجه شده است", e.Message);
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-User Service-Add User ", e.Message);
                return new AddUserResponse(false, "ثبت با مشکل مواجه شده است", e.Message);
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
                this._logger.Warning("Course Management-User Service-Get User ", e.Message);
                return new GetUserByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-User Service-Get User ", e.Message);
                return new GetUserByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetAllUserResponse GetAll(GetAllUserRequest request)
        {
            throw new NotImplementedException();
        }

        public UpdateUserResponse Update(UpdateUserRequest request)
        {
            throw new NotImplementedException();
        }

        public DeleteUserResponse Delete(DeleteUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

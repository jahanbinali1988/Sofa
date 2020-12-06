using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.User;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedKernel.Validation;
using System;

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

                var user = User.CreateInstance(null, request.FirstName, request.LastName, request.Password, request.Email, request.UserName,
                    (UserRoleEnum)request.Role, request.PhoneNumber, (LevelEnum)request.Level, request.IsActive, request.Description);
                this._userDomainService.CanAdd(user);

                this._unitOfWork.userRepository.Add(user);
                this._unitOfWork.Commit();
                this._busControl.Publish<RegisteredUserEvent>(new RegisteredUserEvent()
                {
                    Description = "Created in CourseManagement module",
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    IsActive = user.IsActive,
                    LastName = user.LastName,
                    PasswordHash = user.PasswordHash,
                    PhoneNumber = user.PhoneNumber,
                    Role = (short)user.Role,
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
            try
            {
                request.Validate();

                var user = this._unitOfWork.userRepository.GetAll();
                var result = user.Convert();
                return new GetAllUserResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Users = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-User Service-GetAll User ", e.Message);
                return new GetAllUserResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-User Service-GetAll User ", e.Message);
                return new GetAllUserResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateUserResponse Update(UpdateUserRequest request)
        {
            try
            {
                request.Validate();

                var user = User.CreateInstance(request.Id, request.FirstName, request.LastName, request.Password, request.Email, request.UserName, (UserRoleEnum)request.Role,
                    request.PhoneNumber, (LevelEnum)request.Level, request.IsActive, request.Description);
                this._unitOfWork.userRepository.Update(user);
                this._unitOfWork.Commit();
                this._busControl.Publish<RegisteredUserEvent>(new RegisteredUserEvent()
                {
                    Description = "Updated in CourseManagement module",
                    IsDeleted= user.IsDeleted,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    Id = user.Id,
                    IsActive = user.IsActive,
                    LastName = user.LastName,
                    PasswordHash = user.PasswordHash,
                    PhoneNumber = user.PhoneNumber,
                    Role = (short)user.Role,
                    UserName = user.UserName,
                    Level = (short)user.Level
                });

                return new UpdateUserResponse(true, "ویرایش با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-User Service-Update User ", e.Message);
                return new UpdateUserResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-User Service-Update User ", e.Message);
                return new UpdateUserResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeleteUserResponse Delete(DeleteUserRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.userRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateUserIsDeletedStatusEvent>(new UpdateUserIsDeletedStatusEvent()
                {
                    Id = request.Id
                });

                return new DeleteUserResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-User Service-Delete User ", e.Message);
                return new DeleteUserResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-User Service-Delete User ", e.Message);
                return new DeleteUserResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public ChangeActiveStatusUserResponse ChangeActiveStatus(ChangeActiveStatusUserRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.userRepository.ChangeActiveStatus(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateUserIsActiveStatusEvent>(new UpdateUserIsActiveStatusEvent()
                {
                    Id = request.Id
                });

                return new ChangeActiveStatusUserResponse(true, "به روزرسانی با موفقیت انجام شد.");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-User Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusUserResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-User Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusUserResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
        }

        public SearchUserResponse Search(SearchUserRequest request)
        {
            try
            {
                var user = this._unitOfWork.userRepository.QueryPage(request.PageIndex, request.PageSize, 
                    (c=> c.UserName.StartsWith(request.Caption) || c.FirstName.StartsWith(request.Caption) || c.LastName.StartsWith(request.Caption)));
                var result = user.Convert();
                return new SearchUserResponse(true, "عملیات خواندن با موفقیت انجام شد") { Users = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-User Service-Search ", e.Message);
                return new SearchUserResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-User Service-Search ", e.Message);
                return new SearchUserResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
        }
    }
}

using MassTransit;
using Sofa.CourseManagement.DomainService;
using Sofa.CourseManagement.Model;
using Sofa.CourseManagement.Repository;
using Sofa.Events.Term;
using Sofa.SharedKernel;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Validation;
using System;

namespace Sofa.CourseManagement.ApplicationService
{
    public class TermService : ITermService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITermDomainService _termDomainService;
        private readonly IBusControl _busControl;
        private readonly ILogger _logger;

        public TermService(IUnitOfWork unitOfWork, ITermDomainService termDomainService, IBusControl busControl, ILogger logger)
        {
            this._unitOfWork = unitOfWork;
            _termDomainService = termDomainService;
            this._busControl = busControl;
            this._logger = logger;
        }

        public AddTermResponse AddTerm(AddTermRequest request)
        {
            try
            {
                request.Validate();
                _termDomainService.CanAdd(request.Title);

                var term = Term.CreateInstance(null, request.Title, request.CourseId, request.IsActive, request.Description);
                this._unitOfWork.termRepository.Add(term);
                this._unitOfWork.Commit();
                this._busControl.Publish<RegisterTermEvent>(new RegisterTermEvent()
                {
                    Description = "Created in CourseManagement module",
                    CourseId = term.CourseId,
                    Id = term.Id,
                    CreateDate = term.CreateDate,
                    IsActive = term.IsActive,
                    IsDeleted = term.IsDeleted,
                    ModifiedDate = term.ModifyDate,
                    Title = term.Title
                });

                return new AddTermResponse(true, "ثبت با موفقیت انجام شد") { NewRecordedId = term.Id };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Add Term ", e.Message);
                return new AddTermResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Add Term ", e.Message);
                return new AddTermResponse(false, "ثبت با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetTermByIdResponse Get(GetTermByIdRequest request)
        {
            try
            {
                request.Validate();

                var term = this._unitOfWork.termRepository.Get(request.TermId);
                var result = term.Convert();
                return new GetTermByIdResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Term = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Get Term ", e.Message);
                return new GetTermByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Get Term ", e.Message);
                return new GetTermByIdResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public GetAllTermResponse GetAll(GetAllTermRequest request)
        {
            try
            {
                request.Validate();

                var term = this._unitOfWork.termRepository.GetAll();
                var result = term.Convert();
                return new GetAllTermResponse(true, "عملیات خواندن با موفقیت انجام شد", "") { Terms = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-GetAll Term ", e.Message);
                return new GetAllTermResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-GetAll Term ", e.Message);
                return new GetAllTermResponse(false, "عملیات خواندن با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public UpdateTermResponse Update(UpdateTermRequest request)
        {
            try
            {
                request.Validate();

                var term = Term.CreateInstance(request.Id, request.Title, request.CourseId, request.IsActive, request.Description);
                this._unitOfWork.termRepository.Update(term);
                this._unitOfWork.Commit();
                this._busControl.Publish<RegisterTermEvent>(new RegisterTermEvent()
                {
                    Description = "Updated in CourseManagement module",
                    CourseId = term.CourseId,
                    Id = term.Id,
                    CreateDate = term.CreateDate,
                    IsActive = term.IsActive,
                    IsDeleted = term.IsDeleted,
                    ModifiedDate = term.ModifyDate,
                    Title = term.Title
                });

                return new UpdateTermResponse(true, "ویرایش با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Update Term ", e.Message);
                return new UpdateTermResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Update Term ", e.Message);
                return new UpdateTermResponse(false, "ویرایش با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public DeleteTermResponse Delete(DeleteTermRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.termRepository.SafeDelete(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateTermIsDeletedStatusEvent>(new UpdateTermIsDeletedStatusEvent()
                {
                    Id = request.Id
                });

                return new DeleteTermResponse(true, "حذف با موفقیت انجام شد");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Delete Term ", e.Message);
                return new DeleteTermResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Delete Term ", e.Message);
                return new DeleteTermResponse(false, "حذف با مشکل مواجه شد.", e.Message.ToString());
            }
        }

        public ChangeActiveStatusTermResponse ChangeActiveStatus(ChangeActiveStatusTermRequest request)
        {
            try
            {
                request.Validate();

                this._unitOfWork.userRepository.ChangeActiveStatus(request.Id);
                this._unitOfWork.Commit();
                this._busControl.Publish<UpdateTermIsActiveStatusEvent>(new UpdateTermIsActiveStatusEvent()
                {
                    Id = request.Id
                });

                return new ChangeActiveStatusTermResponse(true, "به روزرسانی با موفقیت انجام شد.");
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusTermResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-ChangeActiveStatus ", e.Message);
                return new ChangeActiveStatusTermResponse(false, "به روزرسانی با موفقیت انجام شد.", e.Message.ToString());
            }
        }

        public SearchTermResponse Search(SearchTermRequest request)
        {
            try
            {
                var terms = this._unitOfWork.termRepository.QueryPage(request.PageIndex, request.PageSize,
                    (c => c.Title.StartsWith(request.Caption)));
                var result = terms.Convert();
                return new SearchTermResponse(true, "عملیات خواندن با موفقیت انجام شد") { Terms = result };
            }
            catch (BusinessException e)
            {
                this._logger.Warning("Course Management-Term Service-Search ", e.Message);
                return new SearchTermResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
            catch (Exception e)
            {
                this._logger.Error("Course Management-Term Service-Search ", e.Message);
                return new SearchTermResponse(false, "عملیات خواندن با موفقیت انجام شد", e.Message.ToString());
            }
        }
    }
}

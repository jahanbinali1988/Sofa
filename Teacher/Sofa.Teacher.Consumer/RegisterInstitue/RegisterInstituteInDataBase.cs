﻿using Sofa.Events.Institute;
using Sofa.SharedKernel.BaseClasses;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterInstitute
{
public class RegisterInstituteInDataBase : IUnitOfBusiness<RegisterInstituteEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegisterInstituteInDataBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterInstituteEvent message)
        {
            try
            {
                if (message.Id != null && message.Id != Guid.Empty)
                {
                    Institute institute = _unitOfWork.instituteRepository.Get(message.Id);

                    institute.AssignDescription(message.Description);
                    institute.AssignIsActive(message.IsActive);
                    institute.AssignIsDeleted(message.IsDeleted);
                    institute.AssignModifiedDate(DateTime.Now);
                    institute.IncreaseRowVersion();
                    institute.AssignTitle(message.Title);
                    
                    _unitOfWork.instituteRepository.Update(institute);
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                Institute newInstitute = Institute.CreateInstance(null, message.Title, message.IsActive, message.Description);

                await _unitOfWork.instituteRepository.AddAsync(newInstitute);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }
    }
}

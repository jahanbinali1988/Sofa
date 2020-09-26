using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Repository
{
    public interface IInstituteRepository : IEfRepositoryBase<Institute, Guid>
    {
        IEnumerable<Institute> GetInstitutesWithFieldsById(Guid instituteId);
    }
}

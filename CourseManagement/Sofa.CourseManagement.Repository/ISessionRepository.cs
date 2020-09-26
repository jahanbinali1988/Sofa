﻿using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Repository;
using System;
using System.Collections.Generic;

namespace Sofa.CourseManagement.Repository
{
    public interface ISessionRepository : IEfRepositoryBase<Session, Guid>
    {
    }
}
using MassTransit.Initializers.Conventions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ILessonPlanRepository lessonPlanRepository { get; }
        IPostRepository postRepository { get; }
        IUserRepository userRepository { get; }
        IInstituteRepository instituteRepository { get; }
        IFieldRepository fieldRepository { get; }
        ICourseRepository courseRepository { get; }
        ITermRepository termRepository { get; }
        ISessionRepository sessionRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        Task CommitAsync();
    }
}

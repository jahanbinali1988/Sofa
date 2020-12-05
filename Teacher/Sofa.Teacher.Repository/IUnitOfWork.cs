using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IInstituteRepository instituteRepository { get; }
        IFieldRepository fieldRepository { get; }
        ICourseRepository courseRepository { get; }
        ITermRepository termRepository { get; }
        ISessionRepository sessionRepository { get; }
        ILessonPlanRepository lessonPlanRepository { get; }
        IPostRepository postRepository { get; }
        IUserRepository userRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        Task CommitAsync();
    }
}

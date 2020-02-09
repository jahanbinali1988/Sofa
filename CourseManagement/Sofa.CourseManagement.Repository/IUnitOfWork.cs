using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ILessonPlanRepository lessonPlanRepository { get; }
        ILessonRepository lessonRepository { get; }
        IPostRepository postRepository { get; }
        IUserRepository userRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        Task CommitAsync();
    }
}

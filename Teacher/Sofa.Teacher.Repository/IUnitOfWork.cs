using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        ILessonPlanRepository lessonPlanRepository { get; }
        ICourseRepository courseRepository { get; }
        IPostRepository postRepository { get; }
        IUserRepository userRepository { get; }

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
        void Commit();
        Task CommitAsync();
    }
}

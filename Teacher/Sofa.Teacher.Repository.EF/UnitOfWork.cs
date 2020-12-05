using Microsoft.EntityFrameworkCore.Storage;
using Sofa.Teacher.EntityFramework.Context;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        ILessonPlanRepository IUnitOfWork.lessonPlanRepository => new LessonPlanRepository(_context);
        ICourseRepository IUnitOfWork.courseRepository => new CourseRepository(_context);
        IPostRepository IUnitOfWork.postRepository => new PostRepository(_context);
        IUserRepository IUnitOfWork.userRepository => new UserRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
        void IDisposable.Dispose()
        {
            _context.Dispose();
        }
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return _context.Database.BeginTransactionAsync();
        }
    }
}

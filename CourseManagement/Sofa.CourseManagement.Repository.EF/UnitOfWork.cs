using Microsoft.EntityFrameworkCore.Storage;
using Sofa.CourseManagement.EntityFramework.Context;
using System;
using System.Threading.Tasks;

namespace Sofa.CourseManagement.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        ILessonPlanRepository IUnitOfWork.lessonPlanRepository => new LessonPlanRepository(_context);
        IPostRepository IUnitOfWork.postRepository => new PostRepository(_context);
        IUserRepository IUnitOfWork.userRepository => new UserRepository(_context);
        public IInstituteRepository instituteRepository => new InstituteRepository(_context);
        public IFieldRepository fieldRepository => new FieldRepository(_context);
        public ICourseRepository courseRepository => new CourseRepository(_context);
        public ITermRepository termRepository => new TermRepository(_context);
        public ISessionRepository sessionRepository => new SessionRepository(_context);

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
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

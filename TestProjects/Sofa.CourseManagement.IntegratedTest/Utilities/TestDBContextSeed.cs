using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Seed;
using Sofa.SharedKernel;
using Sofa.SharedKernel.Enum;
using System;

namespace Sofa.CourseManagement.IntegratedTest.Utilities
{
    public class TestDBContextSeed : IDbContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var defaultInstitute = Institute.CreateInstance(DefaultData.InstituteId, "TestInstitute", Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, Guid.NewGuid().ToString());

            var defaultField = Field.CreateInstance(DefaultData.FieldId, "DefaultField", defaultInstitute.Id, true, string.Empty);

            var defaultCourse = Course.CreateInstance(DefaultData.CourseId, "DefaultCourse", AgeRangeEnum.Adults, defaultField.Id, true, string.Empty);

            var defaultTerm = Term.CreateInstance(DefaultData.TermId, "DefaultTerm", defaultCourse.Id, true, string.Empty);

            var defaultLessonPlan = LessonPlan.CreateInstance(DefaultData.LessonPlanId, LevelEnum.Begginer, DefaultData.SessionId, true, string.Empty);

            var defaultSession = Session.CreateInstance(DefaultData.SessionId, "DefaultSession", defaultLessonPlan.Id, defaultTerm.Id, true, string.Empty);

            var defaultPost = Post.CreateInstance(DefaultData.PostId, "DefaultPost", 1, ContentTypeEnum.Text, Guid.NewGuid().ToString(), defaultLessonPlan.Id, true, string.Empty);

            modelBuilder.Entity<Institute>().HasData(defaultInstitute);
            modelBuilder.Entity<Field>().HasData(defaultField);
            modelBuilder.Entity<Course>().HasData(defaultCourse);
            modelBuilder.Entity<Term>().HasData(defaultTerm);
            modelBuilder.Entity<LessonPlan>().HasData(defaultLessonPlan);
            modelBuilder.Entity<Session>().HasData(defaultSession);
            modelBuilder.Entity<Post>().HasData(defaultPost);
        }
    }
}

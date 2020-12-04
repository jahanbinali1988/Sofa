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
            var defaultInstitute = Institute.CreateInstance(DefaultData.InstituteId, "TestInstitute", true, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

            var defaultField = Field.CreateInstance(DefaultData.FieldId, "DefaultField", true, defaultInstitute.Id);

            var defaultCourse = Course.CreateInstance(DefaultData.CourseId, "DefaultCourse", AgeRangeEnum.Adults, true, defaultField.Id);

            var defaultTerm = Term.CreateInstance(DefaultData.TermId, "DefaultTerm", true, defaultCourse.Id, string.Empty);

            var defaultLessonPlan = LessonPlan.CreateInstance(DefaultData.LessonPlanId, SharedKernel.Enum.LevelEnum.Begginer, true);

            var defaultSession = Session.CreateInstance(DefaultData.SessionId, "DefaultSession", true, defaultLessonPlan.Id, defaultTerm.Id, string.Empty);

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

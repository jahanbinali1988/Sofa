using Microsoft.EntityFrameworkCore;
using Sofa.CourseManagement.Model;
using Sofa.EntityFramework.Seed;
using System;

namespace Sofa.CourseManagement.IntegratedTest.Utilities
{
    public class TestDBContextSeed : IDbContextSeed
    {
        public void Seed(ModelBuilder modelBuilder)
        {
            var defaultInstitute = Institute.CreateInstance(DefaultData.defaultInstituteId, "TestInstitute", true, Guid.NewGuid().ToString());

            var defaultField = Field.CreateInstance(DefaultData.defaultFieldId, "DefaultField", true, defaultInstitute.Id);

            var defaultCourse = Course.CreateInstance(DefaultData.defaultCourseId, "DefaultCourse", "", true, defaultField.Id);

            var defaultTerm = Term.CreateInstance(DefaultData.defaultTermId, "DefaultTerm", true, defaultCourse.Id);

            var defaultLessonPlan = LessonPlan.CreateInstance(DefaultData.defaultLessonPlanId, SharedKernel.Enum.LevelEnum.Begginer, true);

            var defaultSession = Session.CreateInstance(DefaultData.defaultSessionId, "DefaultSession", true, defaultLessonPlan.Id, defaultTerm.Id);

            var defaultPost = Post.CreateInstance(DefaultData.defaultPostId, "DefaultPost", 1, SharedKernel.Enum.PostTypeEnum.Text, defaultLessonPlan.Id, true);

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

using System;

namespace Sofa.CourseManagement.EntityFramework.Seed
{
    public static class DefaultData
    {
        public static string SysAdminUsername => "sysadmin";
        public static string SysAdminPassword => "123456";
        public static Guid SysAdminId => Guid.Parse("731874E2-B89C-4509-819A-5B69396A336B");

        public static string TeacherUsername => "teacher";
        public static string TeacherPassword => "123456";
        public static Guid TeacherUserId => Guid.Parse("253E472E-21AC-4864-B218-B364169D0611");

        public static string StudentUsername => "student";
        public static string StudentPassword => "123456";
        public static Guid StudentId => Guid.Parse("50ECC8E1-5C5C-4A97-A5F5-AF9E9EBA1B70");

        public static Guid defaultInstituteId => Guid.Parse("E9A52E3D-27AA-4726-A1A9-BF90B6CC2357");
        public static Guid defaultFieldId => Guid.Parse("CCDD20D4-B2A0-455A-8F7A-168503776B82");
        public static Guid defaultCourseId => Guid.Parse("B70D992C-2B43-496A-9981-3578E2D0EC4C");
        public static Guid defaultTermId => Guid.Parse("21B8DC7F-9D87-409D-9EC1-46287E7A6559");
        public static Guid defaultSessionId => Guid.Parse("49F4C5F7-D568-449C-9B5F-4D5B987E1E59");
        public static Guid defaultLessonPlanId => Guid.Parse("0908EC03-9F07-426A-A26C-78CAC8646545");
        public static Guid defaultPostId => Guid.Parse("B0108B2C-5837-4F22-B78D-857BC22F9554");
    }
}

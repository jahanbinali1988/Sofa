using System;

namespace Sofa.CourseManagement.IntegratedTest
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

    }
}

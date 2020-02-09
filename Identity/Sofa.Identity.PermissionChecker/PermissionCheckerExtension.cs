using Sofa.Identity.Model;
using Sofa.SharedKernel.BaseClasses.Exceptions;
using Sofa.SharedKernel.Enum;
using Sofa.SharedSpecs;
using System;

namespace Sofa.Identity.PermissionChecker
{
    public static class PermissionCheckerExtension
    {
        public static void ShouldBeTeacher(this User user)
        {
            if (user.Role != UserRoleEnum.SysAdmin || user.Role != UserRoleEnum.Teacher)
                throw new AccessDeniedException("دسترسی به این بخش فقط برای کاربر مدرس امکان پذیر است.");
        }

        public static bool IsMatchWithLevelOrCourse(this User user, Guid levelId, Guid courseId)
        {
            if (user.Role == UserRoleEnum.SysAdmin || user.Role == UserRoleEnum.Teacher)
                return true;
            else if (user.Role == UserRoleEnum.Student)
            {
                var isMatchForCourse = new UserIsMatchWithCourseSpec(levelId, courseId);
                if(isMatchForCourse.IsSatisfiedBy(user))
                    return false;

                return true;
            }
            return false;
        }

        public static bool IsSysAdmin(this User user)
        {
            return user.Role == UserRoleEnum.SysAdmin;
        }
    }
}

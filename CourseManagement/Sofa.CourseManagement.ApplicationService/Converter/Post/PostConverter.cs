using Sofa.CourseManagement.Model;
using System.Collections.Generic;
using System.Linq;
using Sofa.SharedKernel.Enum;

namespace Sofa.CourseManagement.ApplicationService
{
    public static class PostConverter
    {
        public static PostDto Convert(this Post source)
        {
            if (source == null)
            {
                return null;
            }

            return new PostDto
            {
                Id = source.Id,
                Title = source.Title,
                ContentType = source.ContentType,
                Order = source.Order,
                Content = source.Content,
                PostTypeCaption = source.ContentType.GetDescription(),
                IsActive = source.IsActive,
                LessonPlanId = source.LessonPlanId,
                CreateDate = source.CreateDate,
                ModifiedDate = source.ModifyDate,
                Description = source.Description
            };
        }

        public static IEnumerable<PostDto> Convert(this IEnumerable<Post> source)
        {
            if (source == null)
            {
                return null;
            }

            return source
                .Select(x => Convert(x));
        }
    }
}

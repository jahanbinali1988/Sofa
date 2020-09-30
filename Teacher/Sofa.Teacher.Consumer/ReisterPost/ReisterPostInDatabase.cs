using Sofa.Events.Post;
using Sofa.SharedKernel.BaseClasses;
using Sofa.SharedKernel.Enum;
using Sofa.Teacher.Model;
using Sofa.Teacher.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.ReisterPost
{
    public class ReisterPostInDatabase : IUnitOfBusiness<RegisterPostEvent, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReisterPostInDatabase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> Do(RegisterPostEvent message)
        {
            try
            {
                var post = _unitOfWork.postRepository.Query(c => c.Id == message.Id).SingleOrDefault();
                if (post != null)
                {
                    post.AssignModifiedDate(DateTime.Now);
                    post.AssignIsActive(message.IsActive);
                    post.AssignOrder(message.Order);
                    post.AssignPostType((ContentTypeEnum)message.PostType);
                    post.IncreaseRowVersion();
                    post.AssignTitle(message.Title);
                    post.AssignDescription(message.Description);
                    post.AssignCourse(message.LessonId);

                    _unitOfWork.postRepository.Update(post);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newPost = Post.CreateInstance(null, message.Title, message.Order, (ContentTypeEnum)message.PostType, message.Content, message.LessonId, message.Description, message.IsActive);
                
                await _unitOfWork.postRepository.AddAsync(newPost);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                _unitOfWork.Dispose();
                return false;
            }
        }
    }
}

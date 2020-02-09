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
                    post.ModifyDate = DateTime.Now;
                    post.IsActive = message.IsActive;
                    post.Order = message.Order;
                    post.PostType = (PostTypeEnum)message.PostType;
                    post.RowVersion = post.RowVersion + 1;
                    post.Title = message.Title;
                    post.Description = message.Description;
                    post.CourseId = message.LessonId;

                    _unitOfWork.postRepository.Update(post);
                    await _unitOfWork.CommitAsync();
                    return true;
                }

                var newPost = Post.DefaultFactory(message.Title, message.Order, (PostTypeEnum)message.PostType, message.LessonId);
                newPost.Description = message.Description;

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

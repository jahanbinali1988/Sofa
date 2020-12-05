using MassTransit;
using Sofa.Events.Post;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.PostConsumer.UpdatePostIsDeletedStatus
{
    public class UpdatePostIsDeletedStatusEventConsumer : IConsumer<UpdatePostIsDeletedStatusEvent>
    {
        private readonly UpdatePostIsDeletedStatusInDataBase _updatePostIsDeleted;
        private readonly ILogger _logger;

        public UpdatePostIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updatePostIsDeleted = new UpdatePostIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatePostIsDeletedStatusEvent> context)
        {
            try
            {
                await _updatePostIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "RegisteredUserRequestedConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

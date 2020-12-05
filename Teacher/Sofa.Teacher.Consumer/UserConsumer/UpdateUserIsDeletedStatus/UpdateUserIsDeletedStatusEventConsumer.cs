using MassTransit;
using Sofa.Events.User;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.UserConsumer.UpdateUserIsDeletedStatus
{
    public class UpdateUserIsDeletedStatusEventConsumer : IConsumer<UpdateUserIsDeletedStatusEvent>
    {
        private readonly UpdateUserIsDeletedStatusInDataBase _updateUserIsDeleted;
        private readonly ILogger _logger;

        public UpdateUserIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateUserIsDeleted = new UpdateUserIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateUserIsDeletedStatusEvent> context)
        {
            try
            {
                await _updateUserIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateUserIsDeletedStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

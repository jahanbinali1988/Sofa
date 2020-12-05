using MassTransit;
using Sofa.Events.User;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.UserConsumer.UpdateUserIsActiveStatus
{
    public class UpdateUserIsActiveStatusEventConsumer : IConsumer<UpdateUserIsActiveStatusEvent>
    {
        private readonly UpdateUserIsActiveStatusInDataBase _updateUserIsActive;
        private readonly ILogger _logger;

        public UpdateUserIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateUserIsActive = new UpdateUserIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateUserIsActiveStatusEvent> context)
        {
            try
            {
                await _updateUserIsActive.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateUserIsActiveStatusEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

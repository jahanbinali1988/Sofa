using MassTransit;
using Sofa.Events.Post;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.PostConsumer.UpdatePostIsActiveStatus
{
    public class UpdatePostIsActiveStatusEventConsumer : IConsumer<UpdatePostIsActiveStatusEvent>
    {
        private readonly UpdatePostIsActiveStatusInDataBase _registerUserInDatabase;
        private readonly ILogger _logger;

        public UpdatePostIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerUserInDatabase = new UpdatePostIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdatePostIsActiveStatusEvent> context)
        {
            try
            {
                await _registerUserInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdatePostIsActiveStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

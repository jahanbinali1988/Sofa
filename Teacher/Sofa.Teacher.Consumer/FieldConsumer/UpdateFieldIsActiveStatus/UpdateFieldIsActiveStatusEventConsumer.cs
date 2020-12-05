using MassTransit;
using Sofa.Events.Field;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.FieldConsumer.UpdateFieldIsActiveStatus
{
    public class UpdateFieldIsActiveStatusEventConsumer : IConsumer<UpdateFieldIsActiveStatusEvent>
    {
        private readonly UpdateFieldIsActiveStatusInDataBase _updateFieldIsActive;
        private readonly ILogger _logger;

        public UpdateFieldIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateFieldIsActive = new UpdateFieldIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateFieldIsActiveStatusEvent> context)
        {
            try
            {
                await _updateFieldIsActive.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateFieldIsActiveStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

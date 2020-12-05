using MassTransit;
using Sofa.Events.Field;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.FieldConsumer.UpdateFieldIsDeletedStatus
{
    public class UpdateFieldIsDeletedStatusEventConsumer : IConsumer<UpdateFieldIsDeletedStatusEvent>
    {
        private readonly UpdateFieldIsDeletedStatusInDataBase _updateFieldIsDeleted;
        private readonly ILogger _logger;

        public UpdateFieldIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateFieldIsDeleted = new UpdateFieldIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateFieldIsDeletedStatusEvent> context)
        {
            try
            {
                await _updateFieldIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateFieldIsDeletedStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

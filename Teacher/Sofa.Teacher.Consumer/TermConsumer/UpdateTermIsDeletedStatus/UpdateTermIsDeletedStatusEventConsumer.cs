using MassTransit;
using Sofa.Events.Term;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.TermConsumer.UpdateTermIsDeletedStatus
{
    public class UpdateTermIsDeletedStatusEventConsumer : IConsumer<UpdateTermIsDeletedStatusEvent>
    {
        private readonly UpdateTermIsDeletedStatusInDataBase _updateTermIsDeleted;
        private readonly ILogger _logger;

        public UpdateTermIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateTermIsDeleted = new UpdateTermIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateTermIsDeletedStatusEvent> context)
        {
            try
            {
                await _updateTermIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateTermIsDeletedStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

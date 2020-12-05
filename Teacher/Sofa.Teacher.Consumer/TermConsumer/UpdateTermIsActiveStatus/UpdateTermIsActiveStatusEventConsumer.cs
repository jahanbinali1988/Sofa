using MassTransit;
using Sofa.Events.Term;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.TermConsumer.UpdateTermIsActiveStatus
{
    public class UpdateTermIsActiveStatusEventConsumer : IConsumer<UpdateTermIsActiveStatusEvent>
    {
        private readonly UpdateTermIsActiveStatusInDataBase _updateTermIsActive;
        private readonly ILogger _logger;

        public UpdateTermIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateTermIsActive = new UpdateTermIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateTermIsActiveStatusEvent> context)
        {
            try
            {
                await _updateTermIsActive.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateTermIsActiveStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

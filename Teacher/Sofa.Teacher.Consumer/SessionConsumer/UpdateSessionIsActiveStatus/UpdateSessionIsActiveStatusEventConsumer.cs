using MassTransit;
using Sofa.Events.Session;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.SessionConsumer.UpdateSessionIsActiveStatus
{
    public class UpdateSessionIsActiveStatusEventConsumer : IConsumer<UpdateSessionIsActiveStatusEvent>
    {
        private readonly UpdateSessionIsActiveStatusInDataBase _updateSessionIsActive;
        private readonly ILogger _logger;

        public UpdateSessionIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateSessionIsActive = new UpdateSessionIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateSessionIsActiveStatusEvent> context)
        {
            try
            {
                await _updateSessionIsActive.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateSessionIsActiveStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

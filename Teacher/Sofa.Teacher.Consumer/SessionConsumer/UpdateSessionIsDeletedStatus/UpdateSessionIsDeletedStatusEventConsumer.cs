using MassTransit;
using Sofa.Events.Session;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.SessionConsumer.UpdateSessionIsDeletedStatus
{
    public class UpdateSessionIsDeletedStatusEventConsumer : IConsumer<UpdateSessionIsDeletedStatusEvent>
    {
        private readonly UpdateSessionIsDeletedStatusInDataBase _updateSessionIsDeleted;
        private readonly ILogger _logger;

        public UpdateSessionIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateSessionIsDeleted = new UpdateSessionIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateSessionIsDeletedStatusEvent> context)
        {
            try
            {
                await _updateSessionIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateSessionIsDeletedStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

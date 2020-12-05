using MassTransit;
using Sofa.Events.Institute;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.InstituteConsumer.UpdateInstituteIsActiveStatus
{
    public class UpdateInstituteIsActiveStatusEventConsumer : IConsumer<UpdateInstituteIsActiveStatusEvent>
    {
        private readonly UpdateInstituteIsActiveStatusInDataBase _updateInstituteIsActive;
        private readonly ILogger _logger;

        public UpdateInstituteIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateInstituteIsActive = new UpdateInstituteIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateInstituteIsActiveStatusEvent> context)
        {
            try
            {
                await _updateInstituteIsActive.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateInstituteIsActiveStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

using MassTransit;
using Sofa.Events.Institute;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.InstituteConsumer.UpdateInstituteIsDeletedStatus
{
    public class UpdateInstituteIsDeletedStatusEventConsumer : IConsumer<UpdateInstituteIsDeletedStatusEvent>
    {
        private readonly UpdateInstituteIsDeletedStatusInDataBase _updateInstituteIsDeleted;
        private readonly ILogger _logger;

        public UpdateInstituteIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateInstituteIsDeleted = new UpdateInstituteIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateInstituteIsDeletedStatusEvent> context)
        {
            try
            {
                await _updateInstituteIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateInstituteIsDeletedStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

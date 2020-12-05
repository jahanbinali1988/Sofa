using MassTransit;
using Sofa.Events.LessonPlan;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.LessonPlanConsumer.UpdateLessonPlanIsDeletedStatus
{
    public class UpdateLessonPlanIsDeletedStatusEventConsumer : IConsumer<UpdateLessonPlanIsDeletedStatusEvent>
    {
        private readonly UpdateLessonPlanIsDeletedStatusInDataBase _updateLessonPlanIsDeleted;
        private readonly ILogger _logger;

        public UpdateLessonPlanIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateLessonPlanIsDeleted = new UpdateLessonPlanIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateLessonPlanIsDeletedStatusEvent> context)
        {
            try
            {
                await _updateLessonPlanIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateLessonPlanIsDeletedStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

using MassTransit;
using Sofa.Events.LessonPlan;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.LessonPlanConsumer.UpdateLessonPlanIsActiveStatus
{
    public class UpdateLessonPlanIsActiveStatusEventConsumer : IConsumer<UpdateLessonPlanIsActiveStatusEvent>
    {
        private readonly UpdateLessonPlanIsActiveStatusInDataBase _updateLessonPlanIsActive;
        private readonly ILogger _logger;

        public UpdateLessonPlanIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateLessonPlanIsActive = new UpdateLessonPlanIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateLessonPlanIsActiveStatusEvent> context)
        {
            try
            {
                await _updateLessonPlanIsActive.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateLessonPlanIsActiveStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

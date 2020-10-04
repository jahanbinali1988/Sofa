using MassTransit;
using Sofa.Events.LessonPlan;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterLessonPlan
{
    public class RegisterLessonPlanEventConsumer : IConsumer<RegisterLessonPlanEvent>
    {
        private readonly RegisterLessonPlanInDatabase _registerLessonPlanInDatabase;
        private readonly ILogger _logger;

        public RegisterLessonPlanEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerLessonPlanInDatabase = new RegisterLessonPlanInDatabase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterLessonPlanEvent> context)
        {
            try
            {
                await _registerLessonPlanInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "RegisterLessonPlanEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

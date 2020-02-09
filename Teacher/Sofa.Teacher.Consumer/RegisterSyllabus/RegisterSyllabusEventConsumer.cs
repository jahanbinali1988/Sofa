using MassTransit;
using Sofa.Events.LessonPlan;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterSyllabus
{
    public class RegisterSyllabusEventConsumer : IConsumer<RegisterLessonPlanEvent>
    {
        private readonly RegisterSyllabusInDatabase _registerSyllabusInDatabase;
        private readonly ILogger _logger;

        public RegisterSyllabusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerSyllabusInDatabase = new RegisterSyllabusInDatabase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterLessonPlanEvent> context)
        {
            try
            {
                await _registerSyllabusInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "RegisterSyllabusEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

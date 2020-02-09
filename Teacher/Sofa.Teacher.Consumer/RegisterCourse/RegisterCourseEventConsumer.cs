using MassTransit;
using Sofa.Events.Lesson;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterCourse
{
    public class RegisterCourseEventConsumer : IConsumer<RegisterLessonEvent>
    {
        private readonly RegisterCourseInDatabase _registerCourseInDatabase;
        private readonly ILogger _logger;
        public RegisterCourseEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerCourseInDatabase = new RegisterCourseInDatabase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterLessonEvent> context)
        {
            try
            {
                await _registerCourseInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "RegisterCourseEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

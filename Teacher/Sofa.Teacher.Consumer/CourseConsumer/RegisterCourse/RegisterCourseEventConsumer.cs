using MassTransit;
using Sofa.Events.Course;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.CourseConsumer.RegisterCourse
{
    public class RegisterCourseEventConsumer : IConsumer<RegisterCourseEvent>
    {
        private readonly RegisterCourseInDataBase _registerCourseInDatabase;
        private readonly ILogger _logger;

        public RegisterCourseEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerCourseInDatabase = new RegisterCourseInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterCourseEvent> context)
        {
            try
            {
                await _registerCourseInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "ReisterCourseEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

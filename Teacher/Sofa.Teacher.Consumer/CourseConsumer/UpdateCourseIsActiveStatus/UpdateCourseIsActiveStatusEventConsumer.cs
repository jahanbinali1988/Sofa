using MassTransit;
using Sofa.Events.Course;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.CourseConsumer.UpdateCourseIsActiveStatus
{ 
    public class UpdateCourseIsActiveStatusEventConsumer : IConsumer<UpdateCourseIsActiveStatusEvent>
    {
        private readonly UpdateCourseIsActiveStatusInDataBase _updateCourseIsActiveStatus;
        private readonly ILogger _logger;

        public UpdateCourseIsActiveStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateCourseIsActiveStatus = new UpdateCourseIsActiveStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateCourseIsActiveStatusEvent> context)
        {
            try
            {
                await _updateCourseIsActiveStatus.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateCourseIsActiveStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

using MassTransit;
using Sofa.Events.Course;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.CourseConsumer.UpdateCourseIsDeletedStatus
{
    public class UpdateCourseIsDeletedStatusEventConsumer : IConsumer<UpdateCourseIsDeletedStatusEvent>
    {
        private readonly UpdateCourseIsDeletedStatusInDataBase _updateCourseIsDeleted;
        private readonly ILogger _logger;

        public UpdateCourseIsDeletedStatusEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _updateCourseIsDeleted = new UpdateCourseIsDeletedStatusInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<UpdateCourseIsDeletedStatusEvent> context)
        {
            try
            {
                await _updateCourseIsDeleted.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "UpdateCourseIsDeletedStatusEventConsumer");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

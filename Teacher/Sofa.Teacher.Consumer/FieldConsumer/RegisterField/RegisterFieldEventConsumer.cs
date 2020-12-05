using MassTransit;
using Sofa.Events.Field;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.FieldConsumer.RegisterField
{
    public class RegisterFieldEventConsumer : IConsumer<RegisterFieldEvent>
    {
        private readonly RegisterFieldInDataBase _registerFieldInDatabase;
        private readonly ILogger _logger;

        public RegisterFieldEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerFieldInDatabase = new RegisterFieldInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterFieldEvent> context)
        {
            try
            {
                await _registerFieldInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "ReisterFieldEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

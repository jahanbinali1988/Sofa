using MassTransit;
using Sofa.Events.Session;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.SessionConsumer.RegisterSession
{
public class RegisterSessionEventConsumer : IConsumer<RegisterSessionEvent>
    {
        private readonly RegisterSessionInDataBase _registerSessionInDatabase;
        private readonly ILogger _logger;

        public RegisterSessionEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerSessionInDatabase = new RegisterSessionInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterSessionEvent> context)
        {
            try
            {
                await _registerSessionInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "ReisterSessionEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

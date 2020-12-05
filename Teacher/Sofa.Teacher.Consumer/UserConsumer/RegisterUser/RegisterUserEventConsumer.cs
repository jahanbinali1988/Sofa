using MassTransit;
using Sofa.Events.User;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.UserConsumer.RegisterUser
{
    public class RegisterUserEventConsumer : IConsumer<RegisteredUserEvent>
    {
        private readonly RegisterUserInDatabase _registerUserInDatabase;
        private readonly ILogger _logger;

        public RegisterUserEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerUserInDatabase = new RegisterUserInDatabase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisteredUserEvent> context)
        {
            try
            {
                await _registerUserInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "RegisteredUserRequestedConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

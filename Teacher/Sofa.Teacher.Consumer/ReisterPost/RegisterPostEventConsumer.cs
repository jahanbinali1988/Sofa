using MassTransit;
using Sofa.Events.Post;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.ReisterPost
{
    public class RegisterPostEventConsumer : IConsumer<RegisterPostEvent>
    {
        private readonly RegisterPostInDatabase _registerPostInDatabase;
        private readonly ILogger _logger;

        public RegisterPostEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerPostInDatabase = new RegisterPostInDatabase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterPostEvent> context)
        {
            try
            {
                await _registerPostInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "ReisterPostEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

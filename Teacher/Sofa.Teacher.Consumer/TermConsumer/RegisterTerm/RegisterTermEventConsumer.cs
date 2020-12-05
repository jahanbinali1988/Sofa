using MassTransit;
using Sofa.Events.Term;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.TermConsumer.RegisterTerm
{
    public class RegisterTermEventConsumer : IConsumer<RegisterTermEvent>
    {
        private readonly RegisterTermInDataBase _registerTermInDatabase;
        private readonly ILogger _logger;

        public RegisterTermEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerTermInDatabase = new RegisterTermInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterTermEvent> context)
        {
            try
            {
                await _registerTermInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "ReisterTermEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

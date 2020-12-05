using MassTransit;
using Sofa.Events.Institute;
using Sofa.SharedKernel;
using Sofa.Teacher.Repository;
using System;
using System.Threading.Tasks;

namespace Sofa.Teacher.Consumer.RegisterInstitute
{
    public class RegisterInstituteEventConsumer : IConsumer<RegisterInstituteEvent>
    {
        private readonly RegisterInstituteInDataBase _registerInstituteInDatabase;
        private readonly ILogger _logger;

        public RegisterInstituteEventConsumer(IUnitOfWork unitOfWork, ILogger logger)
        {
            _registerInstituteInDatabase = new RegisterInstituteInDataBase(unitOfWork);
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<RegisterInstituteEvent> context)
        {
            try
            {
                await _registerInstituteInDatabase.Do(context.Message);
            }
            catch (Exception exception)
            {
                _logger.Exception(exception, "ReisterInstituteEventConsumer.Consume");
                _logger.Information("{@a}", context.Message);
                throw exception;
            }
        }
    }
}

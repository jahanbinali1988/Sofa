using MassTransit;

namespace Sofa.SharedKernel.BaseClasses.Bus
{
    public interface IConsumerBase<T> : IConsumer where T : class
    {
        void Consume(ConsumeContext<T> context);
    }
}

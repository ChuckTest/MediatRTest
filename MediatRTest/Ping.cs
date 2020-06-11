using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Autofac;

namespace MediatRTest
{
    //public interface IRequest<out TResponse> : IBaseRequest
    public class Ping : IRequest<string> 
    {
    }

    //public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    public class PingHandler : IRequestHandler<Ping, string>
    {
        Task<string> IRequestHandler<Ping, string>.Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }

    public class PingTest
    {
        public static async void Test()
        {
            //https://github.com/jbogard/MediatR/blob/master/test/MediatR.Tests/SendTests.cs#L47
            //similar to official code which use StructureMap https://structuremap.github.io/
            var mediator = InitHelper.Instance.Container.Resolve<IMediator>();
            var response = await mediator.Send(new Ping());
            Console.WriteLine(response); // "Pong"
        }
    }
}

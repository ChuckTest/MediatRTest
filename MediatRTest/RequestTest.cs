using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Autofac;

namespace MediatRTest
{
    /// <summary>
    /// 1.create a message
    /// </summary>
    //public interface IRequest<out TResponse> : IBaseRequest
    public class PingRequest : IRequest<string>
    {
        public string Name { get; set; }
    }

    /// <summary>
    /// 2.create a handler
    /// </summary>
    //public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    public class PingHandler : IRequestHandler<PingRequest, string>
    {
        Task<string> IRequestHandler<PingRequest, string>.Handle(PingRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Pong");
        }
    }

    public class RequestTest
    {
        public static async Task Test()
        {
            //https://github.com/jbogard/MediatR/blob/master/test/MediatR.Tests/SendTests.cs#L47
            //similar to official code which use StructureMap https://structuremap.github.io/
            var mediator = InitHelper.Instance.Container.Resolve<IMediator>();
            //3.Finally, send a message through the mediator
            var response = await mediator.Send(new PingRequest()
            {
                Name = "Chuck"
            });
            Console.WriteLine(response); // "Pong"
        }
    }
}

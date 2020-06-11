using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using MediatR;

namespace MediatRTest
{
    class PingNotification : INotification
    {

    }

    class PingNotificationHandler1 : INotificationHandler<PingNotification>
    {
        Task INotificationHandler<PingNotification>.Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pong 1");
            return Task.CompletedTask;
        }
    }

    class PingNotificationHandler2 : INotificationHandler<PingNotification>
    {
        Task INotificationHandler<PingNotification>.Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pong 2"); 
            return Task.CompletedTask;
        }
    }

    class NotificationTest
    {
        public static async Task Test()
        {
            var mediator = InitHelper.Instance.Container.Resolve<IMediator>();
            await mediator.Publish(new PingNotification());
        }
    }
}

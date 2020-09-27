using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using MediatR;

namespace MediatRTest
{
    /// <summary>
    /// 1.first create your notification message:
    /// </summary>
    class PingNotification : INotification
    {

    }

    /// <summary>
    /// 2.create zero or more handlers for your notification
    /// </summary>
    class PingNotificationHandler1 : INotificationHandler<PingNotification>
    {
        Task INotificationHandler<PingNotification>.Handle(PingNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine("Pong 1");
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// 2.create zero or more handlers for your notification
    /// </summary>
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
            //3.Finally, publish your message via the mediator:
            await mediator.Publish(new PingNotification());
        }
    }
}

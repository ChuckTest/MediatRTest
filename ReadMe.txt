https://github.com/jbogard/MediatR/wiki
https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.Autofac/Program.cs
You will need to configure two dependencies: 
first, the mediator itself. 
The other dependency is the factory delegate, ServiceFactory.

Finally, you'll need to register your handlers in your container of choice.


MediatR has two kinds of messages it dispatches:

    1.Request/response messages, dispatched to a single handler
    2.Notification messages, dispatched to multiple handlers


There are two flavors of requests in MediatR - ones that return a value, and ones that do not:

    1.IRequest<T> - the request returns a value
    2.IRequest - the request does not return a value

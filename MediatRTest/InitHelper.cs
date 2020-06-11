using System.Reflection;
using Autofac;
using MediatR;

namespace MediatRTest
{
    public class InitHelper
    {
        private InitHelper()
        {

        }

        public static InitHelper Instance { get; set; } = new InitHelper();

        public IContainer Container { get; private set; }

        public void SetupAutofac()
        {
            var builder = new ContainerBuilder();

            // Uncomment to enable polymorphic dispatching of requests, but note that
            // this will conflict with generic pipeline behaviors
            // builder.RegisterSource(new ContravariantRegistrationSource());

            // Mediator itself
            builder
                .RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            // finally register our custom code (individually, or via assembly scanning)
            // - requests & handlers as transient, i.e. InstancePerDependency()
            // - pre/post-processors as scoped/per-request, i.e. InstancePerLifetimeScope()
            // - behaviors as transient, i.e. InstancePerDependency()
            builder.RegisterAssemblyTypes(typeof(MyType).GetTypeInfo().Assembly).AsImplementedInterfaces(); // via assembly scan
            //builder.RegisterType<MyHandler>().AsImplementedInterfaces().InstancePerDependency();          // or individually
            
            Container = builder.Build();

        }

    }
}

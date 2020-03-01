using Autofac;
using Scanner.Client.BusinessLogic.Services;

namespace Scanner.Client.BusinessLogic.Infrastructures.Modules {
    public class ServiceModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerLifetimeScope();
        }
    }
}

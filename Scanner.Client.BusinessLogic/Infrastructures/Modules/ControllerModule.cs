using Autofac;
using Scanner.Client.BusinessLogic.Controllers;

namespace Scanner.Client.BusinessLogic.Infrastructures.Modules {
    public class ControllerModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<LoginController>()
                .InstancePerLifetimeScope();
        }
    }
}

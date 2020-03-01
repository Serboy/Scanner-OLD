using Autofac;
using Scanner.Client.BusinessLogic.Logics;

namespace Scanner.Client.BusinessLogic.Infrastructures.Modules {
    public class LogicModule : Module {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<UserLogic>()
                .As<IUserLogic>()
                .InstancePerLifetimeScope();
        }
    }
}

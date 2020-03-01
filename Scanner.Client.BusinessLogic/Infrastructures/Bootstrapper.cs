using Autofac;
using Scanner.Client.BusinessLogic.Infrastructures.Modules;
using System;

namespace Scanner.Client.BusinessLogic.Infrastructures {
    public class Bootstrapper {
        private static readonly Lazy<Bootstrapper> Instance = new Lazy<Bootstrapper>(() => new Bootstrapper());

        public Bootstrapper() {
            Builder = new ContainerBuilder();
            Register();
        }

        public ContainerBuilder Builder { get; }
        public IContainer Container { get; private set; }
        public static Bootstrapper Current => Instance.Value;

        public void Build() { 
            Container = Builder.Build(); 
        }

        protected void Register() {
            Builder.RegisterModule(new ServiceModule());
            Builder.RegisterModule(new LogicModule());
        }
    }
}

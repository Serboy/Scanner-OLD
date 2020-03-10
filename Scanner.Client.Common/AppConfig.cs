using System;
using System.Linq;
using System.Reflection;

namespace Scanner.Client.Common {
    public static class AppConfig {
        public static Assembly GetAssembly(string name) {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            return assemblies.FirstOrDefault(s => s.GetName()
                .Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}

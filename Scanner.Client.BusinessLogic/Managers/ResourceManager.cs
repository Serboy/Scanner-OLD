using Scanner.Client.Common;
using Scanner.Client.Common.Attributes;
using Scanner.Client.Model.Domains;
using System;
using System.IO;
using System.Linq;

namespace Scanner.Client.BusinessLogic.Managers {
    public class ResourceManager {
        private static readonly Lazy<ResourceManager> Instance = new Lazy<ResourceManager>(() => new ResourceManager());

        public static ResourceManager Current => Instance.Value;
        
        public ImageResource ImageResource { get; private set; }

        public void Initialize() {
            ReadImageResource();
        }

        #region ᶳ Private Methods ᶳ
        private void ReadImageResource() {
            var assembly = AppConfig.GetAssembly("Scanner.Client");
            var dir = $"{assembly.GetName().Name}.Resources.Images";
            var files = assembly.GetManifestResourceNames()
                .Where(s => s.StartsWith(dir))
                .ToList();

            typeof(ImageResource)
                .GetProperties()
                .ToList()
                .ForEach(s => {
                    var attr = s.GetCustomAttributes(typeof(ResourceManagerAttribute), false);

                    var a = s.Name;
                });
        }
        #endregion
    }
}

using Newtonsoft.Json.Linq;
using Scanner.Client.Common;
using Scanner.Client.Model.Domains;
using System;
using System.IO;
using System.Linq;

namespace Scanner.Client.BusinessLogic.Managers {
    public class AppSettingManager {
        private static readonly Lazy<AppSettingManager> Instance = new Lazy<AppSettingManager>(() => new AppSettingManager());

        public AppSettingManager() {
        }

        public static AppSettingManager Current => Instance.Value;
        public AppSetting Setting { get; set; }

        public void Initialize() {
            ReadAppSetting();
        }

        public void ReadAppSetting() {
            var assembly = AppConfig.GetAssembly("Scanner.Client");
            var stream = assembly.GetManifestResourceStream("Scanner.Client.Configurations.appsettings.json");

            using (var reader = new StreamReader(stream)) {
                Setting = JObject.Parse(reader.ReadToEnd()).ToObject<AppSetting>();
            }
        }
    }
}

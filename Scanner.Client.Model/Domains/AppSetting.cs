namespace Scanner.Client.Model.Domains {
    public sealed class AppSetting {
        public string BaseService { get; set; }
        public AppUserSetting UserService { get; set; }
        public AppResourceSetting Resource { get; set; }
    }

    public class AppUserSetting {
        public string Url { get; set; }
        public string SignIn { get; set; }
        public string UserPrefix { get; set; }
    }

    public class AppResourceSetting {
        public ImageResource Image { get; set; }
    }
}

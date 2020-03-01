namespace Scanner.Client.Model.Domains {
    public sealed class AppSetting {
        public string BaseService { get; set; }
        public AppUserSetting UserService { get; set; }
    }

    public class AppUserSetting {
        public string Url { get; set; }
        public string SignIn { get; set; }
    }
}

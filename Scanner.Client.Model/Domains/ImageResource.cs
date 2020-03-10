using Scanner.Client.Common.Attributes;

namespace Scanner.Client.Model.Domains {
    public class ImageResource {
        [ResourceManager(Name = "main-logo.png")]
        public string MainLogo { get; set; }

        [ResourceManager(Name = "user-icon.png")]
        public string UserIcon { get; set; }
    }
}

using System;

namespace Scanner.API.Common {
    public static class AppConfig {
        public static string BaseDirectory {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }

        public static string GetPath(string path) {
            return string.Format("{0}{1}", BaseDirectory, path);
        }
    }
}

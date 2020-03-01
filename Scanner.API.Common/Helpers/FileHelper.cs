using System;
using System.IO;
using System.Threading.Tasks;

namespace Scanner.API.Common.Helpers {
    public static class FileHelper {
        public static async Task<string> ReadFileAsync(string path) {
            try {
                if (string.IsNullOrEmpty(path))
                    throw new ArgumentNullException(path);

                using var reader = new StreamReader(path);

                return await reader.ReadToEndAsync();
            } catch {
                return null;
            }
        }
    }
}

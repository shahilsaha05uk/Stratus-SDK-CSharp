using System.Text;

namespace StratusSDK
{
    public static class FileReader
    {
        public static string Read(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");
            return File.ReadAllText(filePath);
        }
        public static string ReadByStream(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");
            using var stream = ReadToStream(filePath);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
        public static StreamContent ReadToStreamContent(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");
            var stream = ReadToStream(filePath);
            return new StreamContent(stream);
        }
        public static Stream ReadToStream(string filePath)
            => new FileStream(
                filePath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                4096,
                true);
    }
}
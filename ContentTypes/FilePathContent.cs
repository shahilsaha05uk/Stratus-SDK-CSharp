using System.Net.Http.Headers;

namespace StratusSDK
{
    public sealed class FilePathContent : IStratusHttpContent
    {
        private readonly string path;
        private readonly string contentType;

        public FilePathContent(string path, EContentType contentType)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"File not found: {path}");

            this.path = path;
            this.contentType = contentType.ToMimeString();
        }

        public HttpContent ToContent()
        {
            var stream = new FileStream(
                path, FileMode.Open, FileAccess.Read, FileShare.Read,
                bufferSize: 81920, useAsync: true);

            var content = new StreamContent(stream);

            if (!string.IsNullOrWhiteSpace(contentType))
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return content;
        }
    }
}
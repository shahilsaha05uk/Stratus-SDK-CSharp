using System.Net.Http.Headers;

namespace StratusSDK
{
    public sealed class StreamUploadContent : IStratusHttpContent
    {
        private readonly Stream stream;
        private readonly string? contentType;

        public StreamUploadContent(
            Stream stream, 
            EContentType? contentType = null, 
            bool leaveOpen = false)
        {
            this.stream = stream;
            this.contentType = contentType?.ToMimeString();
        }

        public HttpContent ToContent()
        {
            var content = new StreamContent(stream);

            if (!string.IsNullOrWhiteSpace(contentType))
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return content;
        }
    }
}
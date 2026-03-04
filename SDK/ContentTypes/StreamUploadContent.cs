using System.Net.Http.Headers;

namespace StratusSDK
{
    public sealed class StreamUploadContent : IStratusHttpContent
    {
        private readonly string? contentType;
        private readonly Func<Stream> streamFactory;
        public StreamUploadContent(
            Func<Stream> streamFactory, 
            EContentType? contentType = null)
        {
            this.streamFactory = streamFactory
            ?? throw new ArgumentNullException(nameof(streamFactory));
            this.contentType = contentType?.ToMimeString();
        }

        public HttpContent ToContent()
        {
            var stream = streamFactory() 
                ?? throw new InvalidOperationException("Stream factory returned null.");
            var content = new StreamContent(stream);

            if (!string.IsNullOrWhiteSpace(contentType))
                content.Headers.ContentType = new MediaTypeHeaderValue(contentType);

            return content;
        }
    }
}
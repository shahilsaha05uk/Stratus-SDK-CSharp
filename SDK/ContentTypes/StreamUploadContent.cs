using System.Net.Http.Headers;
using StratusSDK;
using StratusSDK.Core.Constants;
using StratusSDK.Core.Enums;
using StratusSDK.Core.Interfaces;

namespace StratusSDK.ContentTypes
{
    public sealed class StreamUploadContent : IStratusHttpContent
    {
        readonly string? contentType;
        readonly Func<Stream> streamFactory;
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
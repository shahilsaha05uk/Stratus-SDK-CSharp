using System.Net.Http.Headers;

namespace StratusSDK
{
    public sealed class BytesContent : IStratusHttpContent
    {
        readonly byte[] data;
        readonly string contentType;

        public BytesContent(byte[] data, EContentType contentType)
        {
            this.data = data ??
                throw new ArgumentNullException(nameof(data));

            this.contentType = contentType.ToMimeString();
        }

        public HttpContent ToContent()
        {
            var content = new ByteArrayContent(data);
            content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return content;
        }
    }
}
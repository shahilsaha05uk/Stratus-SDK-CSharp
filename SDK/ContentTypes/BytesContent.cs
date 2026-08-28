using System.Net.Http.Headers;
using StratusSDK;
using StratusSDK.Core.Constants;
using StratusSDK.Core.Enums;
using StratusSDK.Core.Interfaces;

namespace StratusSDK.ContentTypes
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
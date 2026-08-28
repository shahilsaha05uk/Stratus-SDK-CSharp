using System.Text;
using StratusSDK;
using StratusSDK.ContentTypes;
using StratusSDK.Core.Enums;
using StratusSDK.Core.Interfaces;

namespace StratusSDK.Api.Object.UploadObject.Models
{
    public static class UploadContent
    {
        public static IStratusHttpContent FromFile(
            string path,
            EContentType contentType = EContentType.ApplicationOctetStream)
            => new FilePathContent(path, contentType);

        public static IStratusHttpContent FromStream(
            Func<Stream> streamFactory,
            EContentType contentType = EContentType.ApplicationOctetStream)
            => new StreamUploadContent(streamFactory, contentType);

        public static IStratusHttpContent FromBytes(
            byte[] bytes,
            EContentType contentType = EContentType.ApplicationOctetStream)
            => new BytesContent(bytes, contentType);

        public static IStratusHttpContent FromString(
            string content,
            EContentType contentType = EContentType.TextPlain)
            => new BytesContent(
                Encoding.UTF8.GetBytes(content),
                contentType);
    }
}

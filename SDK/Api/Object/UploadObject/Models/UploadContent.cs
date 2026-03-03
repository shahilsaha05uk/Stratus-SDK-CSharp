using System.Text;

namespace StratusSDK
{
    public static class UploadContent
    {
        public static IStratusHttpContent FromFile(
            string path,
            EContentType contentType = EContentType.ApplicationOctetStream)
            => new FilePathContent(path, contentType);

        public static IStratusHttpContent FromStream(
            Stream stream,
            EContentType contentType = EContentType.ApplicationOctetStream)
            => new StreamUploadContent(stream, contentType);

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

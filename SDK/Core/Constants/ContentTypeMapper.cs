namespace StratusSDK
{
    public static class ContentTypeMapper
    {
        public static string ToMimeString(this EContentType contentType) =>
            contentType switch
            {
                EContentType.ApplicationJson => "application/json",
                EContentType.TextPlain => "text/plain",
                EContentType.TextCsv => "text/csv",
                EContentType.ApplicationXml => "application/xml",
                EContentType.ApplicationOctetStream => "application/octet-stream",
                EContentType.ApplicationPdf => "application/pdf",
                EContentType.ApplicationZip => "application/zip",
                EContentType.ApplicationFormUrlEncoded => "application/x-www-form-urlencoded",
                EContentType.MultipartFormData => "multipart/form-data",

                EContentType.ImagePng => "image/png",
                EContentType.ImageJpeg => "image/jpeg",
                EContentType.ImageGif => "image/gif",
                EContentType.ImageWebp => "image/webp",

                EContentType.VideoMp4 => "video/mp4",
                EContentType.AudioMpeg => "audio/mpeg",

                EContentType.ApplicationJavascript => "application/javascript",
                EContentType.ApplicationDocx =>
                    "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                EContentType.ApplicationXlsx =>
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",

                _ => throw new ArgumentOutOfRangeException(nameof(contentType))
            };
    }
}
namespace StratusSDK
{
    /// <summary>
    /// Specifies the type of presigned URL to generate.
    /// </summary>
    public enum EPresignedType
    {
        /// <summary>
        /// Presigned URL for uploading objects to the bucket.
        /// </summary>
        Upload,

        /// <summary>
        /// Presigned URL for downloading objects from the bucket.
        /// </summary>
        Download
    }
}

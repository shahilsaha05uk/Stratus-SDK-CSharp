using System.Net.Mime;

namespace StratusSDK
{
    public interface IStratusHttpContent
    {
        HttpContent ToContent();
    }
}
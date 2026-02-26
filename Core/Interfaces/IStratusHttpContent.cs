using System.Net.Mime;

namespace StratusSDK.Core.Interfaces
{
    public interface IStratusHttpContent
    {
        HttpContent ToContent();
    }
}
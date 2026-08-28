using System.Net.Mime;
using StratusSDK;

namespace StratusSDK.Core.Interfaces
{
    public interface IStratusHttpContent
    {
        HttpContent ToContent();
    }
}
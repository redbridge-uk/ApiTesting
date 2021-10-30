using System.Net;

namespace Redbridge.ApiTesting.Framework.Results
{
    public interface IWebResult
    {
        HttpStatusCode Status { get; }
    }
}
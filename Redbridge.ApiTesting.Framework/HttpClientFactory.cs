using System.Net.Http;
using Redbridge.Web.Messaging;

namespace Redbridge.ApiTesting.Framework
{
    public class HttpClientFactory : IHttpClientFactory
    {
        public HttpClient Create()
        {
            return new HttpClient();
        }
    }
}
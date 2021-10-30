using Redbridge.ApiTesting.Framework.Extensions;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public interface ISessionNamable
    {
        string SessionName { get; set; }
    }
}
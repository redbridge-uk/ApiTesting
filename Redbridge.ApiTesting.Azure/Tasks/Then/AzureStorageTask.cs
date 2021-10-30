using Redbridge.ApiTesting.Framework;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Azure.Tasks.Then
{
    public abstract class AzureStorageTask<TUserSession> : ThenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
    }
}

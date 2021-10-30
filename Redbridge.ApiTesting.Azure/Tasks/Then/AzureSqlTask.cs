using Redbridge.ApiTesting.Framework;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Azure.Tasks.Then
{
    public abstract class AzureSqlTask<TUserSession> : ThenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        protected AzureSqlTask()
        {
        }

        public string ConnectionString { get; set; }
    }
}
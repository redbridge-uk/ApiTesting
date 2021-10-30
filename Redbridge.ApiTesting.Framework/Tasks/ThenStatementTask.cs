using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public abstract class ThenStatementTask<TUserSession> : ScenarioTask<TUserSession>, IThenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession>
    {
        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context.Result == null)
            {
                throw new UnexpectedTestScenarioResultException("No result has been supplied.");
            }

            return Task.CompletedTask;
        }
    }
}
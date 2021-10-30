using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks.Thens
{
    public class SessionAuthenticatedAssertion<TUserSession> : ThenStatementTask<TUserSession>
        where TUserSession: IUserSession<TUserSession>
    {
        public override string TaskName => "Current session is authenticated";
        public override string TaskDescription => "Asserts that the current user session is authenticated.";
        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            await base.OnExecuteAsync(context);
            if (!context.ActiveSession.IsConnected)
            {
                throw new UnexpectedTestScenarioResultException($"Expected session {context.ActiveSession.Name} to be connected.");
            }
        }
    }
}

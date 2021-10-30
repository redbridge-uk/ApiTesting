using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks.Givens
{
    public class SetAdministratorCurrentContextGivenTask<TUserSession> : GivenScenarioTask<TUserSession> 
        where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "An administrator account";
        public override string TaskDescription => "Sets the current working context to an administrator user account";

        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            context.ActiveSession = context.Scenario.Administrator;
            return Task.CompletedTask;
        }
    }
}

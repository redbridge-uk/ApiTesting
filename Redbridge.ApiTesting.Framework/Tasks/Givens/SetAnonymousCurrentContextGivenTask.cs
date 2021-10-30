using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks.Givens
{
    public class SetAnonymousCurrentContextGivenTask<TUserSession> : GivenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "An anonymous user";
        public override string TaskDescription => "Sets the current working context to the anonymous session";

        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            context.ActiveSession = context.Scenario.Anonymous;
            return Task.CompletedTask;
        }
    }
}
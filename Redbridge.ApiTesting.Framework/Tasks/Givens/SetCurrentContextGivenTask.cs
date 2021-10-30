using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Framework.Tasks.Givens
{
    public class SetCurrentContextGivenTask<TUserSession> : GivenScenarioTask<TUserSession>, ISessionNamable, IThenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => $"A specified session called {SessionName}";
        public override string TaskDescription => "Sets the current working context to a specified session";
        public string SessionName { get; set; }

        public SetCurrentContextGivenTask() { }

        public SetCurrentContextGivenTask(string name)
        {
            SessionName = name;
        }

        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            context.ActiveSession = context.Scenario.Sessions[SessionName];
            return Task.CompletedTask;
        }
    }
}
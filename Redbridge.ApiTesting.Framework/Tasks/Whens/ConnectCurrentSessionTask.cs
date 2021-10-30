using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Exceptions;
using Redbridge.ApiTesting.Framework.Results;
using Redbridge.ApiTesting.Framework.Tasks.Givens;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Framework.Tasks.Whens
{
    public class ConnectCurrentSessionTask<TUserSession> : WhenScenarioTask<TUserSession>, IGivenScenarioTask<TUserSession> 
        where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "Connect current session";
        public override string TaskDescription => "Connects the current context session";
        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if ( context.ActiveSession == null ) throw new TestScenarioException($"Unable to connect the current session {context.StepNumber} as no active session is set. Please use a set session tasks or similar.");
            await context.ActiveSession.ConnectAsync();
            context.SetResult(new BooleanTestResult(context.ActiveSession.IsConnected));
        }
    }
    public class RenewCurrentSessionTokenTask<TUserSession> : ThenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "Connect current session";
        public override string TaskDescription => "Connects the current context session";
        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context.ActiveSession == null) throw new TestScenarioException($"Unable to connect the current session {context.StepNumber} as no active session is set. Please use a set session tasks or similar.");
            await context.ActiveSession.ConnectAsync();
            context.SetResult(new BooleanTestResult(context.ActiveSession.IsConnected));
        }
    }
    public class LogOffCurrentSessionTask<TUserSession> : WhenScenarioTask<TUserSession>, IGivenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "Disconnect current session";
        public override string TaskDescription => "Disconnects the current context session";
        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context.ActiveSession == null) throw new TestScenarioException($"Unable to disconnect the current session {context.StepNumber} as no active session is set. Please use a set session tasks or similar.");
            await context.ActiveSession.DisconnectAsync();
        }
    }
}

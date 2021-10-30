using System;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Exceptions;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks.Whens
{
    public abstract class WebProxyActionWhenScenarioTask<T, TUserSession> : WebProxyWhenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        private readonly Func<T, TUserSession, Task> _func;

        protected WebProxyActionWhenScenarioTask(Func<T, TUserSession, Task> func)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            var session = GetActingSession(context);
            if (!session.IsConnected)
            {
                context.Scenario.WriteLog($"Connecting acting session {session.Name} to act on behalf of this action.");
                await session.ConnectAsync();
            }

            var argument = CreateArgument(context);
            await _func(argument, session);

            if (CaptureResult)
            {
                context.SetResult(new SuccessTestResult());
            }
        }

        protected virtual TUserSession GetActingSession(ScenarioContext<TUserSession> context)
        {
            var session = context.ActiveSession;
            if ( session == null ) throw new TestScenarioException("No active session has been defined.");
            return session;
        }

        protected abstract T CreateArgument(ScenarioContext<TUserSession> context);
    }
}
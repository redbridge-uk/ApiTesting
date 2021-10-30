using System;
using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks.Thens
{
    public abstract class WebProxyFuncThenScenarioTask<TIn1, TResult, TUserSession> : WebProxyThenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession> where TResult : class
    {
        private readonly Func<TIn1, TUserSession, Task<TResult>> _func;

        protected WebProxyFuncThenScenarioTask(Func<TIn1, TUserSession, Task<TResult>> func)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            var session = context.ActiveSession;
            var argument = CreateArgument(context);
            var result = await _func(argument, session);
        }

        protected abstract TIn1 CreateArgument(ScenarioContext<TUserSession> context);
    }
}
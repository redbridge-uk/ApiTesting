using System;
using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks.Whens
{
    public abstract class WebProxyFuncWhenScenarioTask<T, TK, TUserSession> : WebProxyWhenScenarioTask<TUserSession> 
        where TUserSession : IUserSession<TUserSession>
    {
        private readonly Func<T, TUserSession, Task<TK>> _func;
        private TK _lastResult;

        protected WebProxyFuncWhenScenarioTask(Func<T, TUserSession, Task<TK>> func)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            var session = context.ActiveSession;
            var argument = CreateArgument(context);
            _lastResult = await _func(argument, session);
        }

        public TK LastResult => _lastResult;

        protected abstract T CreateArgument(ScenarioContext<TUserSession> context);
    }
}
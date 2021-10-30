using System;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Extensions;

namespace Redbridge.ApiTesting.Framework.Tasks.Givens
{
    public abstract class WebProxyFuncGivenScenarioTask<TIn1, TResult, TUserSession> : WebProxyGivenScenarioTask<TUserSession> 
        where TUserSession : IUserSession<TUserSession> where TResult : class
    {
        private readonly Func<TIn1, TUserSession, Task<TResult>> _func;

        protected WebProxyFuncGivenScenarioTask(Func<TIn1, TUserSession, Task<TResult>> func)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        protected override async Task OnExecuteAsync (ScenarioContext<TUserSession> context)
        {
            var session = context.ActiveSession;
            var argument = CreateArgument(context);
            var result = await _func(argument, session);
            // Hold on, this should only really be done in the 'When' scenarios?
            OnProcessResult(context, result);
            context.SetResult(new SingleScenarioTestResult<TResult>(result));
        }

        protected virtual void OnProcessResult(ScenarioContext<TUserSession> context, TResult result) {
        }

        protected abstract TIn1 CreateArgument(ScenarioContext<TUserSession> context);
    }

    public abstract class WebProxyFuncGivenScenarioTask<TIn1, TIn2, TResult, TUserSession> : WebProxyGivenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession> where TResult : class
    {
        private readonly Func<TIn1, TIn2, TUserSession, Task<TResult>> _func;

        protected WebProxyFuncGivenScenarioTask(Func<TIn1, TIn2, TUserSession, Task<TResult>> func)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            var session = context.ActiveSession;
            var argumentOne = CreateArgumentOne(context);
            var argumentTwo = CreateArgumentTwo(context);
            var result = await _func(argumentOne, argumentTwo, session);
            context.SetResult(new SingleScenarioTestResult<TResult>(result));
        }

        protected abstract TIn1 CreateArgumentOne(ScenarioContext<TUserSession> context);
        protected abstract TIn2 CreateArgumentTwo(ScenarioContext<TUserSession> context);
    }

    public abstract class WebProxyFuncGivenScenarioTask<TIn1, TIn2, TIn3, TResult, TUserSession> : WebProxyGivenScenarioTask<TUserSession>
        where TUserSession : IUserSession<TUserSession> where TResult : class
    {
        private readonly Func<TIn1, TIn2, TIn3, TUserSession, Task<TResult>> _func;

        protected WebProxyFuncGivenScenarioTask(Func<TIn1, TIn2, TIn3, TUserSession, Task<TResult>> func)
        {
            _func = func ?? throw new ArgumentNullException(nameof(func));
        }

        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            var session = context.ActiveSession;
            var argumentOne = CreateArgumentOne(context);
            var argumentTwo = CreateArgumentTwo(context);
            var argumentThree = CreateArgumentThree(context);
            var result = await _func(argumentOne, argumentTwo, argumentThree, session);
            context.SetResult(new SingleScenarioTestResult<TResult>(result));
        }

        protected abstract TIn1 CreateArgumentOne(ScenarioContext<TUserSession> context);
        
        protected abstract TIn2 CreateArgumentTwo(ScenarioContext<TUserSession> context);

        protected abstract TIn3 CreateArgumentThree(ScenarioContext<TUserSession> context);
    }
}
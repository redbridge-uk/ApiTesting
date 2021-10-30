//using System;
//using System.Threading.Tasks;

//namespace Redbridge.ApiTesting.Framework.Tasks.Givens
//{
//    public abstract class WebProxyFuncGivenScenarioTask<TIn1, TUserSession, Task> : WebProxyGivenScenarioTask<TUserSession>
//        where TUserSession : IUserSession<TUserSession>
//    {
//        private readonly Func<TIn1, TUserSession, Task> _func;

//        protected WebProxyFuncGivenScenarioTask(Func<TIn1 , TUserSession, Task> func)
//        {
//            _func = func ?? throw new ArgumentNullException(nameof(func));
//        }

//        protected override async Task OnExecuteAsync(ScenarioContext<TUserSession> context)
//        {
//            var session = context.ActiveSession;
//            var argument = CreateArgument(context);
//            await _func(argument, session);
//            // Hold on, this should only really be done in the 'When' scenarios?
//            OnProcessResult(context);
//        }

//        protected virtual void OnProcessResult(ScenarioContext<TUserSession> context)
//        {
//        }

//        protected abstract TIn1 CreateArgument(ScenarioContext<TUserSession> context);
//    }
//}
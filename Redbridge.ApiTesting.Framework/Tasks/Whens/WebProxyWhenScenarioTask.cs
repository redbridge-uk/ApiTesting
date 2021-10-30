using System;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Exceptions;

namespace Redbridge.ApiTesting.Framework.Tasks.Whens
{
    public abstract class WebProxyWhenScenarioTask<TUserSession> : WhenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        protected override void OnValidateTask(ScenarioContext<TUserSession> context)
        {
            base.OnValidateTask(context);
            if (context.ActiveSession == null) throw new TestScenarioException($"Unable to connect the current session {context.StepNumber} as no active session is set. Please use a set session tasks or similar.");

        }
    }

    public abstract class WebProxyWhenScenarioTask<TUserSession, TIn1> : WebProxyWhenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession> where TIn1 : new()
    {

        protected WebProxyWhenScenarioTask()
        {
        }

        protected virtual TIn1 OnCreateBody(ScenarioContext<TUserSession> context)
        {
            return new TIn1();
        }
    }
}
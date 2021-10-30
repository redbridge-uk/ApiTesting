using System;
using Redbridge.ApiTesting.Framework.Exceptions;
using Redbridge.ApiTesting.Framework.Extensions;

namespace Redbridge.ApiTesting.Framework.Tasks.Thens
{
    public abstract class WebProxyThenScenarioTask<TUserSession, TMessageBody> : WebProxyThenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession> where TMessageBody : new()
    {
        private readonly Lazy<TMessageBody> _body;

        protected WebProxyThenScenarioTask()
        {
            _body = new Lazy<TMessageBody>(OnCreateBody);
        }

        protected virtual TMessageBody OnCreateBody()
        {
            return new TMessageBody();
        }

        public TMessageBody Body => _body.Value;
    }

    public abstract class WebProxyThenScenarioTask<TUserSession> : ThenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        protected override void OnValidateTask(ScenarioContext<TUserSession> context)
        {
            base.OnValidateTask(context);
            if (context.ActiveSession == null) throw new TestScenarioException($"Unable to connect the current session {context.StepNumber} as no active session is set. Please use a set session tasks or similar.");

        }
    }
}
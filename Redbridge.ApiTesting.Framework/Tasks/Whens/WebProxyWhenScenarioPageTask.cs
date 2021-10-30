using Redbridge.ApiTesting.Framework.Exceptions;
using Redbridge.ApiTesting.Framework.Extensions;

namespace Redbridge.ApiTesting.Framework.Tasks.Whens
{
    public abstract class WebProxyWhenScenarioPageTask<TUserSession> : WhenScenarioTask<TUserSession>, IPagedTask 
        where TUserSession : IUserSession<TUserSession>
    {
        protected override void OnValidateTask(ScenarioContext<TUserSession> context)
        {
            base.OnValidateTask(context);
            if (context.ActiveSession == null) throw new TestScenarioException($"Unable to connect the current session {context.StepNumber} as no active session is set. Please use a set session tasks or similar.");
        }

        public int Page { get; set; } = 1;
        public int Size { get; set; } = 20;
        public string Sorting { get; set; } = "+created";
        public string Filter { get; set; }
    }
}
using System;
using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public abstract class ScenarioTask<TUserSession> : IScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public abstract string TaskName { get; }
        public abstract string TaskDescription { get; }

        public async Task ExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            context.Scenario.WriteLog($"Executing task {TaskName} ({TaskDescription})");
            OnValidateTask(context);
            try
            {
                await OnExecuteAsync(context);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw;
            }
        }

        protected abstract Task OnExecuteAsync(ScenarioContext<TUserSession> context);

        protected virtual void OnValidateTask(ScenarioContext<TUserSession> context) {}
    }
}
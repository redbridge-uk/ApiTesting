using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ExpectZeroResultsTask<TUserSession> : ThenStatementTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "Expect at zero result";
        public override string TaskDescription => string.Empty;
        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (!context.Result.Success)
            {
                throw new UnexpectedTestScenarioResultException("Expected at least one result item, but instead the scenario failed for an unexpected reason.");
            }

            if (!(context.Result is IArrayTestResult arrayResult))
            {
                throw new UnexpectedTestScenarioResultException("Expected at least one result item, but the result returned was not an array collection.");
            }

            if (arrayResult.Count != 0)
            {
                throw new UnexpectedTestScenarioResultException($"Expected exactly zero result items, but received {arrayResult.Count}.");
            }

            return Task.CompletedTask;
        }
    }
}
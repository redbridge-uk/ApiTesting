using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ExpectAtLeastResultTask<TUserSession> : ThenStatementTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public ExpectAtLeastResultTask(int minimumExpected)
        {
            MinimumExpectedResults = minimumExpected;
        }

        public override string TaskName => $"Expect at least {MinimumExpectedResults} results";
        public override string TaskDescription => string.Empty;
        public int MinimumExpectedResults { get; set; }
        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (!context.Result.Success)
            {
                throw new UnexpectedTestScenarioResultException($"Expected at least {MinimumExpectedResults} result item, but instead the scenario failed for an unexpected reason.");
            }

            if (!(context.Result is IArrayTestResult arrayResult))
            {
                throw new UnexpectedTestScenarioResultException($"Expected at least {MinimumExpectedResults} result item, but the result returned was not an array collection.");
            }

            if (arrayResult.Count < MinimumExpectedResults)
            {
                throw new UnexpectedTestScenarioResultException($"Expected at least {MinimumExpectedResults} result item, but received {arrayResult.Count} items.");
            }

            return Task.CompletedTask;
        }
    }
}
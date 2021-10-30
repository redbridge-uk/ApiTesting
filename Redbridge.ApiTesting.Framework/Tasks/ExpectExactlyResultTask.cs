using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ExpectExactlyResultTask<TUserSession> : ThenStatementTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public ExpectExactlyResultTask(int count)
        {
            ExpectedResults = count;
        }

        public int ExpectedResults { get; set; }

        public override string TaskName => $"Expect exactly {ExpectedResults} results";
        public override string TaskDescription => string.Empty;
        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (!context.Result.Success)
            {
                throw new UnexpectedTestScenarioResultException($"Expected at least {ExpectedResults} result item, but instead the scenario failed for an unexpected reason.");
            }

            if (!(context.Result is IArrayTestResult arrayResult))
            {
                throw new UnexpectedTestScenarioResultException($"Expected at least {ExpectedResults} result item, but the result returned was not an array collection.");
            }

            if (arrayResult.Count != ExpectedResults)
            {
                throw new UnexpectedTestScenarioResultException($"Expected exactly {ExpectedResults} result item, but received {arrayResult.Count} items.");
            }

            return Task.CompletedTask;
        }
    }
}
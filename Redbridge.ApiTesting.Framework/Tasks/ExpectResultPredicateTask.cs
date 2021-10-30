using System;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ExpectResultPredicateTask<TUserSession, TResult> : ThenStatementTask<TUserSession> where TUserSession : IUserSession<TUserSession> where TResult : class
    {
        private readonly Func<TResult, bool> _predicate;

        public ExpectResultPredicateTask(Func<TResult, bool> predicate)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        }

        public override string TaskName => "Expect result with predicate";
        public override string TaskDescription => string.Empty;
        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context.Result == null)
            {
                throw new UnexpectedTestScenarioResultException();
            }

            var response = context.Result as ScenarioTestResult<TResult>;
            if (response == null)
            {
                throw new UnexpectedTestScenarioResultException();
            }

            if (!_predicate(response.Result))
            {
                throw new UnexpectedTestScenarioResultException("Unexpected result. Predicate not met.");
            }

            return Task.CompletedTask;
        }
    }
}
using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ExpectSuccessTask<TUserSession> : ThenStatementTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "Expect success";
        public override string TaskDescription => string.Empty;
        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context.Result == null || !context.Result.Success)
            {
                throw new UnexpectedTestScenarioResultException("We expected a successful result but ended up with either a null result or a negative success.");
            }

            return Task.CompletedTask;
        }
    }
}
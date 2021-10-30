using System.Net;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ExpectHttpResultTask<TUserSession> : ThenStatementTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName => "Expect success";
        public override string TaskDescription => string.Empty;

        public ExpectHttpResultTask(HttpStatusCode code = HttpStatusCode.OK)
        {
            ExpectedCode = code;
        }

        public HttpStatusCode ExpectedCode { get; set; }

        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (!context.HasResult)
            {
                throw new UnexpectedTestScenarioResultException(
                    "Expected a result with an http code. No result was returned.");
            }

            if (context.Result is IWebResult)
            {

            }

            return Task.CompletedTask;
        }
    }
}
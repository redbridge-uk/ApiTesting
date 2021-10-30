using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ExpectExceptionTask<TUserSession, TException> : ThenStatementTask<TUserSession> where TUserSession : IUserSession<TUserSession>
        where TException: _Exception
    {
        public override string TaskName => "Expect success";
        public override string TaskDescription => string.Empty;
        public string ExpectedMessage { get; set; }

        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context.Result == null || context.Result.Success)
            {
                throw new UnexpectedTestScenarioResultException("Expected the result to be an exception, however the step succeeded.");
            }

            if (!(context.Result is ExceptionResult exceptionResult))
            {
                throw new UnexpectedTestScenarioResultException("Expected the result to be an exception, however the result returned was of an unexpected type.");
            }

            if (exceptionResult.Exception.GetType() != typeof(TException))
            {
                throw new UnexpectedTestScenarioResultException($"Expected the result to be an exception of type {typeof(TException)}, however the result returned was of type {exceptionResult.Exception.GetType()}.");
            }

            if ( !string.IsNullOrWhiteSpace(ExpectedMessage) )
            {
                var message = exceptionResult.Exception.Message;
                if (!message.Equals(ExpectedMessage))
                {
                    throw new UnexpectedTestScenarioResultException(
                        $"Unexpected exception message, expected '{ExpectedMessage}' but received '{message}' Note that validation is case sensitive.");
                }
            }

            return Task.CompletedTask;
        }
    }
}
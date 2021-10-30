using System;

namespace Redbridge.ApiTesting.Framework.Results
{
    public class ExceptionResult : ScenarioTestResult
    {
        public ExceptionResult(Exception exception)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
        }

        public override bool Success => false;
        public Exception Exception { get; }
    }
}
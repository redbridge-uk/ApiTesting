using System;

namespace Redbridge.ApiTesting.Framework.Results
{
    public class FailTestResult : ScenarioTestResult
    {
        public string Message { get; }

        public FailTestResult(string message)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        public override bool Success => false;
    }
}
using System;

namespace Redbridge.ApiTesting.Framework.Results
{
    public abstract class ScenarioTestResult : IScenarioTestResult
    {
        protected ScenarioTestResult()
        {
        }

        public abstract bool Success { get; }
    }

    public abstract class ScenarioTestResult<TResult> : ScenarioTestResult
        where TResult: class
    {
        protected ScenarioTestResult(TResult result)
        {
            Result = result ?? throw new ArgumentNullException(nameof(result));
        }

        public TResult Result { get; }

        public override bool Success => true;
    }
}
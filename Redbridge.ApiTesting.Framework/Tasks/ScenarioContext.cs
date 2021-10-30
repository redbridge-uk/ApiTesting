using System;
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public abstract class ScenarioContext<TUserSession>
        where TUserSession: IUserSession<TUserSession>
    {
        private IScenarioTestResult _result;
        private int _stepCounter = 1;

        protected ScenarioContext(TestScenario<TUserSession> scenario)
        {
            Scenario = scenario ?? throw new ArgumentNullException(nameof(scenario));
        }

        public TestScenario<TUserSession> Scenario { get; }

        public void Succeed()
        {
            SetResult(new SuccessTestResult());
        }

        public void Fail(string reason = "")
        {
            SetResult(new FailTestResult(reason));
        }

        public void SetResult (IScenarioTestResult result)
        {
            _result = result ?? throw new ArgumentNullException(nameof(result));
        }

        public IScenarioTestResult Result => _result;

        public bool HasResult => _result != null;

        public void IncrementStep()
        {
            _stepCounter++;
        }

        public TUserSession ActiveSession { get; set; }
        public int StepNumber => _stepCounter;
    }
}
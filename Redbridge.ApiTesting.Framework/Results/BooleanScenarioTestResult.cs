namespace Redbridge.ApiTesting.Framework.Results
{
    public class BooleanTestResult : ScenarioTestResult
    {
        public BooleanTestResult(bool result)
        {
            Success = result;
        }

        public override bool Success { get; }

        public static BooleanTestResult True => new BooleanTestResult(true);
        public static BooleanTestResult False => new BooleanTestResult(false);
    }
}
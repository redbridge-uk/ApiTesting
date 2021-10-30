namespace Redbridge.ApiTesting.Framework.Results
{
    public class ArrayScenarioTestResult<TEntity> : ScenarioTestResult<TEntity[]>, IArrayTestResult
    {
        public ArrayScenarioTestResult(TEntity[] result) : base(result)
        {
        }

        public int Count => Result.Length;
    }
}
namespace Redbridge.ApiTesting.Framework.Results
{
    public class PagedScenarioTestResult<TEntity> : ScenarioTestResult<TEntity[]>, IArrayTestResult
    {
        public PagedScenarioTestResult(TEntity[] result) : base(result)
        {
        }

        public int Count => Result.Length;
    }
}
using Redbridge.ApiTesting.Framework.Results;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class SingleScenarioTestResult<TEntity> : ScenarioTestResult<TEntity> where TEntity : class
    {
        public SingleScenarioTestResult(TEntity result) : base(result)
        {
        }
    }
}
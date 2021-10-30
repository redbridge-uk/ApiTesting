using Redbridge.ApiTesting.Framework.Tasks;

namespace Redbridge.ApiTesting.Framework.Tests
{
    public class TestScenarioContext : ScenarioContext<TestUserSession>
    {
        public TestScenarioContext(UnitTestScenario scenario) : base(scenario)
        {
        }

        public static TestScenarioContext StartNew(UnitTestScenario scenario)
        {
            return new TestScenarioContext(scenario);
        }
    }
}
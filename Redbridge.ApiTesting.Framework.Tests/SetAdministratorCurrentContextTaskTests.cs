using System.Threading.Tasks;
using NUnit.Framework;
using Redbridge.ApiTesting.Framework.Tasks.Givens;

namespace Redbridge.ApiTesting.Framework.Tests
{
    [TestFixture]
    public class SetAdministratorCurrentContextTaskTests
    {
        [Test]
        public void Construct_SetAdministratorCurrentContextTask_ExpectSuccess()
        {
            var task = new SetAdministratorCurrentContextGivenTask<TestUserSession>();
            Assert.IsNotNull(task);
            Assert.AreEqual("An administrator account", task.TaskName);
        }

        [Test]
        public async Task ExecuteAsync_SetAdministratorCurrentContextTask_ExpectContextSet()
        {
            var task = new SetAdministratorCurrentContextGivenTask<TestUserSession>();
            var scenario = UnitTestScenario.StartNew("Test");
            var context = new TestScenarioContext(scenario);
            Assert.IsNull(context.ActiveSession);
            await task.ExecuteAsync(context);
            Assert.AreEqual(scenario.Administrator, context.ActiveSession);
        }
    }
}

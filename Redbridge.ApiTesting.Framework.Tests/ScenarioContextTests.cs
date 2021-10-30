using System;
using NUnit.Framework;

namespace Redbridge.ApiTesting.Framework.Tests
{
    [TestFixture]
    public class ScenarioContextTests
    {
        [Test]
        public void CreateNew_ScenarioContextGivenNullScenario_ExpectArgumentNull()
        {
            var ane = Assert.Throws<ArgumentNullException>(() => UnitTestScenario.StartNew(null));
            Assert.IsNotNull(ane);
            Assert.AreEqual("name", ane.ParamName);
        }

        [Test]
        public void CreateNew_ScenarioContext_ExpectSuccess()
        {
            var scenario = UnitTestScenario.StartNew("TEST1");
            var context = TestScenarioContext.StartNew(scenario);
            Assert.IsNotNull(context);
            Assert.AreEqual(context.Scenario, scenario);
            Assert.IsNull(context.ActiveSession);
            Assert.IsFalse(context.HasResult);
            Assert.IsNull(context.Result);
            Assert.AreEqual(1, context.StepNumber);
        }

        [Test]
        public void IncrementStep_FromNewScenarioContext_ExpectUpdatedStepCount()
        {
            var scenario = UnitTestScenario.StartNew("TEST1");
            var context = TestScenarioContext.StartNew(scenario);
            context.IncrementStep();
            Assert.AreEqual(2, context.StepNumber);
        }
    }
}

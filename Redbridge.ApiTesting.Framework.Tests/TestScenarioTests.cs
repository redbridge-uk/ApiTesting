using NUnit.Framework;
using Redbridge.IntegrationTesting;

namespace Redbridge.ApiTesting.Framework.Tests
{
    [TestFixture]
    public class TestScenarioTests
    {
        [Test]
        public void ConstructTestScenario_WithoutDescription_ExpectInstance()
        {
            var scenario = UnitTestScenario.StartNew("EL-0001");
            Assert.IsNotNull(scenario);
            Assert.AreEqual("EL-0001", scenario.Name);
            Assert.AreEqual("", scenario.Description);
            Assert.IsNotNull(scenario.Administrator, "Expected an administrator user");
            Assert.IsNotNull(scenario.Anonymous, "Expected an anonymous user");
            Assert.IsNotNull(scenario.Given, "Given statement builder should not be null.");
            Assert.IsNotNull(scenario.Given.When, "When statement builder should not be null.");
            Assert.IsNotNull(scenario.Given.When.Then, "Then statement builder should not be null.");
        }

        [Test]
        public void ConstructTestScenario_WithDescription_ExpectInstance()
        {
            var scenario = UnitTestScenario.StartNew("EL-0001", "An administrator user can login.");
            Assert.IsNotNull(scenario);
            Assert.AreEqual("EL-0001", scenario.Name);
            Assert.AreEqual("An administrator user can login.", scenario.Description);
            Assert.IsNotNull(scenario.Administrator, "Expected an administrator user");
            Assert.IsNotNull(scenario.Anonymous, "Expected an anonymous user");
            Assert.IsNotNull(scenario.Given, "Given statement builder should not be null.");
            Assert.IsNotNull(scenario.Given.When, "When statement builder should not be null.");
            Assert.IsNotNull(scenario.Given.When.Then, "Then statement builder should not be null.");
        }
    }
}
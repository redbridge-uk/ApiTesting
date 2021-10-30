using System;
using Moq;
using Redbridge.Configuration;
using Redbridge.Diagnostics;

namespace Redbridge.ApiTesting.Framework.Tests
{
    public class TestScenarioBuilder
    {
        public TestScenarioBuilder()
        {
            MockApplicationSettings = new Mock<IApplicationSettingsRepository>();
            MockApplicationSettings.Setup(a => a.GetUrl("serviceUri")).Returns(new Uri("https://localhost:1234"));
            MockLogger = new Mock<ILogger>();
        }

        public Mock<IApplicationSettingsRepository> MockApplicationSettings { get; set; }
        public Mock<ILogger> MockLogger { get; set; }

        //public TestScenario Build()
        //{
        //    return new TestScenario(MockApplicationSettings.Object, MockLogger.Object, "MockTest");
        //}
    }

    //[TestFixture]
    //public class ConnectCurrentSessionTaskTests
    //{
    //    [Test]
    //    public void Construct_ConnectCurrentSessionTask_ExpectSuccess()
    //    {
    //        var task = new ConnectCurrentSessionTask();
    //        Assert.AreEqual("Connect current session", task.Name);
    //        Assert.AreEqual("Connects the current context session", task.Description);
    //    }

    //    [Test]
    //    public void ExecuteTask_ConnectCurrentSessionTaskWithNullScenarioContext_ExpectArgumentNullException()
    //    {
    //        var task = new ConnectCurrentSessionTask();
    //        var ane = Assert.ThrowsAsync<ArgumentNullException>(() => task.ExecuteAsync(null));
    //        Assert.IsNotNull(ane);
    //    }

    //    [Ignore("Doesn't work yet.")]
    //    public async Task ExecuteTask_ConnectCurrentSessionTaskWithNullScenario_ExpectSuccess()
    //    {
    //        var builder = new TestScenarioBuilder();
    //        var task = new ConnectCurrentSessionTask();
    //        var scenario = builder.Build();
    //        await task.ExecuteAsync(ScenarioContext.StartNew(scenario));
    //    }
    //}
}

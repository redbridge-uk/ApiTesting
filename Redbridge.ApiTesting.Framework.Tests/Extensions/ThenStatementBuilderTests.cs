using System;
using Moq;
using NUnit.Framework;
using Redbridge.ApiTesting.Framework.Extensions;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Framework.Tests.Extensions
{
    [TestFixture]
    public class ThenStatementBuilderTests
    {
        [Test]
        public void Construct_ThenStatementBuilder_ExpectSuccess()
        {
            var builder = new ThenStatementBuilder<TestUserSession>();
            Assert.AreEqual(0, builder.Count);
        }

        [Test]
        public void AddNullItem_ToThenStatementBuilder_ExpectArgumentNullException()
        {
            var builder = new ThenStatementBuilder<TestUserSession>();
            IThenScenarioTask<TestUserSession> task = null;
            var ane = Assert.Throws<ArgumentNullException>(() => builder.AddTask(task));
            Assert.AreEqual("task", ane.ParamName);
        }

        [Test]
        public void AddItem_ToThenStatementBuilder_ExpectItemAdded()
        {
            var builder = new ThenStatementBuilder<TestUserSession>();
            var mockTask = new Mock<IThenScenarioTask<TestUserSession>>();
            builder.AddTask(mockTask.Object);
            Assert.AreEqual(1, builder.Count);
        }
    }
}

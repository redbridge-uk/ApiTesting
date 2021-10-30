using System;
using Moq;
using NUnit.Framework;
using Redbridge.ApiTesting.Framework.Extensions;
using Redbridge.ApiTesting.Framework.Tasks.Givens;

namespace Redbridge.ApiTesting.Framework.Tests
{
    [TestFixture]
    public class GivenStatementBuilderTests
    {
        [Test]
        public void Construct_GivenStatementBuilder_ExpectSuccess()
        {
            var whenStatementBuilder = new WhenStatementBuilder<TestUserSession>(new ThenStatementBuilder<TestUserSession>());
            var builder = new GivenStatementBuilder<TestUserSession>(whenStatementBuilder);
            Assert.AreEqual(0, builder.Count);
        }

        [Test]
        public void AddNullTask_GivenStatementBuilder_ExpectArgumentNullException()
        {
            var whenStatementBuilder = new WhenStatementBuilder<TestUserSession>(new ThenStatementBuilder<TestUserSession>());
            var builder = new GivenStatementBuilder<TestUserSession>(whenStatementBuilder);
            IGivenScenarioTask<TestUserSession> task = null;
            Assert.Throws<ArgumentNullException>(() => builder.AddTask(task));
        }

        [Test]
        public void AddTask_GivenStatementBuilder_ExpectItemCounted()
        {
            var whenStatementBuilder = new WhenStatementBuilder<TestUserSession>(new ThenStatementBuilder<TestUserSession>());
            var builder = new GivenStatementBuilder<TestUserSession>(whenStatementBuilder);
            var task = new Mock<IGivenScenarioTask<TestUserSession>>();
            builder.AddTask(task.Object);
            Assert.AreEqual(1, builder.Count);
        }

        [Test]
        public void Construct_GivenStatementBuilder_ExpectWhenStatementBuilderInstance()
        {
            var whenStatementBuilder = new WhenStatementBuilder<TestUserSession>(new ThenStatementBuilder<TestUserSession>());
            var builder = new GivenStatementBuilder<TestUserSession>(whenStatementBuilder);
            Assert.AreEqual(builder.When, whenStatementBuilder);
        }
    }
}

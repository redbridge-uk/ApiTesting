using System;
using NUnit.Framework;
using Redbridge.ApiTesting.Framework.Extensions;

namespace Redbridge.ApiTesting.Framework.Tests
{
    [TestFixture]
    public class WhenStatementBuilderTests
    {
        [Test]
        public void Construct_WhenStatementBuilderWithThenStatementBuilder_ExpectSuccess()
        {
            var thenStatement = new ThenStatementBuilder<TestUserSession>();
            var builder = new WhenStatementBuilder<TestUserSession>(thenStatement);
            Assert.IsNull(builder.SessionName);
            Assert.AreEqual(builder.Then, thenStatement);
        }


        [Test]
        public void SetNullTask_WhenStatementBuilder_ExpectArgumentNullException()
        {
            var ane = Assert.Throws<ArgumentNullException>(() => new WhenStatementBuilder<TestUserSession>(null));
            Assert.IsNotNull(ane);
            Assert.AreEqual("thenStatementBuilder", ane.ParamName);
        }
    }
}

using NUnit.Framework;
using Redbridge.ApiTesting.Framework.Extensions;
using Redbridge.ApiTesting.Framework.Tasks.Whens;

namespace Redbridge.ApiTesting.Framework.Tests
{
    [TestFixture]
    public class WhenStatementBuilderExtensionsTests
    {
        [Test]
        public void WhenLoggedIn_ExtensionApplied_ThenWhenTaskSet()
        {
            var thenBuilder = new ThenStatementBuilder<TestUserSession>();
            var builder = new WhenStatementBuilder<TestUserSession>(thenBuilder);
            var result = builder.LoggedIn();
            Assert.AreEqual(result, builder);
            Assert.IsNotNull(builder.Task);
            Assert.AreEqual(typeof(ConnectCurrentSessionTask<TestUserSession>), builder.Task.GetType());
        }
    }
}

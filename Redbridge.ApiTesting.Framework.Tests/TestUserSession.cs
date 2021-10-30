using System;
using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tests
{
    public class TestUserSession : IUserSession<TestUserSession>
    {
        private readonly UnitTestScenario _scenario;

        public TestUserSession(UnitTestScenario scenario, string name)
        {
            _scenario = scenario ?? throw new ArgumentNullException(nameof(scenario));
            Name = name;
        }

        public Task<TestUserSession> ConnectAsync()
        {
            return Task.FromResult(this);
        }

        public Task DisconnectAsync()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
        }

        public string Name { get; }
        public bool IsConnected => false;
    }
}
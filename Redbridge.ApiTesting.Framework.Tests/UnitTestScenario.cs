using System;
using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.Configuration;
using Redbridge.Console.Diagnostics;

namespace Redbridge.ApiTesting.Framework.Tests
{
    public class UnitTestScenario : TestScenario<TestUserSession>
    {
        public UnitTestScenario(IApplicationSettingsRepository appSettings, string name, string description = "") 
            : base(appSettings, new ConsoleLogWriter(), name, description) {}

        public override TestUserSession CreateSession(string name, string email, string password, bool addToSessionCollection = true, string agent = "TestingFramework")
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            return new TestUserSession(this, name);
        }

        protected override ScenarioContext<TestUserSession> CreateContext()
        {
            return new TestScenarioContext(this);
        }

        public static UnitTestScenario StartNew(string name, string description = "")
        {
            return new UnitTestScenario(new WindowsApplicationSettingsRepository(), name, description);
        }
    }
}
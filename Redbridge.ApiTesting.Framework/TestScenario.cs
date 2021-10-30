using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Exceptions;
using Redbridge.ApiTesting.Framework.Extensions;
using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.Configuration;
using Redbridge.Diagnostics;

namespace Redbridge.ApiTesting.Framework
{
    public abstract class TestScenario<TUserSession> : IDisposable
        where TUserSession: IUserSession<TUserSession>, IDisposable
    {
        public string Name { get; }
        public string Description { get; }
        private readonly TUserSession _administratorSession;
        private readonly TUserSession _anonymousSession;
        private readonly UserSessionCollection<TUserSession> _sessionsCollection = new UserSessionCollection<TUserSession>();
        private readonly ScenarioStatements<TUserSession> _statements;

        protected TestScenario (IApplicationSettingsRepository appSettings, ILogger logger, string name, string description = "")
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            Settings = appSettings;

            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Logger.WriteDebug($"Created test scenario {name} with description {description}");
            
            var administratorUser = Settings.GetStringValue("administratorUser");
            if (administratorUser == null) throw new TestScenarioException("The application setting 'administratorUser' must be configured. Null or empty string values are not supported.");

            var administratorPassword = Settings.GetStringValue("administratorPassword");
            if (administratorPassword == null) throw new TestScenarioException("The application setting 'administratorPassword' must be configured. Null or empty string values are not supported.");

            _administratorSession = CreateSession("Administrator", administratorUser, administratorPassword, false, "");
            _anonymousSession = CreateSession("Anonymous", string.Empty, string.Empty, false, "");
            _statements = new ScenarioStatements<TUserSession>();
        }

        protected ILogger Logger { get; }

        protected IApplicationSettingsRepository Settings { get; }

        public abstract TUserSession CreateSession(string name, string email, string password,
            bool addToSessionCollection, string agent);

        public UserSessionCollection<TUserSession> Sessions => _sessionsCollection;
        public TUserSession Administrator => _administratorSession;
        public TUserSession Anonymous => _anonymousSession;

        public void Dispose()
        {
            Logger.WriteInfo($"Disposing session {Name}.");
            _anonymousSession?.Dispose();
            _administratorSession?.Dispose();
            _sessionsCollection?.Dispose();
            Logger.WriteInfo("Test scenario disposed.");
            if (Context == null) throw new ScenarioNotExecutedException();
        }

        public void WriteLog(string content)
        {
            Logger.WriteInfo(content);
        }

        public string CreateRandomEmail()
        {
            var builder = new RandomEmailBuilder();
            var email = builder.Create();
            Logger.WriteInfo($"Created random email {email}");
            return email;
        }
        
        public IGivenStatementBuilder<TUserSession> Given => _statements.Givens;

        private ScenarioContext<TUserSession> Context { get; set; }

        public async Task Run()
        {
            var stopWatch = Stopwatch.StartNew();
            try
            {
                if (Context != null) throw new ScenarioAlreadyExecutedException();
                _statements.Validate();
                Context = CreateContext();
                await _statements.ExecuteAsync(Context);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                throw new UnexpectedTestScenarioResultException($"Scenario {Name} failed to complete using the expectations configured. The underlying exception was: {e.Message}");
            }
            finally
            {
                stopWatch.Stop();
                System.Console.WriteLine($"Completed executing scenario in {stopWatch.Elapsed}");
            }
        }

        protected abstract ScenarioContext<TUserSession> CreateContext();

    }
}

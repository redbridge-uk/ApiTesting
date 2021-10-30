using System;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Extensions;
using Redbridge.ApiTesting.Framework.Tasks;

namespace Redbridge.ApiTesting.Framework
{
    public class ScenarioStatements<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public ScenarioStatements()
        {
            Thens = new ThenStatementBuilder<TUserSession>();
            When = new WhenStatementBuilder<TUserSession>(Thens);
            Givens = new GivenStatementBuilder<TUserSession>(When);
        }

        public GivenStatementBuilder<TUserSession> Givens { get; }
        public WhenStatementBuilder<TUserSession> When { get; }
        public ThenStatementBuilder<TUserSession> Thens { get; }

        public async Task ExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            // Start monitors as appropriate
            await Thens.StartMonitorsAsync(context);
            await Givens.ExecuteAsync(context);
            await When.ExecuteAsync(context);
            await Thens.ExecuteAsync(context);
            await Thens.StopMonitorsAsync();
        }

        public void Validate()
        {

        }
    }
}
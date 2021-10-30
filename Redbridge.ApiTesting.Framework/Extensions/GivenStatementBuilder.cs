using System;
using Redbridge.ApiTesting.Framework.Tasks.Givens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class GivenStatementBuilder<TUserSession> : StatementBuilder<IGivenScenarioTask<TUserSession>, TUserSession>, IGivenStatementBuilder<TUserSession>
        where TUserSession : IUserSession<TUserSession>
    {
        public GivenStatementBuilder(WhenStatementBuilder<TUserSession> whenStatementBuilder)
        {
            When = whenStatementBuilder ?? throw new ArgumentNullException(nameof(whenStatementBuilder));
        }

        public IWhenStatementBuilder<TUserSession> When { get; }
        public IGivenStatementBuilder<TUserSession> And => this;
    }
}
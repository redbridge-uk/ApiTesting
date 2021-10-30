using Redbridge.ApiTesting.Framework.Tasks.Givens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public interface IGivenStatementBuilder<TUserSession> : IStatementBuilder where TUserSession : IUserSession<TUserSession>
    {
        TK AddTask<TK>(TK task) where TK : IGivenScenarioTask<TUserSession>;
        IWhenStatementBuilder<TUserSession> When { get; }
        IGivenStatementBuilder<TUserSession> And { get; }
    }
}
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public interface IThenStatementBuilder<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        IThenStatementBuilder<TUserSession> AndThen { get; }
        IThenStatementBuilder<TUserSession> And { get; }
        TK AddTask<TK>(TK task) where TK : IThenScenarioTask<TUserSession>;
    }
}
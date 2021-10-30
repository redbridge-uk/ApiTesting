using Redbridge.ApiTesting.Framework.Tasks.Whens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public interface IWhenStatementBuilder<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        IThenStatementBuilder<TUserSession> Then { get; }
        IWhenStatementBuilder<TUserSession> Is { get; }
        TTask SetTask<TTask>(TTask task) where TTask: IWhenScenarioTask<TUserSession>;
        IWhenStatementBuilder<TUserSession> User(string user);
    }
}
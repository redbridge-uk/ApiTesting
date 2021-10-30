using Redbridge.ApiTesting.Framework.Tasks.Whens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public interface IPagedWhenStatementBuilder<TUserSession>  where TUserSession : IUserSession<TUserSession>
    {
        ThenStatementBuilder<TUserSession> Then { get; }
        IWhenStatementBuilder<TUserSession> Is { get; }
        TTask SetTask<TTask>(TTask task) where TTask : IWhenScenarioTask<TUserSession>, IPagedTask;
        IWhenStatementBuilder<TUserSession> User(string user);
    }
}
namespace Redbridge.ApiTesting.Framework.Tasks.Thens
{
    public interface IThenScenarioTask<TUserSession> : IScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
    }
}
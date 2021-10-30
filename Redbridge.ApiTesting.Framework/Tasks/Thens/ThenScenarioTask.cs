namespace Redbridge.ApiTesting.Framework.Tasks.Thens
{
    public abstract class ThenScenarioTask<TUserSession> : ScenarioTask<TUserSession>, IThenScenarioTask<TUserSession> 
        where TUserSession : IUserSession<TUserSession>
    {
    }
}
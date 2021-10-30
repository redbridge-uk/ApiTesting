namespace Redbridge.ApiTesting.Framework.Tasks.Givens
{
    public interface IGivenScenarioTask<TUserSession> : IScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
    }
}
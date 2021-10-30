namespace Redbridge.ApiTesting.Framework.Tasks.Givens
{
    public abstract class WebProxyGivenScenarioTask<TUserSession> : GivenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        protected WebProxyGivenScenarioTask()
        {
        }
    }
}
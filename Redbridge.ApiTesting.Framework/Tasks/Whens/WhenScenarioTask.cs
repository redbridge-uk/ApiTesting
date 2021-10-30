namespace Redbridge.ApiTesting.Framework.Tasks.Whens
{
    public abstract class WhenScenarioTask<TUserSession> : ScenarioTask<TUserSession>, IWhenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public bool CaptureResult { get; set; } = true;
    }
}
namespace Redbridge.ApiTesting.Framework.Tasks.Whens
{
    public interface IWhenScenarioTask<TUserSession> : IScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        bool CaptureResult { get; set; }
    }
}
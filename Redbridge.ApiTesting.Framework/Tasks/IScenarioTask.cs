using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    /// <summary>
    /// For tasks that run during the whole of the scenario.
    /// </summary>
    public interface IMonitorTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        Task StartMonitorAsync(ScenarioContext<TUserSession> session);
        Task StopMonitorAsync();
    }

    public interface IScenarioTask<TUserSession> 
        where TUserSession : IUserSession<TUserSession>
    {
        string TaskName { get; }
        string TaskDescription { get; }
        Task ExecuteAsync(ScenarioContext<TUserSession> context);
    }
}
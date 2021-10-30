using Redbridge.ApiTesting.Framework.Tasks.Givens;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public abstract class GivenScenarioTask<TUserSession> : ScenarioTask<TUserSession>, IGivenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        
    }
}
using System.Linq;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class ThenStatementBuilder<TUserSession> : StatementBuilder<IThenScenarioTask<TUserSession>, TUserSession>, IThenStatementBuilder<TUserSession>
        where TUserSession : IUserSession<TUserSession>
    {
        public IThenStatementBuilder<TUserSession> AndThen => this;
        public IThenStatementBuilder<TUserSession> And => this;

        public async Task StartMonitorsAsync(ScenarioContext<TUserSession> session)
        {
           var monitors = Tasks.Where(t => t is IMonitorTask<TUserSession>).Cast<IMonitorTask<TUserSession>>();
           foreach (var m in monitors)
           {
               await m.StartMonitorAsync(session);
           }
        }

        public async Task StopMonitorsAsync()
        {
            var monitors = Tasks.Where(t => t is IMonitorTask<TUserSession>).Cast<IMonitorTask<TUserSession>>();
            foreach (var m in monitors)
            {
                await m.StopMonitorAsync();
            }
        }
    }
}
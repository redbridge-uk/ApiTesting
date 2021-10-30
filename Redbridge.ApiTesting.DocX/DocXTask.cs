using System;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework;
using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.DocX
{
    public class DocXTask<TUserSession> : ThenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        public override string TaskName { get; }
        public override string TaskDescription { get; }
        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            throw new NotImplementedException();
        }
    }
}

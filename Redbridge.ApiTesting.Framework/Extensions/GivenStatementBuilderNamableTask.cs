using Redbridge.ApiTesting.Framework.Tasks;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class GivenStatementBuilderNameableTask<TUserSession, TTask> : GivenStatementBuilderTask<TUserSession, TTask>, IGivenStatementBuilderNameableTask<TUserSession>
        where TUserSession : IUserSession<TUserSession> where TTask : class, ISessionNamable
    {
        public GivenStatementBuilderNameableTask(IGivenStatementBuilder<TUserSession> builder, TTask task) : base(builder, task) { }
        
        public string Name
        {
            get => Task.SessionName;
            set => Task.SessionName = value;
        }

        public string SessionName
        {
            get => Task.SessionName;
            set => Task.SessionName = value;
        }
    }
}
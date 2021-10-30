using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.Data;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class WhenStatementBuilderNameableTask<TTask, TUserSession> : WhenStatementBuilderTask<TUserSession, TTask>, IWhenStatementBuilderNameableTask<TUserSession>
        where TUserSession : IUserSession<TUserSession> where TTask : class, ISessionNamable
    {
        public WhenStatementBuilderNameableTask(IWhenStatementBuilder<TUserSession> builder, TTask task) : base(builder, task) { }
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

    public class WhenStatementBuilderNameableTask<TUserSession> : INamed where TUserSession : IUserSession<TUserSession>
    {
        public WhenStatementBuilderNameableTask(IWhenStatementBuilder<TUserSession> builder, INamed task)
        {
            Builder = builder;
            Task = task;
        }

        public IWhenStatementBuilder<TUserSession> Builder { get; }
        public INamed Task { get; }

        public string Name
        {
            get => Task.Name;
            set => Task.Name = value;
        }

        public IThenStatementBuilder<TUserSession> Then => Builder.Then;

        public WhenStatementBuilderNameableTask<TUserSession> Named(string name)
        {
            Name = name;
            return this;
        }
    }
}
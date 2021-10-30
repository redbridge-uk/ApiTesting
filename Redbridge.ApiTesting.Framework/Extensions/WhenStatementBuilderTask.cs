using System;
using Redbridge.ApiTesting.Framework.Tasks.Whens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class WhenStatementBuilderTask<TUserSession, TTask> : IWhenStatementBuilder<TUserSession> where TUserSession : IUserSession<TUserSession> 
        where TTask : class
    {
        public WhenStatementBuilderTask(IWhenStatementBuilder<TUserSession> builder, TTask task)
        {
            Builder = builder ?? throw new ArgumentNullException(nameof(builder));
            Task = task;
        }

        public IWhenStatementBuilder<TUserSession> Builder { get; }

        public TTask Task { get; }
        public IThenStatementBuilder<TUserSession> Then => Builder.Then;
        public IWhenStatementBuilder<TUserSession> Is => this;
        public TTask1 SetTask<TTask1>(TTask1 task) where TTask1 : IWhenScenarioTask<TUserSession>
        {
            return Builder.SetTask(task);
        }

        public IWhenStatementBuilder<TUserSession> User(string user)
        {
            return Builder.User(user);
        }
    }
}
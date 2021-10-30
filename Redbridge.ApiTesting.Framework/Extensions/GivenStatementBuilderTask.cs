using System;
using Redbridge.ApiTesting.Framework.Tasks.Givens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public abstract class GivenStatementBuilderTask<TUserSession, TTask> : IGivenStatementBuilder<TUserSession> where TTask : class where TUserSession : IUserSession<TUserSession>
    {
        private readonly IGivenStatementBuilder<TUserSession> _builder;

        protected GivenStatementBuilderTask(IGivenStatementBuilder<TUserSession> builder, TTask task)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
            Task = task ?? throw new ArgumentNullException(nameof(task));
        }

        public TTask Task { get; }
        public IGivenStatementBuilder<TUserSession> Builder => _builder;

        public TK AddTask<TK>(TK task) where TK : IGivenScenarioTask<TUserSession>
        {
            return _builder.AddTask(task);
        }

        public IWhenStatementBuilder<TUserSession> When => _builder.When;
        public IGivenStatementBuilder<TUserSession> And => this;
        public IGivenStatementBuilder<TUserSession> WhoIs => this;
    }
}
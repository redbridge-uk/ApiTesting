using System;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class ThenStatementTaskBuilder<TUserSession, TTask> : IThenStatementBuilder<TUserSession> where TUserSession : IUserSession<TUserSession>
    where TTask: class, IThenScenarioTask<TUserSession>
    {
        public TTask Task { get; }
        private readonly IThenStatementBuilder<TUserSession> _builder;

        public ThenStatementTaskBuilder(IThenStatementBuilder<TUserSession> builder, TTask task)
        {
            Task = task ?? throw new ArgumentNullException(nameof(task));
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public IThenStatementBuilder<TUserSession> AndThen => this;

        public IThenStatementBuilder<TUserSession> And => this;

        public TK AddTask<TK>(TK task) where TK : IThenScenarioTask<TUserSession>
        {
            return _builder.AddTask(task);
        }
    }
}
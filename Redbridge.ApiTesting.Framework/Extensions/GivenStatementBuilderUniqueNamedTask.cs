using System;
using Redbridge.ApiTesting.Framework.Tasks.Givens;
using Redbridge.Data;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class GivenStatementBuilderUniqueNamedTask<TUserSession, TTask> : INamed, IUnique, IGivenStatementBuilder<TUserSession>
        where TTask: class, IUnique, INamed
        where TUserSession : IUserSession<TUserSession>
    {
        public GivenStatementBuilderUniqueNamedTask(IGivenStatementBuilder<TUserSession> builder, TTask task)
        {
            Builder = builder;
            Task = task;
        }

        public IGivenStatementBuilder<TUserSession> Builder { get; }
        public TTask Task { get; }

        public string Name
        {
            get => Task.Name;
            set => Task.Name = value;
        }

        public GivenStatementBuilderUniqueNamedTask<TUserSession, TTask> Named(string name)
        {
            Name = name;
            return this;
        }

        public IGivenStatementBuilder<TUserSession> And => this;
        public GivenStatementBuilderUniqueNamedTask<TUserSession, TTask> WhoIs => this;
        public IWhenStatementBuilder<TUserSession> When => Builder.When;

        public TK AddTask<TK>(TK task) where TK : IGivenScenarioTask<TUserSession>
        {
            return Builder.AddTask(task);
        }

        public Guid Id
        {
            get => Task.Id;
            set => Task.Id = value;
        }

        public GivenStatementBuilderUniqueNamedTask<TUserSession, TTask> IdentifiedBy(Guid orgId)
        {
            Task.Id = orgId;
            return this;
        }
    }
}
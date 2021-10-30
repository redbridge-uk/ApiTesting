using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Tasks;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public abstract class StatementBuilder<T, TUserSession> 
        where T:IScenarioTask<TUserSession> 
        where TUserSession : IUserSession<TUserSession>
   
    {
        protected List<T> Tasks { get; } = new List<T>();

        public TK AddTask<TK>(TK task) where TK : T
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            Tasks.Add(task);
            return task;
        }

        public async Task ExecuteAsync(ScenarioContext<TUserSession> context)
        {
            foreach (var task in Tasks)
            {
                await task.ExecuteAsync(context);
            }
        }

        public int Count => Tasks.Count;
    }
}
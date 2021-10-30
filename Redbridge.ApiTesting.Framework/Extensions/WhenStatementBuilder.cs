using System;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Exceptions;
using Redbridge.ApiTesting.Framework.Results;
using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.ApiTesting.Framework.Tasks.Whens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public class WhenStatementBuilder<TUserSession> : IWhenStatementBuilder<TUserSession> where TUserSession : IUserSession<TUserSession>
    {
        private IWhenScenarioTask<TUserSession> _whenTask;
        private string _currentUserContext = null;

        public WhenStatementBuilder(ThenStatementBuilder<TUserSession> thenStatementBuilder)
        {
            Then = thenStatementBuilder ?? throw new ArgumentNullException(nameof(thenStatementBuilder));
        }

        public string SessionName => _currentUserContext;

        public IThenStatementBuilder<TUserSession> Then { get; }
        public IWhenStatementBuilder<TUserSession> Is => this;
        public IWhenScenarioTask<TUserSession> Task => _whenTask;

        public IWhenStatementBuilder<TUserSession> User (string userName)
        {
            _currentUserContext = userName ?? throw new ArgumentNullException(nameof(userName));
            return this;
        }

        public async Task ExecuteAsync(ScenarioContext<TUserSession> context)
        {
            try
            {
                if (_whenTask == null)
                    throw new TestScenarioException(
                        "No when task has been defined, check that you have a when task configured.");
                await _whenTask.ExecuteAsync(context);
            }
            catch (Exception e)
            {
                context.SetResult(new ExceptionResult(e));
                throw;
            }
        }

        public T SetTask<T>(T task) where T : IWhenScenarioTask<TUserSession>
        {
            if (task == null) throw new ArgumentNullException(nameof(task));
            if (_whenTask != null) throw new WhenStatementTaskAlreadyConfiguredException();
            _whenTask = task;
            return task;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Redbridge.ApiTesting.Framework.Extensions;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class ResultValidator<T> : IResultValidator
    {
        public void Validate(T resultResult)
        {
            throw new NotImplementedException();
        }
    }

    public interface IResultValidator
    {

    }

    public class ExpectResultTypeTask<TResultType, TUserSession> : ThenStatementTask<TUserSession>
        where TUserSession : IUserSession<TUserSession> where TResultType : class
    {
        

        private readonly List<ResultValidator<TResultType>> _validators = new List<ResultValidator<TResultType>>();

        public override string TaskName => $"Expect specific result type of {typeof(TResultType).Name}";
        public override string TaskDescription => string.Empty;

        protected override Task OnExecuteAsync(ScenarioContext<TUserSession> context)
        {
            if (!context.Result.Success)
            {
                throw new UnexpectedTestScenarioResultException($"Expected a result item of type {typeof(TResultType).Name}, but instead the scenario failed for an unexpected reason.");

            }

            if (context.Result is SingleScenarioTestResult<TResultType> result)
            {
                foreach (var subValidator in _validators)
                {
                    subValidator.Validate(result.Result);
                }
                return Task.CompletedTask;
            }

            throw new UnexpectedTestScenarioResultException($"Expected a single scenario test result of type {typeof(TResultType).Name}.");
        }

        public void AddValidation(ResultValidator<TResultType> validator)
        {
            if (validator == null) throw new ArgumentNullException(nameof(validator));
            _validators.Add(validator);
        }
    }
}
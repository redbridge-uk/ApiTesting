using System;
using Redbridge.ApiTesting.Framework.Exceptions;

namespace Redbridge.ApiTesting.Framework.Tasks
{
    public class UnexpectedTestScenarioResultException : TestScenarioException
    {
        public UnexpectedTestScenarioResultException() : base()
        {
        }

        public UnexpectedTestScenarioResultException(string message) : base(message)
        {
        }

        public UnexpectedTestScenarioResultException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
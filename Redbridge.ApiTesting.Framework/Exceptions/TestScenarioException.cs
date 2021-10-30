using System;
using System.Runtime.Serialization;

namespace Redbridge.ApiTesting.Framework.Exceptions
{
    [Serializable]
    public class TestScenarioException : Exception
    {
        public TestScenarioException() {}

        public TestScenarioException(string message) : base(message) {}

        public TestScenarioException(string message, Exception inner) : base(message, inner) {}

        protected TestScenarioException (SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}

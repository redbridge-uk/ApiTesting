using System;
using System.Runtime.Serialization;

namespace Redbridge.ApiTesting.Framework.Exceptions
{
    [Serializable]
    public class ScenarioNotExecutedException : TestScenarioException
    {
        public ScenarioNotExecutedException() {}

        public ScenarioNotExecutedException(string message) : base(message) {}

        public ScenarioNotExecutedException(string message, Exception exception) : base(message, exception) {}

        protected ScenarioNotExecutedException(SerializationInfo info, StreamingContext context) : base(info, context) {}
    }
}
using System.IO;

namespace Redbridge.ApiTesting.Framework.Results
{
    public class StreamResult : ScenarioTestResult
    {
        private readonly Stream _stream;

        public StreamResult(Stream stream)
        {
            _stream = stream;
        }

        public override bool Success => _stream != null;
    }
}
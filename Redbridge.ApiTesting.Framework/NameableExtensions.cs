using Redbridge.ApiTesting.Framework.Tasks;

namespace Redbridge.ApiTesting.Framework
{
    public static class NameableExtensions
    {
        public static T Named<T>(this T source, string name) where T: ISessionNamable
        {
            source.SessionName = name;
            return source;
        }
    }
}
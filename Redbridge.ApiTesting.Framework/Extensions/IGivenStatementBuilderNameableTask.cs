using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.Data;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public interface IGivenStatementBuilderNameableTask<TUserSession> : INamed, IGivenStatementBuilder<TUserSession>, ISessionNamable 
        where TUserSession : IUserSession<TUserSession>
    {
        IGivenStatementBuilder<TUserSession> Builder { get; }
    }
}
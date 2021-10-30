using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.Data;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public interface IWhenStatementBuilderNameableTask<TUserSession> : INamed, IWhenStatementBuilder<TUserSession>, ISessionNamable
        where TUserSession : IUserSession<TUserSession>
    {
        IWhenStatementBuilder<TUserSession> Builder { get; }
    }
}
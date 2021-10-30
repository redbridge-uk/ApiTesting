using Redbridge.ApiTesting.Framework.Tasks.Whens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public static class WhenStatementBuilderExtensions
    {
        public static IWhenStatementBuilder<TUserSession> LoggedIn<TUserSession>(this IWhenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        {
            builder.SetTask(new ConnectCurrentSessionTask<TUserSession>());
            return builder;
        }
    }
}
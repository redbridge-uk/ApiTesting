using Redbridge.ApiTesting.Framework.Tasks.Givens;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public static class ScenarioExtensions
    {
        public static IGivenStatementBuilder<TUserSession> AnAdministratorUser<TUserSession> (this IGivenStatementBuilder<TUserSession> builder) 
            where TUserSession : IUserSession<TUserSession>
        {
            builder.AddTask(new SetAdministratorCurrentContextGivenTask<TUserSession>());
            return builder;
        }

        public static IGivenStatementBuilder<TUserSession> AnAnonymousUser<TUserSession>(this IGivenStatementBuilder<TUserSession> builder)
            where TUserSession : IUserSession<TUserSession>
        {
            builder.AddTask(new SetAnonymousCurrentContextGivenTask<TUserSession>());
            return builder;
        }
    }
}

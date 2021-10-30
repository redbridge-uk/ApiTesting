using System;
using Redbridge.ApiTesting.Framework.Extensions;

namespace Redbridge.ApiTesting.Framework.Tasks.Thens
{
    public static class ThenStatementBuilderExtensions
    {
        public static Tuple<IThenStatementBuilder<TUserSession>, SessionAuthenticatedAssertion<TUserSession>> ExpectAnAuthenticatedUser<TUserSession>(this IThenStatementBuilder<TUserSession> builder) 
            where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            var task = builder.AddTask(new SessionAuthenticatedAssertion<TUserSession>());
            return new Tuple<IThenStatementBuilder<TUserSession>, SessionAuthenticatedAssertion<TUserSession>>(builder, task);
        }
    }
}

using System;
using System.Net;
using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.Exceptions;

namespace Redbridge.ApiTesting.Framework.Extensions
{
    public static class ThenStatementBuilderExtensions
    {
        public static IThenStatementBuilder<TUserSession> ExpectSuccess<TUserSession>(this IThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectSuccessTask<TUserSession>());
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectException<TException, TUserSession>(this IThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        where TException: Exception
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectExceptionTask<TUserSession, TException>());
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectValidationException<TUserSession>(this IThenStatementBuilder<TUserSession> builder, string message = null) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectExceptionTask<TUserSession, ValidationException>() { ExpectedMessage = message } );
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectUserNotAuthorized<TUserSession>(this IThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectExceptionTask<TUserSession, UserNotAuthorizedException>());
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectUserNotAuthenticated<TUserSession>(this IThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectExceptionTask<TUserSession, UserNotAuthenticatedException>());
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectAtLeastOneResult<TUserSession>(this IThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectAtLeastOneResultTask<TUserSession>());
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectAtLeastResult<TUserSession>(this IThenStatementBuilder<TUserSession> builder, int minimum) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectAtLeastResultTask<TUserSession>(minimum));
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectResult<TResult, TUserSession>(this IThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession> where TResult : class
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectResultTypeTask<TResult, TUserSession>());
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectExactlyResult<TUserSession>(this IThenStatementBuilder<TUserSession> builder, int resultsExpected) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectExactlyResultTask<TUserSession>(resultsExpected));
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectZeroResults<TUserSession>(this IThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectZeroResultsTask<TUserSession>());
            return builder;
        }

        public static IThenStatementBuilder<TUserSession> ExpectHttpResult<TUserSession>(this IThenStatementBuilder<TUserSession> builder, HttpStatusCode status) where TUserSession : IUserSession<TUserSession>
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.AddTask(new ExpectHttpResultTask<TUserSession>(status));
            return builder;
        }

        public static ThenStatementBuilder<TUserSession> And<TUserSession>(this ThenStatementBuilder<TUserSession> builder) where TUserSession : IUserSession<TUserSession>
        {
            return builder;
        }
    }
}
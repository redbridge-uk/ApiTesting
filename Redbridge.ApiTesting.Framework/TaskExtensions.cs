using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Redbridge.Threading;

namespace Redbridge.ApiTesting.Framework
{
    public static class TaskExtensions
    {
        public static void ExpectUserExceededSubscriptionException(this Task task)
        {
            try
            {
                task.WaitAndUnwrapException();
                Assert.Fail("Expected this call to throw a subscription exceeded exception.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Expected this call to throw a ExceededDailyLogEntryLimitException instead we received a {0}", ex.GetBaseException().GetType().Name);
            }
        }
    }
}

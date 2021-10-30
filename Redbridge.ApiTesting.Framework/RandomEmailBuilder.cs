using System;

namespace Redbridge.ApiTesting.Framework
{
    public class RandomEmailBuilder : IRandomEmailBuilder
    {
        public RandomEmailBuilder()
        {
        }

        public string Create()
        {
            var randomAddress = Guid.NewGuid().ToString().Replace("-", "");
            var randomFullAddress = $"easilog.integration+{randomAddress}@gmail.com";
            return randomFullAddress;
        }
    }
}
using System;
using System.Collections.ObjectModel;

namespace Redbridge.ApiTesting.Framework
{
    public class UserSessionCollection<TUserSession> 
        : KeyedCollection<string, TUserSession>, IDisposable
    where TUserSession: IUserSession<TUserSession>, IDisposable
    {
        protected override string GetKeyForItem(TUserSession item)
        {
            return item.Name;
        }

        public void Dispose()
        {
            foreach (var session in this)
            {
                session.Dispose();
            }
        }
    }
}

using System;
using System.Threading.Tasks;

namespace Redbridge.ApiTesting.Framework
{
    public interface IUserSession : IDisposable
    {
        string Name { get; }
        bool IsConnected { get; }
    }

    public interface IUserSession<TUserSession> : IUserSession
    {
        Task<TUserSession> ConnectAsync();
        Task DisconnectAsync();
    }
}
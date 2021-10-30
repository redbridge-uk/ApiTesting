using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Redbridge.ApiTesting.Framework;
using Redbridge.ApiTesting.Framework.Tasks;
using Redbridge.ApiTesting.Framework.Tasks.Thens;

namespace Redbridge.ApiTesting.Azure.Tasks.Then
{
    public abstract class SignalRMonitorTask<TUserSession> : ThenScenarioTask<TUserSession> where TUserSession : IUserSession<TUserSession>, IMonitorTask<TUserSession>
    {
        protected SignalRMonitorTask()
        {
        }

        public Uri HubUri { get; set; }

        protected HubConnection Hub { get; private set; }

        public async Task StartMonitorAsync()
        {
            Hub = new HubConnectionBuilder()
               .WithAutomaticReconnect()
               .AddJsonProtocol()
               .WithUrl(HubUri)
               .Build();

            await Hub.StartAsync();
        }

        public async Task StopMonitorAsync()
        {
            await Hub.StopAsync();
        }
    }
}
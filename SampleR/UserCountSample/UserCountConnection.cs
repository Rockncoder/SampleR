using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SampleR.UserCount
{
    public class UserCountConnection : PersistentConnection
    {
        public static int _userCount;

        protected override Task OnConnected(IRequest request, string connectionId)
        {
            _userCount += 1;
            this.Connection.Broadcast(_userCount);
            return base.OnConnected(request, connectionId);
        }

        protected override Task OnDisconnected(IRequest request, string connectionId)
        {
            _userCount -= 1;
            this.Connection.Broadcast(_userCount);
            return base.OnDisconnected(request, connectionId);
        }
    }
}
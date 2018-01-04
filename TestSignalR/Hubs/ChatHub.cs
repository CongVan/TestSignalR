using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Threading.Tasks;

namespace TestSignalR.Hubs
{
    
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void Send(string name, string message)
        {
            Clients.All.addNewMessageToPage(name, message);
            Clients.Client("id").sendTo(name, message);
        }

        //public void SendPrivateMessage(string toUserId, string message)
        //{

        //    string fromUserId = Context.ConnectionId;

        //    var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == toUserId);
        //    var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == fromUserId);

        //    if (toUser != null && fromUser != null)
        //    {
        //        // send to 
        //        Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserName, message);

        //        // send to caller user
        //        Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserName, message);
        //    }

        //}

        //private readonly static ConnectionMapping<string> _connections =
        //   new ConnectionMapping<string>();


        //public static void PushToAllUsers(string message, ChatHub hub)
        //{
        //    IHubConnectionContext<dynamic> clients = GetClients(hub);
        //    clients.All.addAnnouncement(message);
        //}
        ///// <summary>
        ///// Push to a specific user
        ///// </summary>
        ///// <param name="who"></param>
        ///// <param name="message"></param>
        //public static void PushToUser(string who, string message, ChatHub hub)
        //{
        //    IHubConnectionContext<dynamic> clients = GetClients(hub);
        //    foreach (var connectionId in _connections.GetConnections(who))
        //    {
        //        clients.Client(connectionId).addChatMessage(message);
        //    }
        //}

        ///// <summary>
        ///// Push to list users
        ///// </summary>
        ///// <param name="who"></param>
        ///// <param name="message"></param>
        //public static void PushToUsers(string[] whos, string message, ChatHub hub)
        //{
        //    IHubConnectionContext<dynamic> clients = GetClients(hub);
        //    for (int i = 0; i < whos.Length; i++)
        //    {
        //        var who = whos[i];
        //        foreach (var connectionId in _connections.GetConnections(who))
        //        {
        //            clients.Client(connectionId).addChatMessage(message);
        //        }
        //    }

        //}
        //private static IHubConnectionContext<dynamic> GetClients(ChatHub teduShopHub)
        //{
        //    if (teduShopHub == null)
        //        return GlobalHost.ConnectionManager.GetHubContext<ChatHub>().Clients;
        //    else
        //        return teduShopHub.Clients;
        //}

        ///// <summary>
        ///// Connect user to hub
        ///// </summary>
        ///// <returns></returns>
        //public override Task OnConnected()
        //{
        //    _connections.Add(Context.User.Identity.Name, Context.ConnectionId);

        //    return base.OnConnected();
        //}

        //public override Task OnDisconnected(bool stopCalled)
        //{
        //    _connections.Remove(Context.User.Identity.Name, Context.ConnectionId);

        //    return base.OnDisconnected(stopCalled);
        //}

        //public override Task OnReconnected()
        //{
        //    if (!_connections.GetConnections(Context.User.Identity.Name).Contains(Context.ConnectionId))
        //    {
        //        _connections.Add(Context.User.Identity.Name, Context.ConnectionId);
        //    }

        //    return base.OnReconnected();
        //}
    }
}
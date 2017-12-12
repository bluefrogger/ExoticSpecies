/*
    Author: Alex Yoo
    Content: Hub used in views:
        ~/Home/Index.cshtml
        ~/Videos/Index.cshtml
    Usage: <script>var myChatHubName = $.connection.chatHub</script>
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ExoticSpeciesOfTheNorth.Hubs
{
    public class ChatHub : Hub
    {
        public void SendNotification(string myGroup, string myNotification)
        {
            Clients.Group(myGroup).ShowNotification(myNotification);
        }

        public void SendMessage(string myGroup, string myMessage)
        {
            Clients.Group(myGroup).ShowMessage(myMessage);
        }

        public void AddToGroup(string myGroup)
        {
            Groups.Add(Context.ConnectionId, myGroup);
        }

        public void RemoveFromGroup(string myGroup)
        {
            Groups.Remove(Context.ConnectionId, myGroup);
        }

        public void MoveShape(int x, int y)
        {
            Clients.Others.ShapeMoved(x, y);
        }

        public void SendPostit(string message)
        {
            Clients.Others.ShowPostit(message);
        }
    }
}

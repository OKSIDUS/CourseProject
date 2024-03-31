using Microsoft.AspNetCore.SignalR;

namespace UserCollection.WebAPP.Hubs
{
    public class CommentHub : Hub
    {
        public async Task SendComment(string userName, string comment)
        {
            await Clients.All.SendAsync("ReceiveComment", userName, comment);
        }

    }
}

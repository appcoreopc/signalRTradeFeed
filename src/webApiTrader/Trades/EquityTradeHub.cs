using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace webApiTrader.Trades
{
    public class EquityTradeHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("receivemessage", user, message);
        }
    }
}

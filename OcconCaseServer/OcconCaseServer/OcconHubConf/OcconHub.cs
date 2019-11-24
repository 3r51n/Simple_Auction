using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Occon.Server.Api.DbStorage;
using Occon.Server.Api.Models;




namespace Occon.Server.Api.HubConfig
{
    public class OcconHub : Hub
    {
        public async Task SendPlaceBid(string name, decimal price, int id)
        {
            OcconModel data = DbManager.SetData(name, price, id);
            await Clients.All.SendAsync("ClientToData", data);
        }

        public async Task RestoreData()
        {
            OcconModel data = DbManager.GetData(true);
            await Clients.All.SendAsync("RestoreData", data);
        }
    }
}


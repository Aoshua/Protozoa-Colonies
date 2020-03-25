using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ProtozoaColonies.Models;
using System;


/**
 * TODO:
 * Stop using magic strings
 * Move PcManager functions to void, use only SerializeBoard() to return
 * Fix the timer issues
 */
namespace ProtozoaColonies.Hubs
{
    public class PcHub : Hub
    {

        public async Task SetCell(string color, byte x, byte y)
        {
            PcManager.SetCell(color, x, y);
            await Clients.All.SendAsync("SendBoard", PcManager.SerializeBoard());
        }

        public async Task NextState()
        {
            PcManager.NextState();
            await Clients.All.SendAsync("SendBoard", PcManager.SerializeBoard());
        }

        public async Task ClearBoard()
        {
            PcManager.ClearBoard();
            await Clients.All.SendAsync("SendBoard", PcManager.SerializeBoard());
        }

        public async Task SetAuto(bool auto, int seconds)
        {
            PcManager.Auto(auto, seconds);
            await Clients.All.SendAsync("ServerMsg", "Timer at rate of " + seconds + " " + auto);
        }
    }
}
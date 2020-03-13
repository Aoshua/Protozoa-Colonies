using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ProtozoaColonies.Models;
using System.Timers;
using System;


namespace ProtozoaColonies.Hubs
{
    public class PcHub : Hub
    {
        private static System.Timers.Timer aTimer;

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

        public async Task SetAuto(bool auto, int seconds)
        {
            
            aTimer = new System.Timers.Timer(seconds * 1000);
            aTimer.Elapsed += ATimer_Elapsed;
            aTimer.AutoReset = true;
            aTimer.Enabled = auto;

            await Clients.All.SendAsync("ServerMsg", "Timer at rate of " + seconds + " " + auto);
        }

        private async void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await NextState();
        }
    }
}
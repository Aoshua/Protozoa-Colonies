using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ProtozoaColonies.Hubs;
using ProtozoaColonies.Models;
using System.Timers;


namespace ProtozoaColonies.Models
{
    public class PcTimer
    {
        private readonly IHubContext<PcHub> _hubContext;
        private System.Timers.Timer aTimer;

        public PcTimer(IHubContext<PcHub> hubContext)
        {
            this._hubContext = hubContext;
            aTimer = new Timer();
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = false;
            aTimer.AutoReset = true;
        }

        public void StartTimer(int sec)
        {
            const short SEC_TO_MS = 1000;
            aTimer.Interval = sec * SEC_TO_MS;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void StopTimer()
        {
            aTimer.AutoReset = false;
            aTimer.Enabled = false;
        }

        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            await _hubContext.Clients.All.SendAsync("SendBoard", PcManager.NextState());
        }
    }
}

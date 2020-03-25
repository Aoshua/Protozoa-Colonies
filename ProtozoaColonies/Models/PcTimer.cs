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
        private static System.Timers.Timer aTimer;

        public PcTimer(IHubContext<PcHub> hubContext)
        {
            this._hubContext = hubContext;
        }

        public void SetTimer(int ms)
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(ms);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
        }

        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            await _hubContext.Clients.All.SendAsync("SendBoard", PcManager.NextState());
        }

        public void StartTimer()
        {
            aTimer.Enabled = true;
        }

        public void StopTimer()
        {
            aTimer.Enabled = false;
        }
    }
}

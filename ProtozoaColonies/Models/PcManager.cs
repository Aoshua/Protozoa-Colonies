using System.Collections.Generic;
using ProtozoaColonies.Hubs;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR;

namespace ProtozoaColonies.Models
{
    public static class PcManager
    {
        private static PitriDish dish;
        private static PcTimer pcTimer;

        static PcManager()
        {
            dish = new PitriDish();
            dish.NewDish(30);
        }

        public static void CreateTimer(IHubContext<PcHub> hubContext)
        {
            pcTimer = new PcTimer(hubContext);
        }

        public static void ClearBoard()
        {
            dish.CleanDish();
        }

        public static string SetCell(string color, int x, int y)
        {
            dish.PlaceCell(x, y, color);
            return dish.ShareDish();
        }

        public static string NextState()
        {
            dish.CheckDish();
            return dish.ShareDish();
        }

        public static void Auto(bool auto, int seconds)
        {
            const int SEC_TO_MS = 1000;
            pcTimer.SetTimer(seconds * SEC_TO_MS);
            if (auto)
                pcTimer.StartTimer();
            else
                pcTimer.StopTimer();
        }

        public static string SerializeBoard()
        {
            return dish.ShareDish();
        }
    }
}
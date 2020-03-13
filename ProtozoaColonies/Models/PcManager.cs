using System.Collections.Generic;
using ProtozoaColonies.Hubs;
using System;
using Newtonsoft.Json;

namespace ProtozoaColonies.Models
{
    public static class PcManager
    {
        private static PitriDish dish;
        private static PcHub pcHub;

        static PcManager()
        {
            dish = new PitriDish();
            dish.NewDish(32);
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

        public static void Auto()
        {
            
        }

        public static string SerializeBoard()
        {
            return dish.ShareDish();
        }
    }
}
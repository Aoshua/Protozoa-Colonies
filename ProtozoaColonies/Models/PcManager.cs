using System.Collections.Generic;
using ProtozoaColonies.Hubs;
using System;

namespace ProtozoaColonies.Models
{
    public static class PcManager
    {
        private static PetriDish dish;
        private static PcHub pcHub;

        public static List<Cell> SetCell(string color, int x, int y)
        {
            dish.PlaceCell(x, y, color);
            return dish.ShareDish();
        }

        public static List<Cell> NextState()
        {
            dish.CheckDish();
            return dish.ShareDish();
        }

        public static void Auto()
        {
            
        }
    }
}
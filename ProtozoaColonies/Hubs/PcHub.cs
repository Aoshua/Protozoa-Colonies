using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ProtozoaColonies.Hubs
{
    public class PcHub : Hub
    {
        public async Task SetCell(string color, byte x, byte y)
        {
            // check that table has init
            // if table init, set cell in table
            // push table back to all clients
        }

        public async Task NextState()
        {
            // push table back to all clients
        }

        public async Task SetAuto(bool auto, byte speed)
        {
            // init a timer 
            // push back to clients
        }
    }
}
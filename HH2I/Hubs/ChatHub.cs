namespace House2Invest.Hubs
{
    using Microsoft.AspNetCore.SignalR;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;

    public class ChatHub : Hub
    {
        private static HashSet<string> CurrentConnections = new HashSet<string>();

        
    }
}


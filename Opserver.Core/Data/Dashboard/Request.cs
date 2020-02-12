using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchange.Opserver.Data.Dashboard
{
    // Carmelo
    public partial class Request
    {
        public string Server { get; internal set; }
        public string ClientIp { get; internal set; }
        public string Url { get; internal set; }
        public int TimeElapsed { get; internal set; }
    }
}

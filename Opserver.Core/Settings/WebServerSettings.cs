using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackExchange.Opserver
{
    public class WebServerSettings : ModuleSettings
    {
        public override bool Enabled => !Category.IsNullOrEmpty() || !Category.IsNullOrEmpty() || TimeElapsed>0;

        public string Category { get; set; }

        public string AppPool { get; set; }

        public int TimeElapsed { get; set; }
    }
}

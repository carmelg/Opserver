using CommandLine;

namespace RequestAppPool
{
    class Options
    {
        [Option('i', "ip", Required = true, HelpText = "Ip del server IIS")]
        public string Ip { get; set; }

        [Option('p', "pool", Required = true, HelpText = "Application Pool da monitorare (es. Recupera)")]
        public string AppPool { get; set; }

        [Option('t', "timeElapsed", Default = 1000, Required = false, HelpText = "Time elapsed delle request in millisecondi da visualizzare")]
        public int TimeElapsedFilter { get; set; }
    }
}

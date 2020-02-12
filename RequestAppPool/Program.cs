using System;
using System.Collections.Generic;
using CommandLine;
using Microsoft.Web.Administration;

namespace RequestAppPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(Run)
                .WithNotParsed(HandleParseError);
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            if (errs.IsVersion())
            {
                //Console.WriteLine("Version Request");
                return;
            }

            if (errs.IsHelp())
            {
                Console.WriteLine("Esempio : RequestAppPool -i 10.10.20.171 -p Recupera -t 1");
                return;
            }

            Console.WriteLine("Parser Fail");
        }

        private static void Run(Options opts)
        {
            try
            {
                var serverManager = ServerManager.OpenRemote(opts.Ip);

                if (serverManager == null)
                {
                    Console.WriteLine($"Non è stato possibile accedere al server {opts.Ip}");
                    Environment.Exit(-1);
                }

                var appPool = serverManager.ApplicationPools[opts.AppPool];

                if (appPool == null)
                {
                    Console.WriteLine($"Non è stato possibile accedere all'application pool {opts.AppPool} del server {opts.Ip}");
                    Environment.Exit(-1);
                }

                foreach (var workerProcess in appPool.WorkerProcesses)
                {
                    foreach (var request in workerProcess.GetRequests(opts.TimeElapsedFilter))
                    {
                        var t = TimeSpan.FromMilliseconds(request.TimeElapsed);

                        Console.WriteLine($"{request.ClientIPAddr}\t{request.TimeElapsed}\t{request.Url}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }
        }
    }
}

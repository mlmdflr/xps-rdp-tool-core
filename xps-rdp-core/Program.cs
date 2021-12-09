using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xps_rdp_core
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        static void Help()
        {
            Console.WriteLine("optional:");
            Console.WriteLine("fname | opacity | is_u_icon");
            Console.WriteLine("required:");
            Console.WriteLine("host | username | password");
        }

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            if (args.Length == 0)
            {
                Help();
                Environment.Exit(0);
                return;
            }
            var arguments = new Dictionary<string, string>();
            foreach (string argument in args)
            {
                int idx = argument.IndexOf('=');
                if (idx > 0)
                    arguments[argument.Substring(0, idx)] = argument.Substring(idx + 1);
            }
            if (!arguments.ContainsKey("host"))
            {
                Console.WriteLine("[X] Error: A host is required");
                Help();
                Environment.Exit(0);
                return;
            }
            else
            {
                if (arguments["host"].Contains(":"))
                {
                    string[] hosts = arguments["host"].Split(':');
                    arguments["host"] = hosts[0];
                    arguments["port"] = hosts[1];
                }
            }
            if (arguments.ContainsKey("username"))
            {
                string username = arguments["username"];
                string fname = string.Empty;
                string password = string.Empty;

                if (!arguments.ContainsKey("password"))
                {
                    Console.WriteLine("[X] Error: A password is required");
                    Help();
                    Environment.Exit(0);
                    return;
                }
                else
                {
                    password = arguments["username"];
                }
                if (!arguments.ContainsKey("fname"))
                {
                    fname = username;
                }
                else
                {
                    fname = arguments["fname"]; ;
                }
                if (arguments.ContainsKey("port") && arguments.ContainsKey("opacity") && arguments.ContainsKey("is_u_icon"))
                {
                    if (!int.TryParse(arguments["port"], out int p))
                    {
                        Console.WriteLine("[X] Error: A port is int");
                        Environment.Exit(0);
                        return;

                    }
                    if (!double.TryParse(arguments["opacity"], out double o))
                    {
                        Console.WriteLine("[X] Error: A opacity is double");
                        Environment.Exit(0);
                        return;

                    }
                    if (!bool.TryParse(arguments["is_u_icon"], out bool i))
                    {
                        Console.WriteLine("[X] Error: A is_u_icon is bool");
                        Environment.Exit(0);
                        return;


                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], p, arguments["username"], arguments["password"], o, i));
                }
                else if (arguments.ContainsKey("opacity") && arguments.ContainsKey("is_u_icon"))
                {
                    if (!double.TryParse(arguments["opacity"], out double o))
                    {
                        Console.WriteLine("[X] Error: A opacity is double");
                        Environment.Exit(0);
                        return;

                    }
                    if (!bool.TryParse(arguments["is_u_icon"], out bool i))
                    {
                        Console.WriteLine("[X] Error: A is_u_icon is bool");
                        Environment.Exit(0);
                        return;

                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], arguments["username"], arguments["password"], o, i));
                }
                else if (arguments.ContainsKey("port") && arguments.ContainsKey("is_u_icon"))
                {
                    if (!int.TryParse(arguments["port"], out int p))
                    {
                        Console.WriteLine("[X] Error: A port is int");
                        Environment.Exit(0);
                        return;
                    }
                    if (!bool.TryParse(arguments["is_u_icon"], out bool i))
                    {
                        Console.WriteLine("[X] Error: A is_u_icon is bool");
                        Environment.Exit(0);
                        return;
                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], p, arguments["username"], arguments["password"], i));
                }
                else if (arguments.ContainsKey("port") && arguments.ContainsKey("opacity"))
                {
                    if (!int.TryParse(arguments["port"], out int p))
                    {
                        Console.WriteLine("[X] Error: A port is int");
                        Environment.Exit(0);
                        return;
                    }
                    if (!double.TryParse(arguments["opacity"], out double o))
                    {
                        Console.WriteLine("[X] Error: A opacity is double");
                        Environment.Exit(0);
                        return;
                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], p, arguments["username"], arguments["password"], o));
                }
                else if (arguments.ContainsKey("port"))
                {
                    if (!int.TryParse(arguments["port"], out int p))
                    {
                        Console.WriteLine("[X] Error: A port is int");
                        Environment.Exit(0);
                        return;
                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], p, arguments["username"], arguments["password"]));
                }
                else if (arguments.ContainsKey("opacity"))
                {
                    if (!double.TryParse(arguments["opacity"], out double o))
                    {
                        Console.WriteLine("[X] Error: A opacity is double");
                        Environment.Exit(0);
                        return;
                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], arguments["username"], arguments["password"], o));
                }
                else if (arguments.ContainsKey("is_u_icon"))
                {
                    if (!bool.TryParse(arguments["is_u_icon"], out bool i))
                    {
                        Console.WriteLine("[X] Error: A is_u_icon is bool");
                        Environment.Exit(0);
                        return;
                    }
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], arguments["username"], arguments["password"], i));
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1(fname, arguments["host"], arguments["username"], arguments["password"]));
                }
            }
            else
            {
                Console.WriteLine("[X] Error: A username is required");
                Help();
                Environment.Exit(0);
                return;
            }
        }
    }
}

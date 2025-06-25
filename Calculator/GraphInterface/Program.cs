using AnalaizerClassLibrary;

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GraphInterface
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FreeConsole();

        [DllImport("kernel32.dll")]
        private static extern bool AttachConsole(int dwProcessId);

        private const int _aTTACHPARENTPROCESS = -1;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            int argCount = args == null ? 0 : args.Length;
            if (argCount > 0)
            {
                // redirect console output to parent process;
                // must be before any calls to Console.WriteLine()
                AttachConsole(_aTTACHPARENTPROCESS);

                AnalaizerClass.Expression = args[0];

                int length = Console.CursorLeft;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.WriteLine(new string(' ', length));
                Console.SetCursorPosition(0, Console.CursorTop);

                Console.WriteLine("Expression:" + AnalaizerClass.Expression);
                string result = AnalaizerClass.Estimate();

                ConsoleColor color = ConsoleColor.Green;

                if (result.StartsWith("&"))
                {
                    result = result.TrimStart('&');
                    color = ConsoleColor.Red;
                }
                else
                {
                    result = result + Environment.NewLine + "Error: 0";
                }

                ConsoleColor current = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("Result: " + result);
                Console.ForegroundColor = current;

                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

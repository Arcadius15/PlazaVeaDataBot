using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlazaVea.Clases
{
    public static class LoggingService
    {
        public static async Task LogAsync(string mensaje,string svr, Exception exc = null)
        {
            
            if (exc != null)
            {
                await Append(GetSeverity(svr), GetConsoleColor(svr));
                await Append($" {exc.Message}\n", GetConsoleColor("errorinfo"));
            }
            else
            {
                await Append(GetSeverity(svr), GetConsoleColor(svr));
                await Append($" {mensaje}\n", GetConsoleColor(svr));
            }


        }

        private static async Task Append(string mensaje, ConsoleColor color)
        {
            await Task.Run(() => {
                Console.ForegroundColor = color;
                Console.Write(mensaje);
            });
        }

        public static string GetSeverity(string svr)
        {
            switch (svr.ToLower())
            {
                case "error":
                    return "[ERROR]";
                case "info":
                    return "[INFO]";
                case "warn":
                    return "[WARN]";
                case "data":
                    return "[DATA]";
                case "head":
                    return "[HEADER]";
                default:
                    return "[DEBUG]";
            }
        }

        private static ConsoleColor GetConsoleColor(string severity)
        {
            switch (severity.ToLower())
            {
                case "error":
                    return ConsoleColor.Red;
                case "warn":
                    return ConsoleColor.Yellow;
                case "info":
                    return ConsoleColor.Green;
                case "data":
                    return ConsoleColor.Blue;
                case "head":
                    return ConsoleColor.Magenta;
                case "errorinfo":
                    return ConsoleColor.DarkRed;
                default: return ConsoleColor.White;
            }
        }
    }
}

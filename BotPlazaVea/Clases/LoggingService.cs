using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPlazaVea.Clases
{
    public static class LoggingService
    {
        public static async Task LogAsync(string mensaje,TipoCodigo svr, Exception exc = null)
        {
            
            if (exc != null)
            {
                await Append(GetSeverity(svr), GetConsoleColor(svr));
                await Append($" {exc.Message}\n", GetConsoleColor(TipoCodigo.ERROR_INFO));
            }
            else
            {
                await Append(GetSeverity(svr), GetConsoleColor(svr));
                await Append($" {mensaje}\n", GetConsoleColor(TipoCodigo.NORMAL));
            }


        }

        private static async Task Append(string mensaje, ConsoleColor color)
        {
            await Task.Run(() => {
                Console.ForegroundColor = color;
                Console.Write(mensaje);
            });
        }

        public static string GetSeverity(TipoCodigo svr)
        {
            switch (svr)
            {
                case TipoCodigo.ERROR:
                    return "[ERROR]";
                case TipoCodigo.INFO:
                    return "[INFO]";
                case TipoCodigo.WARN:
                    return "[WARN]";
                case TipoCodigo.DATA:
                    return "[DATA]";
                case TipoCodigo.HEAD:
                    return "[HEADER]";
                default:
                    return "[DEBUG]";
            }
        }

        private static ConsoleColor GetConsoleColor(TipoCodigo severity)
        {
            switch (severity)
            {
                case TipoCodigo.ERROR:
                    return ConsoleColor.Red;
                case TipoCodigo.WARN:
                    return ConsoleColor.Yellow;
                case TipoCodigo.INFO:
                    return ConsoleColor.Green;
                case TipoCodigo.DATA:
                    return ConsoleColor.Blue;
                case TipoCodigo.HEAD:
                    return ConsoleColor.Magenta;
                case TipoCodigo.ERROR_INFO:
                    return ConsoleColor.DarkRed;
                case TipoCodigo.NORMAL:
                    return ConsoleColor.Gray;
                default: return ConsoleColor.White;
            }
        }
    }
}

using BotPlazaVea.Clases;
using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BotPlazaVea
{
    class Program
    {
        static async Task Main(string[] args) => await new Plantillas().obtenerUrls();
    }
}

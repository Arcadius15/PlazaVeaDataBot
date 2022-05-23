using PuppeteerSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BotPlazaVea.Clases
{
    public class Plantillas
    {

        string url = "https://www.plazavea.com.pe/";
        string brave = @"C:\Program Files\BraveSoftware\Brave-Browser\Application\brave.exe";

        private static List<string> categorias = new List<string>
        {
            "muebles","tecnologia","calzado","deportes"
        };

        public async Task obtenerProductos()
        {
            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();

            await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true,
                ExecutablePath = brave,
                Timeout = 3000000,
                LogProcess = true
            });

            await using var page = await browser.NewPageAsync();

            int pagina = 0;
            foreach (var cat in categorias)
            {
                await page.GoToAsync(url+ cat);

                var waiting =await  page.WaitForSelectorAsync(".pagination__item.page-number");

                if (waiting!=null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("[Pagina Cargada]");
                }

                var paginaRes = await page.EvaluateFunctionAsync("()=>{" +
                    "const a = document.querySelectorAll('.pagination__item.page-number');" +
                    "const res = [];" +
                    "for(let i=0; i<a.length; i++)" +
                    "   res.push(a[i].innerHTML);" +
                    "return res.slice(-1)[0];" +
                    "}");

                pagina= int.Parse(paginaRes.ToString());

                

                for (int i = 1; i <= pagina; i++)
                {
                    await page.GoToAsync(url + cat + $"?page={i}");
                    await page.WaitForSelectorAsync(".ShowcaseGrid");
                    try
                    {
                        await page.WaitForSelectorAsync(".Showcase__content");
                        var wait = await page.WaitForFunctionAsync("()=>{return " +
                                                "document.querySelectorAll('.ShowcaseGrid')[2].childNodes[1].childNodes.length>0;" +
                                                "return;" +
                                                "}");
                        var estado = wait.JsonValueAsync().Result;
                    }
                    catch (Exception ex)
                    {
                        await LoggingService.LogAsync("", "error", ex);
                    }
                    
                    try
                    {
                        var result = await page.EvaluateFunctionAsync("()=>{" +
                            "const b = [];" +
                            "document.querySelectorAll('.ShowcaseGrid')[2].childNodes[1].childNodes.forEach(x => " +
                            "b.push(x.childNodes[0].childNodes[1].childNodes[1].childNodes[0].href));" +
                            "return b;" +
                            "}");
                        foreach (var item in result)
                        {
                            await LoggingService.LogAsync("Url Obtenido","head");
                            await LoggingService.LogAsync(item.ToString(), "data");
                            //await using var pag = await browser.NewPageAsync();
                            //await pag.GoToAsync(item.ToString());
                            //await pag.CloseAsync();

                        }
                    }
                    catch (Exception ex)
                    {
                        await LoggingService.LogAsync("", "error",ex);
                    }
                }

            }
            
        }
    }
}

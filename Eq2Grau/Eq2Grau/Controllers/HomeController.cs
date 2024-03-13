using System.Diagnostics;
using Eq2Grau.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eq2Grau.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
/// <summary>
/// Este método é a 'porta de entrada' no programa
/// </summary>
/// <param name="A">coeficiente do parâmetro x^2</param>
/// <param name="B">coeficiente do parâmetro x</param>
/// <param name="C">coeficiente do parâmetro independente</param>
/// <returns></returns>
        public IActionResult Index(string A, string B, string C)
        {
            /* ALGORITMO
             * 1.- determinar se os parâmetros fornecidos são números
             *     se sim,
             *        2.- determinar se A != 0
             *            se não, 
             *               enviar mensagem de erro para o utilizador
             *            se sim,
             *               3.- calcular as raízes
             *                   x1, x2 = (-b +/- sqrt(b^2 - 4ac)) / (2a)
             *                   3.1 - calcular as raízes reais
             *                   3.2 - calcular as raízes complexas, se existirem
             *                   3.3 - enviar respostas para o utilizador
             *     se não,
             *        enviar mensagem de erro para o utilizador
             */

            // vars. auxiliares

            double auxA = 0, auxB = 0, auxC = 0;



            // 1.
            if (string.IsNullOrWhiteSpace(A) || string.IsNullOrWhiteSpace(B) || string.IsNullOrWhiteSpace(C))
            {
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "Os parâmetros A, B e C não podem ser nulos";

                // devolver controlo à View
                return View();
            }

            // 1.
            if (!double.TryParse(A, out auxA))
            {
                // o A não é número.
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "Os parâmetros A tem que ser um número";

                // devolver controlo à View
                return View();
            }

            // 1.
            if (!double.TryParse(B, out auxB))
            {
                // o B não é número.
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "Os parâmetros B tem que ser um número";

                // devolver controlo à View
                return View();
            }

            // 1.
            if (!double.TryParse(C, out auxC))
            {
                // o C não é número.
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "Os parâmetros C tem que ser um número";

                // devolver controlo à View
                return View();
            }


            // 2.
            if (auxA == 0)
            {
                // o A é ZERO.
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "O parâmetro A nãooo pode ser 0 (zero)";

                // devolver controlo à View
                return View();
            }


            // 3.
            double delta = Math.Pow(auxB, 2) - 4 * auxA * auxC;
            // 3.1
            if (delta > 0)
            {
                string x1 = Math.Round((-auxB + Math.Sqrt(delta)) / 2 / auxA, 2) + "";
                string x2 = Math.Round((-auxB - Math.Sqrt(delta)) / 2 / auxA, 2) + "";
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "Existem duas raízes reais distintas";
                ViewBag.X1 = x1;
                ViewBag.X1 = x2;

                // devolver controlo à View
                return View();
            }

            if (delta == 0)
            {
                string x = Math.Round(-auxB / 2 / auxA, 2) + "";

                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "Existem duas raízes reais, mas iguais";
                ViewBag.X1 = x;
                ViewBag.X1 = x;

                // devolver controlo à View
                return View();
            }

            if (delta < 0)
            {
                string x1 = Math.Round((-auxB) / 2 / auxA, 2) + " + " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
                string x2 = Math.Round((-auxB) / 2 / auxA, 2) + " - " + Math.Round(Math.Sqrt(-delta) / 2 / auxA, 2) + " i";
                // enviar mensagem para o utilizador

                ViewBag.Mensagem = "Existem duas raízes complexas conjugadas";
                ViewBag.X1 = x1;
                ViewBag.X1 = x2;

                // devolver controlo à View
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Acción para hacer los cálculos
        [HttpPost]
        public IActionResult Calcular(double numero1, double numero2, string operacion, string numero)
        {
            if (!string.IsNullOrEmpty(numero))
            {
                if (numero1 == 0)
                    numero1 = double.Parse(numero);
                else
                    numero1 = double.Parse(numero1.ToString() + numero);
            }

            double resultado = 0;

            switch (operacion)
            {
                case "sumar":
                    resultado = numero1 + numero2;
                    break;
                case "restar":
                    resultado = numero1 - numero2;
                    break;
                case "multiplicar":
                    resultado = numero1 * numero2;
                    break;
                case "dividir":
                    if (numero2 == 0)
                    {
                        ViewData["Resultado"] = "¡Error! No se puede dividir entre 0.";
                        return View("Index");
                    }
                    resultado = numero1 / numero2;
                    break;
                case "igual":
                    resultado = numero1;
                    break;
                default:
                    break;
            }

            ViewData["Resultado"] = resultado;
            return View("Index");
        }
    }
}

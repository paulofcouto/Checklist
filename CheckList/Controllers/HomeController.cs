using CheckList.Infrastructure;
using CheckList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CheckList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index([FromServices] TarefaRepository tarefa)
        {
            return View(tarefa.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Adicionar([FromServices] TarefaRepository tarefa)
        {
            var teste = tarefa.GetAll();
            return View(teste);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

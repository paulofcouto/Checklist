using CheckList.Infrastructure;
using CheckList.Infrastructure.MySql;
using CheckList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CheckList.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;


        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObterQtdTarefas([FromServices] TarefaRepository tarefa)
        {
            var qtdTarefas = tarefa.ObterTodas().Count();
            return Json(qtdTarefas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

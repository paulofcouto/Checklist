using CheckList.Application.Services;
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
        private readonly TarefaService _tarefaService;


        public DashboardController(ILogger<DashboardController> logger, TarefaService tarefaService)
        {
            _logger = logger;
            _tarefaService = tarefaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObterQtdTarefas()
        {
            var qtdTarefas = _tarefaService.ObterQdtTarefas();
            return Json(qtdTarefas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

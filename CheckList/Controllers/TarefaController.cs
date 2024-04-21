using CheckList.Application.Services;
using CheckList.Models.TarefaViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CheckList.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaService _tarefaService;

        public TarefaController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObterTarefas()
        {
            var tarefas = _tarefaService.ObterTarefas();
            return Json(tarefas);
        }

        [HttpPost]
        public IActionResult AdicionarTarefa([FromBody] TarefaViewModel tarefaViewModel)
        {
            _tarefaService.AdicionarTarefa(tarefaViewModel);
            return Ok();
        }
        
        [HttpDelete]
        public IActionResult ExcluirTarefa(int id)
        {
            _tarefaService.DeletarTarefa(id);
            return Ok();
        }
        
        [HttpPut]
        public IActionResult AtualizarStatusTarefa(int id)
        {
            _tarefaService.AtualizarStatusTarefa(id);
        
            return Ok();
        }
    }
}

using CheckList.Infrastructure.MySql;
using CheckList.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Controllers
{
    public class TarefaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ObterTarefas([FromServices] TarefaRepository tarefa)
        {
            return Json(tarefa.ObterTodas());
        }

        [HttpPost]
        public IActionResult AdicionarTarefa([FromServices] TarefaRepository tarefa, [FromBody] TarefaViewModel novaTarefa)
        {
            tarefa.Adicionar(new Models.Entities.TarefaModel { Descricao = novaTarefa.Descricao });
            return Ok();
        }

        [HttpDelete]
        public IActionResult ExcluirTarefa([FromServices] TarefaRepository tarefa, int id)
        {
            tarefa.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult AtualizarTarefa([FromServices] TarefaRepository tarefa, int id)
        {
            tarefa.AtualizarStatus(id);

            return Ok();
        }
    }
}

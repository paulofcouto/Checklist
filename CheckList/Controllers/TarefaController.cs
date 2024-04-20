﻿using CheckList.Infrastructure.MySql;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Adicionar([FromServices] TarefaRepository tarefa)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Detelar([FromServices] TarefaRepository tarefa)
        {
            return View();
        }

        [HttpPut]
        public IActionResult Alterar([FromServices] TarefaRepository tarefa)
        {
            return View();
        }
    }
}

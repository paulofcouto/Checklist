using CheckList.Application.Entities;
using CheckList.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Infrastructure.MySql
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly ChecklistDbContext _context;

        public TarefaRepository(ChecklistDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TarefaModel> ObterTodas()
        {
            return _context.Tarefa.ToList();
        }

        public TarefaModel? ObterPorId(int id)
        {
            return _context.Tarefa.FirstOrDefault(t => t.Id == id);
        }

        public void Adicionar(TarefaModel tarefa)
        {
            _context.Tarefa.Add(tarefa);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            var tarefa = _context.Tarefa.Find(id);

            if (tarefa == null)
            {
                throw new KeyNotFoundException($"Tarefa não encontrada.");
            }

            _context.Tarefa.Remove(tarefa);
            _context.SaveChanges();
        }

        public void Atualizar(TarefaModel tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

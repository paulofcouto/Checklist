using CheckList.Models.Entities;

namespace CheckList.Infrastructure
{
    public class TarefaRepository
    {
        private readonly ChecklistDbContext _context;

        public TarefaRepository(ChecklistDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return _context.Tarefas.ToList();
        }

        public Tarefa GetById(int id)
        {
            return _context.Tarefas.Find(id);
        }

        public void Add(Tarefa produto)
        {
            _context.Tarefas.Add(produto);
            _context.SaveChanges();
        }

        public void Update(Tarefa produto)
        {
            _context.Tarefas.Update(produto);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = GetById(id);
            if (produto != null)
            {
                _context.Tarefas.Remove(produto);
                _context.SaveChanges();
            }
        }


    }
}

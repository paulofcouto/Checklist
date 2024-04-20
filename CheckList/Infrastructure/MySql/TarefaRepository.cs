using CheckList.Models.Entities;

namespace CheckList.Infrastructure.MySql
{
    public class TarefaRepository
    {
        private readonly ChecklistDbContext _bdMySql;

        public TarefaRepository(ChecklistDbContext context)
        {
            _bdMySql = context;
        }

        public IEnumerable<TarefaModel> ObterTodas()
        {
            return _bdMySql.Tarefa;
        }

        public TarefaModel? ObterPorId(int id)
        {
            return _bdMySql.Tarefa.Find(id);
        }

        public void Adicionar(TarefaModel tarefa)
        {
            _bdMySql.Tarefa.Add(tarefa);
            _bdMySql.SaveChanges();
        }

        public void Atualizar(TarefaModel tarefa)
        {
            _bdMySql.Tarefa.Update(tarefa);
            _bdMySql.SaveChanges();
        }

        public void Deletar(int id)
        {
            var tarefa = ObterPorId(id);
            if (tarefa != null)
            {
                _bdMySql.Tarefa.Remove(tarefa);
                _bdMySql.SaveChanges();
            }
        }
    }
}

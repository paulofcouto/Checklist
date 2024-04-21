using CheckList.Application.Entities;

namespace CheckList.Infrastructure.Interface
{
    public interface ITarefaRepository
    {
        IEnumerable<TarefaModel> ObterTodas();
        TarefaModel? ObterPorId(int id);
        void Adicionar(TarefaModel tarefa);
        void Deletar(int id);
        void Atualizar(int id);
    }
}
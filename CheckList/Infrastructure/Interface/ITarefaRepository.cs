using CheckList.Models.Entities;

namespace CheckList.Infrastructure.Interface
{
    public interface ITarefaRepository
    {
        IEnumerable<TarefaModel> ObterTodas();
        TarefaModel? ObterPorId(int id);
        void Adicionar(TarefaModel tarefa);
        void AtualizarStatus(int Id);
        void Deletar(int id);
    }
}
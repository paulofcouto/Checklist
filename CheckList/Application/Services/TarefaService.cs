using CheckList.Application.Entities;
using CheckList.Infrastructure.MySql;
using CheckList.Models.TarefaViewModels;

namespace CheckList.Application.Services
{
    public class TarefaService
    {
        private readonly TarefaRepository _tarefaRepository;

        public TarefaService(TarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public IEnumerable<TarefaModel> ObterTarefas()
        {
            return _tarefaRepository.ObterTodas();
        }

        public int ObterQdtTarefas()
        {
            var tarefas = ObterTarefas();
            return tarefas.Count();
        }

        public void AdicionarTarefa(TarefaViewModel tarefaViewModel)
        {
            var tarefa = new TarefaModel
            {
                Descricao = tarefaViewModel.Descricao,
 
            };

            _tarefaRepository.Adicionar(tarefa);
        }

        public void DeletarTarefa(int id)
        {
            _tarefaRepository.Deletar(id);
        }

        public void AtualizarStatusTarefa(int id)
        {
            var tarefa = _tarefaRepository.ObterPorId(id);

            if (tarefa == null)
            {
                throw new InvalidOperationException("Tarefa não encontrada.");
            }

            tarefa.StatusConcluido = !tarefa.StatusConcluido;
            _tarefaRepository.Atualizar(tarefa);
        }
    }
}

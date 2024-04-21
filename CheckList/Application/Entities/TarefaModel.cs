using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckList.Application.Entities
{
    public class TarefaModel
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public bool StatusConcluido { get; set; }
    }
}

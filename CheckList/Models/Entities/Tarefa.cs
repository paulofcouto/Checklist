using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckList.Models.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public bool StatusConcluido { get; set; }
    }
}

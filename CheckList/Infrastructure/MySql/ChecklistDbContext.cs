using CheckList.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Infrastructure.MySql
{
    public class ChecklistDbContext : DbContext
    {
        public ChecklistDbContext(DbContextOptions<ChecklistDbContext> options) : base(options)
        {

        }

        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarefaModel>().HasData(
                new TarefaModel { Id = 1, Descricao = "Exemplo de tarefa concluída", StatusConcluido = true },
                new TarefaModel { Id = 2, Descricao = "Exemplo de tarefa a fazer", StatusConcluido = false }
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}

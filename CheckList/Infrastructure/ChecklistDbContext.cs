using CheckList.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CheckList.Infrastructure
{
    public class ChecklistDbContext : DbContext
    {
        public ChecklistDbContext(DbContextOptions<ChecklistDbContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}

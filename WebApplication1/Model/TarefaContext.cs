using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Tarefa> Tarefa => Set<Tarefa>(); 
    }
}

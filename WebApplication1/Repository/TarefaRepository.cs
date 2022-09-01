using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Repository
{

    public class TarefaRepository : ITarefaRepository
    {
      
        public readonly TarefaContext _context;

        public TarefaRepository(TarefaContext context)
        {
            _context = context;
        }
        public async Task<Tarefa> Create(Tarefa tarefa)
        {
            _context.Tarefa.Add(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }
       
        public async Task Delete(int id)
        {
            var tarefaToDelete = await _context.Tarefa.FindAsync(id);
            _context.Tarefa.Remove(tarefaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tarefa>> Get()
        {
            return await _context.Tarefa.ToListAsync();
        }

        public async Task<Tarefa> Get(int id)
        {
            return await _context.Tarefa.FindAsync(id);
        }
            
        public async Task Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
       

using WebApplication1.Model;

namespace WebApplication1.Repository
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> Get();

        Task<Tarefa> Get(int id);

        Task<Tarefa> Create(Tarefa tarefa);

        Task Update(Tarefa tarefa);

        Task Delete(int id);
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Repository;

namespace WebApplication1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;
        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Tarefa>> GetTarefa()
        {   
            return await _tarefaRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarefa>> GetTarefa(int id)
        {
            return await _tarefaRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Tarefa>> PostTarefa([FromBody] Tarefa tarefa)
        {
            var novatarefa = await _tarefaRepository.Create(tarefa);
            return tarefa;
        }
        [HttpDelete("{id}")]

        public async Task<ActionResult> Delete(int id)
        {
            var tarefaToDelete = await _tarefaRepository.Get(id);
            if (tarefaToDelete != null)
                return NotFound();
            await _tarefaRepository.Delete(tarefaToDelete.id);
            return NoContent();

        }
        [HttpPut]
        public async Task<ActionResult> PutTarefas(int id,[FromBody] Tarefa tarefa)
        {
            if (id != tarefa.id)
                return BadRequest();
            await _tarefaRepository.Update(tarefa);
            return NoContent();
        }
    }
}

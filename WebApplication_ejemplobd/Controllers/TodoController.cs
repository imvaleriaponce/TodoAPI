using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_ejemplobd.Models;
using WebApplication_ejemplobd.Repositories.Interfaces;

namespace WebApplication_ejemplobd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IToDoRepository _repository;

        public TodoController(IToDoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> Getall()
        {
            var todos = await _repository.GetAll();
            return Ok(todos);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetById(int id)
        {
            var todo = await _repository.GetById(id);
            if (todo == null)
                return NotFound();
            return Ok(todo);
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> Create(ToDo toDo)
        {
            var created = await _repository.Create(toDo);
            return Ok(created);
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult<ToDo>> Update([FromBody]ToDo toDo)
        {
            var updated = await _repository.Update(toDo);
            if(!updated)
                return NotFound();
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<ActionResult<ToDo>> Delete([FromBody] ToDo toDo)
        {
            var deleted = await _repository.Delete(toDo);
            if(!deleted)
                return NotFound();
            return Ok(deleted);
        }
    }
}

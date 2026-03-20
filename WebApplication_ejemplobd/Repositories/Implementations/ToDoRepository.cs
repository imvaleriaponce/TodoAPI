using Microsoft.EntityFrameworkCore;
using WebApplication_ejemplobd.Data;
using WebApplication_ejemplobd.Models;
using WebApplication_ejemplobd.Repositories.Interfaces;

namespace WebApplication_ejemplobd.Repositories.Implementations
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly AppDbContext _toDoContext;
        public ToDoRepository(AppDbContext toDoContext)
        {
            _toDoContext = toDoContext;
        }
        public async Task<ToDo> Create(ToDo todo)
        {
            _toDoContext.ToDos.Add(todo);
            await _toDoContext.SaveChangesAsync();
            return todo;
        }

        public async Task<bool> Delete(ToDo todo)
        {
            var existing = await _toDoContext.ToDos.FindAsync(todo.Id);
            if (existing == null)
                return false;

            _toDoContext.ToDos.Remove(existing);
            await _toDoContext.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ToDo>> GetAll()
        {
            return await _toDoContext.ToDos.ToListAsync();
        }

        public async Task<ToDo?> GetById(int id)
        {
            return await _toDoContext.ToDos.FindAsync(id);
        }

        public async Task<bool> Update(ToDo todo)
        {
            var existing = await _toDoContext.ToDos.FindAsync(todo.Id);
            if(existing == null)
                return false;

            existing.Value= todo.Value;
            existing.Status = todo.Status;
            existing.CreatedBy = todo.CreatedBy;
            existing.CreateDate = todo.CreateDate;

            await _toDoContext.SaveChangesAsync();
            return true;
        }
    }
}

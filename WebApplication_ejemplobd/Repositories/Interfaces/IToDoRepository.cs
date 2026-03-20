using WebApplication_ejemplobd.Models;

namespace WebApplication_ejemplobd.Repositories.Interfaces
{
    public interface IToDoRepository
    {
        Task<IEnumerable<ToDo>> GetAll();
        Task<ToDo> GetById(int id);
        Task<ToDo> Create(ToDo todo);
        Task<bool> Update(ToDo todo);
        Task<bool> Delete(ToDo todo);
    }
}

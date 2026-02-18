using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0309.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskContext _context;

        public EFTaskRepository(TaskContext temp)
        {
            _context = temp;
        }

        // We use .Include() here so the Controller person doesn't have to worry about it
        public IQueryable<UserTask> Tasks => _context.Tasks.Include(x => x.Category);
        public IQueryable<Category> Categories => _context.Categories;

        public void AddTask(UserTask task)
        {
            _context.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(UserTask task)
        {
            _context.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(UserTask task)
        {
            _context.Remove(task);
            _context.SaveChanges();
        }
    }
}
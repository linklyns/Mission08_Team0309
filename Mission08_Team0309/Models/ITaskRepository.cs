namespace Mission08_Team0309.Models
{
    public interface ITaskRepository
    {
        // A list of all tasks, including their Categories
        IQueryable<UserTask> Tasks { get; }
        IQueryable<Category> Categories { get; }

        // Methods for CRUD operations
        void AddTask(UserTask task);
        void UpdateTask(UserTask task);
        void DeleteTask(UserTask task);
    }
}
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0309.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
        }

        public DbSet<UserTask> Tasks { get; set; } // This creates the "Tasks" table

        public DbSet<Category> Categories { get; set; } // This creates the "Category" table

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            // Seed Tasks across all Quadrants and Categories
            modelBuilder.Entity<UserTask>().HasData(
                new UserTask { TaskId = 1, TaskName = "Finish Mission 08", DueDate = new DateTime(2026, 2, 20), Quadrant = 1, CategoryId = 2, Completed = false },
                new UserTask { TaskId = 2, TaskName = "Fix Sink Leak", DueDate = new DateTime(2026, 2, 19), Quadrant = 1, CategoryId = 1, Completed = false },
                new UserTask { TaskId = 3, TaskName = "Study for Midterm", DueDate = new DateTime(2026, 3, 1), Quadrant = 2, CategoryId = 2, Completed = false },
                new UserTask { TaskId = 4, TaskName = "Plan Service Project", DueDate = new DateTime(2026, 3, 15), Quadrant = 2, CategoryId = 4, Completed = false },
                new UserTask { TaskId = 5, TaskName = "Reply to non-urgent emails", DueDate = null, Quadrant = 3, CategoryId = 3, Completed = false },
                new UserTask { TaskId = 6, TaskName = "Schedule Dentist", DueDate = new DateTime(2026, 2, 25), Quadrant = 3, CategoryId = 1, Completed = false },
                new UserTask { TaskId = 7, TaskName = "Organize Desktop Folders", DueDate = null, Quadrant = 4, CategoryId = 3, Completed = false },
                new UserTask { TaskId = 8, TaskName = "Watch Cat Videos", DueDate = null, Quadrant = 4, CategoryId = 1, Completed = false }
            );
        }
    }
}
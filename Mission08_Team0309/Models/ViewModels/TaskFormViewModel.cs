using System.Collections.Generic;

namespace Mission08_Team0309.Models.ViewModels
{
    public class TaskFormViewModel
    {
        public UserTask Task { get; set; } = new UserTask();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}

using System;

namespace ToDoerMVC.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
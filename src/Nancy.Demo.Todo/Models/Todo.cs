using System;

namespace Nancy.Demo.Todo.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public int TodoListId { get; set; }
        public string Title { get; set; }
        public DateTime Deadline { get; set; }
        public bool Completed { get; set; }
    }
}
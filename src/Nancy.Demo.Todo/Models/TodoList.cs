using System.Collections.Generic;

namespace Nancy.Demo.Todo.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public Todos Todos { get; set; }
        public string Title { get; set; }
    }

    public class Todos : List<Todo>
    {
        public int TodoListId { get; set; }
    }
}
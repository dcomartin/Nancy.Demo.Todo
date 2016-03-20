using System;
using System.Collections.Generic;
using Nancy.Demo.Todo.Models;

namespace Nancy.Demo.Todo
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // The bootstrapper enables you to reconfigure the composition of the framework,
        // by overriding the various methods and properties.
        // For more information https://github.com/NancyFx/Nancy/wiki/Bootstrapper

        public static List<TodoList> TodoLists { get; set; }

        public Bootstrapper()
        {
            TodoLists = new List<TodoList>();
            for (var i = 0; i < 3; i++)
            {
                var todoList = new TodoList
                {
                    Title = "Todo list #" + (i + 1),
                    Todos = new Todos(),
                    Id = i + 1
                };
                TodoLists.Add(todoList);

                for (var j = 0; j < 5; j++)
                {
                    todoList.Todos.Add(new Models.Todo()
                    {
                        Completed = false,
                        Title = "Todo item #" + (j + 1),
                        Deadline = DateTime.Now.AddDays(i),
                        Id = j + 1,
                        TodoListId = todoList.Id
                    });
                    todoList.Todos.TodoListId = todoList.Id;
                }
            }
        }
    }
}
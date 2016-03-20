using System.Linq;
using Nancy.Demo.Todo.Models;
using Nancy.ModelBinding;
using Nancy.Responses;

namespace Nancy.Demo.Todo.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ => View["index", Bootstrapper.TodoLists];

            Post["/todolists/add"] = parameters =>
            {
                var newTodoList = this.Bind<TodoList>();
                Bootstrapper.TodoLists.Add(newTodoList);
                newTodoList.Todos = new Todos();
                newTodoList.Todos.TodoListId = newTodoList.Id;

                return new RedirectResponse("/");
            };

            Post["/todolists/{TodoListId:int}/todos/add"] = parameters =>
            {
                var newTodo = this.Bind<Models.Todo>();
                var todoList = Bootstrapper.TodoLists.FirstOrDefault(x => x.Id == newTodo.TodoListId);
                if (todoList == null)
                    return Negotiate.WithModel("Not exists todo list").WithStatusCode(HttpStatusCode.BadRequest);

                todoList.Todos.Add(newTodo);
                return new RedirectResponse("/");
            };

            Get["/todolists/add"] = _ => View["todolist/create.html"];

            Get["/todolists/{todolistid:int}/todos/add"] = _ => View["todo/create.html", _.todolistid];
        }
    }
}
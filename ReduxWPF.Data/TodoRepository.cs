using ReduxWPF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduxWPF.Data
{
    public class TodoRepository : ITodoRepository
    {
        public IEnumerable<Todo> Load()
        {
            using (var ctx = new TodoContext())
            {
                var todos = ctx.Todos.ToList();
                return todos;
            }
        }

        public Todo AddTodo(Todo todo)
        {
            using (var ctx = new TodoContext())
            {
                todo.Text = todo.Text.ToUpper();
                ctx.Todos.Add(todo);
                ctx.SaveChanges();

                return todo;
            }
        }

        public Todo UpdateTodo(Todo todo)
        {
            using (var ctx = new TodoContext())
            {
                var toUpdate = ctx.Todos.Single(x => x.Id == todo.Id);
                toUpdate.IsCompleted = todo.IsCompleted;

                ctx.SaveChanges();

                return toUpdate;
            }
        }

        public bool DeleteTodo(Guid id)
        {
            using (var ctx = new TodoContext())
            {
                var toDelete = ctx.Todos.Single(x => x.Id == id);
                ctx.Todos.Remove(toDelete);

                ctx.SaveChanges();

                return true;
            }
        }

    }
}

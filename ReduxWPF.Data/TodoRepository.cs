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
        public async Task<IEnumerable<Todo>> Load()
        {
            return await Task.Run(() =>
            {
                using (var ctx = new TodoContext())
                {
                    var todos = ctx.Todos.ToList();
                    return todos;
                }
            });
        }

        public async Task<Todo> AddTodo(Todo todo)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new TodoContext())
                {
                    todo.Text = todo.Text.ToUpper();
                    ctx.Todos.Add(todo);
                    ctx.SaveChanges();

                    return todo;
                }
            });
        }

        public async Task<Todo> UpdateTodo(Todo todo)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new TodoContext())
                {
                    var toUpdate = ctx.Todos.Single(x => x.Id == todo.Id);
                    toUpdate.IsCompleted = todo.IsCompleted;

                    ctx.SaveChanges();

                    return toUpdate;
                }
            });
        }

        public async Task<bool> DeleteTodo(Guid id)
        {
            return await Task.Run(() =>
            {
                using (var ctx = new TodoContext())
                {
                    var toDelete = ctx.Todos.Single(x => x.Id == id);
                    ctx.Todos.Remove(toDelete);

                    ctx.SaveChanges();

                    return true;
                }
            });
        }

    }
}

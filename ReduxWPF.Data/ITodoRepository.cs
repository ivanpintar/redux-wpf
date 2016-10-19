using System;
using ReduxWPF.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ReduxWPF.Data
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> Load();
        Task<Todo> AddTodo(Todo todo);
        Task<bool> DeleteTodo(Guid id);
        Task<Todo> UpdateTodo(Todo todo);
    }
}
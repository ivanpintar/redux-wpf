using System;
using ReduxWPF.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ReduxWPF.Data
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> Load();
        Todo AddTodo(Todo todo);
        bool DeleteTodo(Guid id);
        Todo UpdateTodo(Todo todo);
    }
}
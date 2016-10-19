using Redux;
using ReduxWPF.Data;
using ReduxWPF.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Taiste.Redux;

namespace ReduxWPF.Actions
{
    public class ReloadTodosAction : IAction
    {
        public IEnumerable<Todo> Todos { get; set; }
    }

    public class AddTodoAction : IAction
    {
        public string Text { get; set; }
    }

    public class DeleteTodoAction : IAction
    {
        public Guid TodoId { get; set; }
    }

    public class ToggleTodoAction : IAction
    {
        public Guid TodoId { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class FilterTodosAction : IAction
    {
        public TodosFilter Filter { get; set; }
    }

    public class ActionCreator
    {
        private ITodoRepository _repo;

        public ActionCreator(ITodoRepository repo)
        {
            _repo = repo;
        }

        public IAction ReloadTodos()
        {
            return new ThunkAction<AppState>(async (dispatch, getState) =>
            {
                var entities = await _repo.Load();
                var todos = entities
                    .OrderByDescending(x => x.Date)
                    .Select(x => new Todo { Id = x.Id, Text = x.Text, IsCompleted = x.IsCompleted })
                    .ToList();

                dispatch(new ReloadTodosAction { Todos = todos });
            });
        }

        public IAction AddTodo(string text)
        {
            return new ThunkAction<AppState>(async (dispatch, getState) =>
            {
                var addedTodo = await _repo.AddTodo(new Data.Entities.Todo { Text = text });
                dispatch(new AddTodoAction { Text = addedTodo.Text });
            });
        }

        public IAction DeleteTodo(Guid id)
        {
            return new ThunkAction<AppState>(async (dispatch, getState) =>
            {
                await _repo.DeleteTodo(id);
                dispatch(new DeleteTodoAction { TodoId = id });
            });
        }

        public IAction ToggleTodo(Guid id)
        {
            return new ThunkAction<AppState>(async (dispatch, getState) =>
            {
                var todo = getState().Todos.Single(x => x.Id == id);
                var entity = new Data.Entities.Todo
                {
                    Id = todo.Id,
                    Text = todo.Text,
                    IsCompleted = !todo.IsCompleted
                };
                var updated = await _repo.UpdateTodo(entity);

                dispatch(new ToggleTodoAction { TodoId = id, IsCompleted = updated.IsCompleted });
            });
        }

        public IAction Filter(TodosFilter filter)
        {
            return new FilterTodosAction { Filter = filter };
        }

    }
}

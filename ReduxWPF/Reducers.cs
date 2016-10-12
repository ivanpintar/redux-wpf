using Redux;
using ReduxWPF.States;
using System.Collections.Immutable;
using System.Linq;
using ReduxWPF.Actions;

namespace ReduxWPF
{
    public static class Reducers
    {
        public static Todo ToggleTodoReducer(Todo previousState, ToggleTodoAction action)
        {
            return new Todo
            {
                Id = previousState.Id,
                Text = previousState.Text,
                IsCompleted = action.IsCompleted
            };
        }

        public static ImmutableArray<Todo> ToggleTodoReducer(ImmutableArray<Todo> previousState, ToggleTodoAction action)
        {
            var todoToEdit = previousState.First(todo => todo.Id == action.TodoId);

            return previousState.Replace(todoToEdit, ToggleTodoReducer(todoToEdit, action));
        }

        public static ImmutableArray<Todo> AddTodoReducer(ImmutableArray<Todo> previousState, AddTodoAction action)
        {
            return previousState.Insert(0, new Todo(action.Text));
        }

        public static ImmutableArray<Todo> ReloadTodosReducer(ImmutableArray<Todo> previousState, ReloadTodosAction action)
        {
            return ImmutableArray.Create(action.Todos.ToArray());
        }

        public static ImmutableArray<Todo> DeleteTodoReducer(ImmutableArray<Todo> previousState, DeleteTodoAction action)
        {
            var todoToDelete = previousState.First(todo => todo.Id == action.TodoId);
            return previousState.Remove(todoToDelete);
        }

        public static ImmutableArray<Todo> TodosReducer(ImmutableArray<Todo> previousState, IAction action)
        {
            if (action is ReloadTodosAction)
                return ReloadTodosReducer(previousState, (ReloadTodosAction)action);

            if (action is AddTodoAction)
                return AddTodoReducer(previousState, (AddTodoAction)action);

            if (action is ToggleTodoAction)
                return ToggleTodoReducer(previousState, (ToggleTodoAction)action);

            if (action is DeleteTodoAction)
                return DeleteTodoReducer(previousState, (DeleteTodoAction)action);

            return previousState;
        }

        public static AppState ReduceApplication(AppState previousState, IAction action)
        {
            return new AppState
            {
                Filter = action is FilterTodosAction ? ((FilterTodosAction)action).Filter : previousState.Filter,
                Todos = TodosReducer(previousState.Todos, action)
            };
        }
    }
}

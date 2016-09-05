using Redux;
using ReduxWPF.States;
using System.Collections.Immutable;
using System.Linq;

namespace ReduxWPF
{
    public static class Reducers
    {
        public static Todo CompleteTodoReducer(Todo previousState, CompleteTodoAction action)
        {
            return new Todo
            {
                Id = previousState.Id,
                Text = previousState.Text,
                IsCompleted = !previousState.IsCompleted
            };
        }

        public static ImmutableArray<Todo> CompleteTodoReducer(ImmutableArray<Todo> previousState, CompleteTodoAction action)
        {
            var todoToEdit = previousState.First(todo => todo.Id == action.TodoId);

            return previousState.Replace(todoToEdit, CompleteTodoReducer(todoToEdit, action));
        }

        public static ImmutableArray<Todo> AddTodoReducer(ImmutableArray<Todo> previousState, AddTodoAction action)
        {
            return previousState.Insert(0, new Todo(action.Text));
        }

        public static ImmutableArray<Todo> DeleteTodoReducer(ImmutableArray<Todo> previousState, DeleteTodoAction action)
        {
            var todoToDelete = previousState.First(todo => todo.Id == action.TodoId);
            return previousState.Remove(todoToDelete);
        }

        public static ImmutableArray<Todo> TodosReducer(ImmutableArray<Todo> previousState, IAction action)
        {
            if (action is AddTodoAction)
                return AddTodoReducer(previousState, (AddTodoAction)action);

            if (action is CompleteTodoAction)
                return CompleteTodoReducer(previousState, (CompleteTodoAction)action);

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

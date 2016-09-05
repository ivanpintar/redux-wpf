using ReduxWPF.States;
using ReduxWPF.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ReduxWPF
{
    public class Selectors
    {
        public static IEnumerable<Todo> GetFilteredTodos(AppState state)
        {
            switch (state.Filter)
            {
                case TodosFilter.InProgress:
                    return state.Todos.Where(x => !x.IsCompleted);
                case TodosFilter.Completed:
                    return state.Todos.Where(x => x.IsCompleted);
                default:
                    return state.Todos;
            }
        }

        public static FooterViewModel MakeFooterViewModel(AppState state)
        {
            return new FooterViewModel
            {
                ActiveTodosCounterMessage = GetActiveTodosCounterMessage(state.Todos),
                SelectedFilter = state.Filter,
                AreFiltersVisible = state.Todos.Any()
            };
        }

        public static string GetActiveTodosCounterMessage(IEnumerable<Todo> todos)
        {
            var activeTodoCount = todos.Count(todo => !todo.IsCompleted);
            var itemWord = activeTodoCount <= 1 ? "item" : "items";
            return activeTodoCount + " " + itemWord + " left";
        }
    }
}

using System.Collections.Immutable;

namespace ReduxWPF.States
{
    public class AppState
    {
        public ImmutableArray<Todo> Todos { get; set; }
        public TodosFilter Filter { get; set; }
    }
}

using ReduxWPF.States;

namespace ReduxWPF.ViewModels
{
    public class FooterViewModel
    {
        public string ActiveTodosCounterMessage { get; internal set; }
        public bool AreFiltersVisible { get; internal set; }
        public TodosFilter SelectedFilter { get; internal set; }
    }
}
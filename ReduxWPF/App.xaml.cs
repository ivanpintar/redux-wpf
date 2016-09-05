using Redux;
using ReduxWPF.States;
using System.Collections.Immutable;
using System.Windows;

namespace ReduxWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IStore<AppState> Store { get; private set; }

        public App()
        {
            InitializeComponent();

            var initialState = new AppState
            {
                Todos = ImmutableArray<Todo>.Empty,
                Filter = TodosFilter.All
            };

            Store = new Store<AppState>(Reducers.ReduceApplication, initialState);
        }
    }
}

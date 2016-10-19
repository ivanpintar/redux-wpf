using Redux;
using ReduxWPF.Actions;
using ReduxWPF.Data;
using ReduxWPF.States;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Taiste.Redux;

namespace ReduxWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IStore<AppState> Store { get; private set; }
        public static ActionCreator Actions = new ActionCreator(new TodoRepository());

        public App()
        {
            InitializeComponent();

            var initialState = new AppState
            {
                Todos = ImmutableArray<Todo>.Empty,
                Filter = TodosFilter.All
            };

            Store = new Store<AppState>(Reducers.ReduceApplication, initialState, Middleware.ThunkMiddleware);
        }
    }
}

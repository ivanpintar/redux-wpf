using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Controls;

namespace ReduxWPF.Views
{
    /// <summary>
    /// Interaction logic for MainSection.xaml
    /// </summary>
    public partial class MainSection : UserControl
    {
        public MainSection()
        {
            InitializeComponent();

            App.Store
                .Select(Selectors.GetFilteredTodos)
                .Subscribe(todos => TodosItemsControl.ItemsSource = todos);
        }
    }
}

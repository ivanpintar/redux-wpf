using ReduxWPF.States;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ReduxWPF.Views
{
    /// <summary>
    /// Interaction logic for Footer.xaml
    /// </summary>
    public partial class Footer : UserControl
    {
        public Footer()
        {
            InitializeComponent();

            App.Store
                .Select(Selectors.MakeFooterViewModel)
                .Subscribe(vm =>
                {
                    ActiveTodoCounterTextBlock.Text = vm.ActiveTodosCounterMessage;
                    CheckFilter(vm.SelectedFilter);
                });

        }

        private void CheckFilter(TodosFilter selectedFilter)
        {
            switch (selectedFilter)
            {
                case TodosFilter.InProgress:
                    InProgressFilter.IsChecked = true;
                    break;
                case TodosFilter.Completed:
                    CompletedFilter.IsChecked = true;
                    break;
                default:
                    AllFilter.IsChecked = true;
                    break;
            }
        }

        private void AllFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterTodos(TodosFilter.All);
        }

        private void InProgressFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterTodos(TodosFilter.InProgress);
        }

        private void CompletedFilter_Click(object sender, RoutedEventArgs e)
        {
            FilterTodos(TodosFilter.Completed);
        }

        private void FilterTodos(TodosFilter filter)
        {
            App.Store.Dispatch(new FilterTodosAction
            {
                Filter = filter
            });
        }

    }
}

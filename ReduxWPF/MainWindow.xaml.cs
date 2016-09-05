using System;
using System.Linq;
using System.Windows;

namespace ReduxWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.Store.Subscribe(state =>
            {
                Footer.Visibility = state.Todos.Any() ? Visibility.Visible : Visibility.Collapsed;
            });
        }
    }
}

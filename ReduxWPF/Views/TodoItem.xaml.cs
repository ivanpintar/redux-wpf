using ReduxWPF.States;
using System.Windows;
using System.Windows.Controls;
using ReduxWPF.Actions;

namespace ReduxWPF.Views
{
    /// <summary>
    /// Interaction logic for TodoItem.xaml
    /// </summary>
    public partial class TodoItem : UserControl
    {
        public static readonly DependencyProperty TodoProperty =
             DependencyProperty.Register("Todo", typeof(Todo), typeof(TodoItem), new PropertyMetadata(default(Todo), OnTodoChanged));

        public Todo Todo
        {
            get { return (Todo)GetValue(TodoProperty); }
            set { SetValue(TodoProperty, value); }
        }

        private static void OnTodoChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            var todoItem = (TodoItem)sender;
            var todo = (Todo)args.NewValue;

            todoItem.TodoItemTextBlock.Text = todo.Text;
            todoItem.CompleteCheckBox.IsChecked = todo.IsCompleted;
            todoItem.DeleteTodoItemButton.Visibility = !todo.IsCompleted ? Visibility.Hidden : Visibility.Visible;            
        }

        public TodoItem()
        {
            InitializeComponent();
        }

        private void CompleteCheckBox_Click(object sender, RoutedEventArgs e)
        {
            App.Store.Dispatch(App.Actions.ToggleTodo(Todo.Id));
        }

        private void DeleteTodoItemButton_Click(object sender, RoutedEventArgs e)
        {
            App.Store.Dispatch(App.Actions.DeleteTodo(Todo.Id));
        }
    }
}

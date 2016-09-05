using Redux;
using ReduxWPF.States;
using System;

namespace ReduxWPF
{
    public class AddTodoAction : IAction
    {
        public string Text { get; set; }
    }

    public class DeleteTodoAction : IAction
    {
        public Guid TodoId { get; set; }
    }

    public class CompleteTodoAction : IAction
    {
        public Guid TodoId { get; set; }
    }
    
    public class FilterTodosAction : IAction
    {
        public TodosFilter Filter { get; set; }
    }
}

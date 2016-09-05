using System;

namespace ReduxWPF.States
{
    public class Todo
    {
        public Todo() { }
        public Todo(string text)
        {
            Text = text;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
    }
}

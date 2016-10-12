using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReduxWPF.Data.Entities
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Date { get; set; }

        public Todo()
        {
            Id = Guid.NewGuid();
            Date = DateTime.UtcNow;
        }
    }
}

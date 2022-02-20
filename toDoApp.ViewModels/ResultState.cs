using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toDoApp.ViewModels
{
    public class ResultState
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public Guid Id { get; set; }
    }
}

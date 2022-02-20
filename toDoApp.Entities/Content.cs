using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toDoApp.Entities
{
    public partial class Content:EntityBase
    {
        [Required]
        public string ContentStr { get; set; }
    }
}

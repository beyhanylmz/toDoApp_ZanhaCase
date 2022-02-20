using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace toDoApp.Entities
{
    
    public interface IEntity
    {
        Guid Id { get; set; }
        bool IsDeleted { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}

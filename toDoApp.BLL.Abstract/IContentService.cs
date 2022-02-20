using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.Entities;
using toDoApp.ViewModels;

namespace toDoApp.BLL.Abstract
{  
    public interface IContentService
    {
        List<Content> GetAll();
        Content GetById(Guid id);
        bool Add(ContentVM newContent);
        bool Delete(Guid id);
    }
}

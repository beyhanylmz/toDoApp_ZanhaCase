using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using toDoApp.BLL.Abstract;
using toDoApp.DAL.Abstract;
using toDoApp.Entities;
using toDoApp.ViewModels;

namespace toDoApp.BLL
{   
    public class ContentService : IContentService
    {
        IUnitofWork _uow;

        public ContentService(IUnitofWork uow)
        {
            _uow = uow;

        }

        public List<Content> GetAll()
        {
            var data = _uow.GetRepository<Content>().Get(m => m.IsDeleted == false);
            return data;

        }
        public Content GetById(Guid id)
        {
            var data = _uow.GetRepository<Content>().Get().FirstOrDefault(m => m.Id == id);
            return data;
        }


        public bool Add(ContentVM contentVM)
        {
            bool isAdded=false;
            try
            {                
                Content content = new Content();
                content.Id = contentVM.Id;
                content.ContentStr = contentVM.ContentStr;                
                content.IsDeleted = false;
                content.CreatedDate = DateTime.Now; 
                isAdded = _uow.GetRepository<Content>().Add(content);
            }
            catch (Exception ex)
            {
                isAdded = false;
            }
            return isAdded;

        }

        public bool Delete(Guid id)
        {
            bool isDeleted = false;
            try
            {
                isDeleted = _uow.GetRepository<Content>().Delete(id);               

            }
            catch (Exception ex)
            {
                isDeleted = false;
                
            }
            return isDeleted;


        }
    }
}

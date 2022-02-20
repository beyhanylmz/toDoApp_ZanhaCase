using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using toDoApp.BLL.Abstract;
using toDoApp.Entities;
using toDoApp.MVC.Utility;
using toDoApp.ViewModels;

namespace toDoApp.MVC.Controllers
{
    public class ContentController : Controller
    {   
        [Inject]
        public IContentService CS { get; set; }
     
        public ContentController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContentList()
        {
            var model = CS.GetAll();
            List<ContentListVM> list = new List<ContentListVM>();
            foreach (var item in model)
            {
                ContentListVM vm = new ContentListVM();
                vm.id = item.Id;
                vm.contentStr = item.ContentStr;
                list.Add(vm);
            }
            return View(list);
        }

        public ActionResult Add()
        {
            var model = new ContentVM(); 
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(ContentVM newContent)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var Id = Guid.NewGuid();
                    newContent.Id = Id;
                    bool isAdded = CS.Add(newContent);
                    if (isAdded)
                    {
                        return Json(new { IsSuccess = true, Message = "Kayıt Ekleme Başarılı", Id = Id });
                    }
                    else
                    {
                        return Json(new { IsSuccess = true, Message = "Kayıt Ekleme Başarısız", Id = Guid.NewGuid() });
                    }
                    
                }
                catch (Exception ex)
                {
                    return Json(new { IsSuccess = true, Message = "Kayıt Ekleme Başarısız", Id = Guid.NewGuid() });
                }
            }
            return Json(new { IsSuccess = true, Message = "Kayıt Ekleme Başarısız", Id = Guid.NewGuid() });
        }     
        public ActionResult Delete(Guid id)
        {
            Content deletedContent = CS.GetById(id);
            if (deletedContent != null)
            {
                try
                {
                    bool isDeleted = CS.Delete(id);
                    if (isDeleted)
                    {
                        Log.Debug("[ToDoApp]: İçerik silindi id eşittir '"+id +"'");
                    }
                    else
                    {
                        Log.Error("[ToDoApp]: İçerik silinemedi");
                    }
                    
                }
                catch (Exception ex)
                {
                    Log.Error("[ToDoApp]: İçerik silinemedi", ex);
                    throw;
                }

                
            }
            else
            {
                Log.Error("[ToDoApp]: İçerik silinemedi");
            
            }
            return RedirectToAction("ContentList");

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class AppUserController : BaseController
    {

        public ActionResult AppUserAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AppUserAdd(AppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.Email = model.Email;
                appUser.UserName = model.UserName;
                appUser.Password = model.Password;
                appUser.Role = model.Role;
                appUser.Gender = model.Gender;
                db.AppUsers.Add(appUser);   
                db.SaveChanges();

                return View();
 
            }
           

                return View();

           

            
        }

        public ActionResult AppUserList()
        {
            List<AppUserDTO> model = db.AppUsers.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).Select(x => new AppUserDTO
            {
                ID = x.ID,
                FirstName=x.FirstName,
                LastName=x.LastName,
                Email=x.Email,
                UserName=x.UserName,
                Password=x.Password,
                Role=x.Role,
                Gender=x.Gender


            }).ToList();
            return View(model);
        }

       public ActionResult AppUserUpdate(int id)
        {
            AppUser appUser = db.AppUsers.FirstOrDefault(x => x.ID == id);
            AppUserDTO model = new AppUserDTO();
            model.ID = appUser.ID;
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;
            model.UserName = appUser.UserName;
            model.Password = appUser.Password;
            model.Email = appUser.Email;
            model.Role = appUser.Role;
            model.Gender = appUser.Gender;
            return View(model);
        }

        [HttpPost]
       public ActionResult AppUserUpdate(AppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = db.AppUsers.FirstOrDefault(x => x.ID == model.ID);
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.UserName = model.UserName;
                appUser.Password = model.Password;
                appUser.Email = model.Email;
                appUser.Role = model.Role;
                appUser.Gender = model.Gender;
                appUser.UpdateDate = DateTime.Now;
                appUser.Status = WareHouse.Model.Enum.Status.Updated;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/AppUserList");

            }
            else
            {
                return Redirect("/Admin/AppUser/AppUserList");
            }
        }

        public ActionResult AppUserDelete(int id)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = db.AppUsers.FirstOrDefault(x => x.ID == id);
                appUser.Status = WareHouse.Model.Enum.Status.Deleted;
                appUser.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/AppUser/AppUserList");
            }
            else
            {
                return Redirect("/Admin/AppUser/AppUserList");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;
using WareHouse.UI.Areas.Admin.Models.VM;

namespace WareHouse.UI.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
       
        public ActionResult ProductAdd()
        {
            List<Category> model = db.Categories.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).OrderBy(x=>x.AddDate).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductAdd(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product();               
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.CategoryID = model.CategoryID;
                db.Products.Add(product);
                db.SaveChanges();
                ViewBag.ProcessCondition = 1;
                return Redirect("/Admin/Product/ProductList");

            }
            else
            {
                ViewBag.ProcessCondition = 2;
                return Redirect("/Admin/Product/ProductList");

            }
        }

        public ActionResult ProductList()
        {
            List<ProductDTO> model = db.Products.Where(x => x.Status == WareHouse.Model.Enum.Status.Active || x.Status == WareHouse.Model.Enum.Status.Updated).Select(x => new ProductDTO()
            {
                ID = x.ID,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                CategoryName = x.Category.CategoryName,
                CategoryID=x.CategoryID
            }).ToList();

            return View(model);
        }

        public ActionResult ProductUpdate(int id)
        {
            ProductVM model = new ProductVM();
            Product product = db.Products.FirstOrDefault(x => x.ID == id);  
            model.product.ID = product.ID;
            model.product.ProductName = product.ProductName;
            model.product.ProductDescription = product.ProductDescription;
            model.product.UnitPrice = product.UnitPrice;
            model.product.UnitsInStock = product.UnitsInStock;
            //model.product.CategoryID = product.CategoryID;
            //model.product.CategoryName = product.Category.CategoryName;

            List<Category> categorymodel=db.Categories.Where(x => x.Status == Model.Enum.Status.Active || x.Status == Model.Enum.Status.Updated).ToList();
            model.Categories = categorymodel;
            return View(model);
        }

        [HttpPost]
        public ActionResult ProductUpdate(ProductDTO model)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.FirstOrDefault(x => x.ID == model.ID);
                //product.ID = model.ID;
                product.ProductName = model.ProductName;
                product.ProductDescription = model.ProductDescription;
                product.UnitPrice = model.UnitPrice;
                product.UnitsInStock = model.UnitsInStock;
                product.CategoryID = model.CategoryID;
                //product.Category.CategoryName = model.CategoryName;
                product.UpdateDate = DateTime.Now;
                product.Status = WareHouse.Model.Enum.Status.Updated;
            
                db.SaveChanges();
                return Redirect("/Admin/Product/ProductList");
            }
            else
            {
                return View();
            }

        }

        public ActionResult ProductDelete(int id)
        {
            if (ModelState.IsValid)
            {
                Product product = db.Products.FirstOrDefault(x => x.ID == id);
                product.Status = WareHouse.Model.Enum.Status.Deleted;
                product.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Redirect("/Admin/Product/ProductList");
            }
            else
            {
                return Redirect("/Admin/Product/ProductList");
            }
        }
    }
}
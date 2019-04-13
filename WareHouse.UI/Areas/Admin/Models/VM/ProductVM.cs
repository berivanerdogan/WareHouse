using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WareHouse.Model.Entity;
using WareHouse.UI.Areas.Admin.Models.DTO;

namespace WareHouse.UI.Areas.Admin.Models.VM
{
    public class ProductVM
    {
        public ProductVM()
        {
            Categories = new List<Category>();
            product = new ProductDTO();
        }

        public List<Category> Categories { get; set; }
        public ProductDTO product { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace WareHouse.UI.Areas.Admin.Models.DTO
{
    public class ProductDTO:BaseDTO
    {
        [Required(ErrorMessage ="Please Add Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage ="Please Add Product Description")]
        public string ProductDescription { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }

        public string CategoryName { get; set; }
        public int CategoryID { get; set; }


    }
}
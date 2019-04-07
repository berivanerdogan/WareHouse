using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Model.Entity
{
   public class Shipper:BaseEntity
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
    }
}

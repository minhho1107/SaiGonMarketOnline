using BH_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.ModelViews
{
    public class ProductHomeVM
    {
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
    }
}

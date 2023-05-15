using BH_Online.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.Controllers
{
    public class SearchController : Controller
    {
        private readonly BHOnlineContext _context;

        public SearchController(BHOnlineContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        //[HttpPost]
        //public IActionResult FindProduct(string keyword)
        //{
        //    List<Product> ls = new List<Product>();
        //    if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
        //    {
        //        return PartialView("ListProductsSearchPartial", null);
        //    }
        //    ls = _context.Products.AsNoTracking()
        //                          .Where(x => x.ProductName.Contains(keyword))
        //                          .OrderByDescending(x => x.ProductName)
        //                          .ToList();
        //    if (ls == null)
        //    {
        //        return PartialView("ListProductsSearchPartial", null);
        //    }
        //    else
        //    {
        //        return PartialView("ListProductsSearchPartial", ls);
        //    }
        //}

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.Controllers
{
    public class AjaxContentController : Controller// reload cái HeaderCart trong product detail 
    {
        public IActionResult HeaderCart()
        {
            return ViewComponent("HeaderCart");
        }
        public IActionResult HeaderFavourites()
        {
            return ViewComponent("NumberCart");
        }
    }
}

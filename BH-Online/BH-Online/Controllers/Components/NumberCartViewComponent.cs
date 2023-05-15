using BH_Online.Extension;
using BH_Online.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.Controllers.Components// tạo default để làm view components khi mà ajax của mình nó gọi thêm vào giỏ hàng lập tức nó sẽ reload đúng dữ liệu mà ng dùng cần 
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}

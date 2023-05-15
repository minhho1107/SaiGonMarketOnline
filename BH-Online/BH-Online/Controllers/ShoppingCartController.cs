using AspNetCoreHero.ToastNotification.Abstractions;
using BH_Online.Extension;
using BH_Online.Models;
using BH_Online.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly BHOnlineContext _context;
        public INotyfService _notyfService { get; }
        public ShoppingCartController(BHOnlineContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        public List<CartItem> GioHang // khởi tạo 1 giỏ hàng rỗng 
        {
            get
            {
                var gh = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if (gh == default(List<CartItem>))  // nếu trường hợp có rồi thì ta lấy ra giỏ hàng 
                {
                    gh = new List<CartItem>(); // chưa có khởi tạo 1 cái giỏ hàng mới và chưa lưu gì hết
                }
                return gh;
            }
        }
        /*
            1. Thêm mới sản phẩm vào giỏ hàng 
            2. Cập nhật số lượng sản phẩm 
            3. Xóa sản phẩm khỏi giỏ hàng 
            4. Xóa luôn giỏ hàng 

        */

        [HttpPost]
        [Route("api/cart/add")]
        public IActionResult AddToCart(int productID, int? amount) // hàm addtocard thêm mới 1 giỏ hàng vào trong đó có
        {
            List<CartItem> cart = GioHang; // lấy biến giỏ hàng ra 

            try
            {
                //Them san pham vao gio hang
                CartItem item = cart.SingleOrDefault(p => p.product.ProductId == productID); // khởi tạo mới 1 cartitem  lấy giỏ hàng ra 
                if (item != null) // da co => cap nhat so luong(giỏ hàng đã có item)
                {
                    item.amount = item.amount + amount.Value;
                    //luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                else
                {
                    Product hh = _context.Products.SingleOrDefault(p => p.ProductId == productID); // khi chưa có sản phẩm ta định nghĩa nó là 1 cái hàng hóa
                    item = new CartItem// lấy sản phẩm ra định nghĩa 1 card item   
                    {
                        amount = amount.HasValue ? amount.Value : 1,
                        product = hh
                    };
                    cart.Add(item);//Them vao gio hàng
                }

                //Luu lai Session
                HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                _notyfService.Success("Thêm sản phẩm thành công");
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false }); // còn nếu bị lỗi
            }
        }
        [HttpPost]
        [Route("api/cart/update")]
        public IActionResult UpdateCart(int productID, int? amount) // cập nhật 
        {
            //Lay gio hang ra de xu ly
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang"); // lấy sản phẩm đó ra(sản đó phải có trong giỏ hàng r) 
            try
            {
                if (cart != null)//(sản đó phải có trong giỏ hàng r) 
                {
                    CartItem item = cart.SingleOrDefault(p => p.product.ProductId == productID);
                    if (item != null && amount.HasValue) // da co -> cap nhat so luong
                    {
                        item.amount = amount.Value;
                    }
                    //Luu lai session
                    HttpContext.Session.Set<List<CartItem>>("GioHang", cart);
                }
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [Route("api/cart/remove")] 
        public ActionResult Remove(int productID) // xóa sản phẩm khỏi giỏ hàng
        {

            try
            {
                List<CartItem> gioHang = GioHang; // có sản phẩm này trong giỏ ko 
                CartItem item = gioHang.SingleOrDefault(p => p.product.ProductId == productID);
                if (item != null)
                {
                    gioHang.Remove(item);// có thì xóa item đó khỏi giỏ hàng 
                }
                //luu lai session
                HttpContext.Session.Set<List<CartItem>>("GioHang", gioHang);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
        [Route("cart.html", Name = "Cart")]
        public IActionResult Index()
        {
            return View(GioHang);
        }
    }
}


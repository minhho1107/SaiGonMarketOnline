using BH_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.ModelViews
{
    public class CartItem // sản phẩm mà khách hàng bỏ vào giỏ hàng 
    {
        public Product product { get; set; } // sản phẩm 
        public int amount { get; set; } // số lượng 
        public double TotalMoney => amount * product.Price.Value; // tổng tiền
    }
}

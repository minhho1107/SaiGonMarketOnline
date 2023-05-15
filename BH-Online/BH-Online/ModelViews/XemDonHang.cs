using BH_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.ModelViews
{
    public class XemDonHang
    {
        public Order DonHang { get; set; }
        public List<OrderDetail> ChiTietDonHang { get; set; }
    }
}

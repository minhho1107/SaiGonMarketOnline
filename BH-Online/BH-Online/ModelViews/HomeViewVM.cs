using BH_Online.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BH_Online.ModelViews
{
    public class HomeViewVM
    {
        public List<TinDang> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
        public QuangCao quangcao { get; set; }
    }
}

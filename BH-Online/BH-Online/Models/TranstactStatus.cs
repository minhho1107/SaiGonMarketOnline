﻿using System;
using System.Collections.Generic;

#nullable disable

namespace BH_Online.Models
{
    public partial class TranstactStatus
    {
        public TranstactStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int TransactStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Application.DTOs.Order
{
    public class ProductOrderDto
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string CustomerName { get; set; }

        public string ProductName { get; set; }
    }
}

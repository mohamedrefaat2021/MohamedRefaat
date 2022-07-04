using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohamedRefaat.Domain.Models.Order
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public MohamedRefaat.Domain.Models.Customer.Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }


    }
}

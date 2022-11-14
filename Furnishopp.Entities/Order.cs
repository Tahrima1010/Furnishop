using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnishopp.Entities
{
    public class Order
    {

        public int ID { get; set; }
        public List<Product> Products { get; set; }

        public Decimal TotalPrice { get; set; }

        public Customer C_ID { get; set; }
    }
}

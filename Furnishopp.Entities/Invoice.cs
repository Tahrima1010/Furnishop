using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnishopp.Entities
{
    public class Invoice
    {
        public int ID { get; set; }

        public decimal Price { get; set; }

        public Customer C_ID { get; set; }

        public DateTime Date { get; set; }
    }
}

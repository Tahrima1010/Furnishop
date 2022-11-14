using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furnishopp.Entities
{
    public class Rating
    {
        public int ID { get; set; }

        public float rating { get; set; }
        
        public Product P_ID { get; set; }

        public Customer C_ID { get; set; }
    }
}

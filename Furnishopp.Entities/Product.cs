using System.ComponentModel.DataAnnotations;

namespace Furnishopp.Entities
{
    public class Product : BaseEntity
    {


        [Range(1, 1000000)]
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        //public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
    }
}

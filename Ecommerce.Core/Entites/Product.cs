using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entites
{
    public class Product : BaseEntites<int>
    {
        public string Name { get; set; }    

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }

    }
}

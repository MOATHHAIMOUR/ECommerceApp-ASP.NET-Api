namespace Ecommerce.Core.Entites
{
    public class Category : BaseEntites<int>
    {
        public string Name { get; set; }  
        
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>(); 
    }
}

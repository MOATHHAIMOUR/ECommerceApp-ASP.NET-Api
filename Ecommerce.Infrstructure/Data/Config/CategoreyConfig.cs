using Ecommerce.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Ecommerce.Infrstructure.Data.Config
{
    internal class CategoreyConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();

        
            // C (1)  ------ (M) P (FK)
            builder.HasMany(p=>p.Products)
            .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            builder.HasData(new List<Category>
            {
                new Category { Id = 1, Name = "Electronics", Description = "Devices and gadgets including phones, laptops, and more." },
                new Category { Id = 2, Name = "Books", Description = "Wide range of books from different genres and authors." },
                new Category { Id = 3, Name = "Clothing", Description = "Men's, women's, and children's clothing for all seasons." },
                new Category { Id = 4, Name = "Home & Kitchen", Description = "Appliances, furniture, and decor for your home." },
                new Category { Id = 5, Name = "Sports & Outdoors", Description = "Equipment and gear for various sports and outdoor activities." },
                new Category { Id = 6, Name = "Beauty & Personal Care", Description = "Skincare, makeup, and personal hygiene products." },
                new Category { Id = 7, Name = "Toys & Games", Description = "Toys, games, and educational materials for children." },
                new Category { Id = 8, Name = "Automotive", Description = "Car parts, accessories, and tools for vehicle maintenance." },
                new Category { Id = 9, Name = "Health & Wellness", Description = "Health supplements, fitness equipment, and wellness products." },
                new Category { Id = 10, Name = "Office Supplies", Description = "Stationery, organizers, and other essentials for office use." }
            });
        }
    }
}

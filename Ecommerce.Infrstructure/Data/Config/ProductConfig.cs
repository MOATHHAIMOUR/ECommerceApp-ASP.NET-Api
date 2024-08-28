using Ecommerce.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrstructure.Data.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(30).IsRequired();
            builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.HasData(new List<Product>
            {
                 new Product { Id = 1, Name = "Smartphone", CategoryId = 1, Price = 599.99m, Description = "Latest model smartphone with advanced features." },
                 new Product { Id = 2, Name = "Laptop", CategoryId = 1, Price = 999.99m, Description = "High-performance laptop suitable for gaming and work." },
                 new Product { Id = 3, Name = "Fiction Novel", CategoryId = 2, Price = 14.99m, Description = "Bestselling fiction novel by a renowned author." },
                 new Product { Id = 4, Name = "Men's Jacket", CategoryId = 3, Price = 79.99m, Description = "Warm and stylish jacket for winter." },
                 new Product { Id = 5, Name = "Blender", CategoryId = 4, Price = 49.99m, Description = "High-speed blender perfect for smoothies and soups." },
                 new Product { Id = 6, Name = "Tennis Racket", CategoryId = 5, Price = 129.99m, Description = "Professional-grade tennis racket for serious players." },
                 new Product { Id = 7, Name = "Face Cream", CategoryId = 6, Price = 24.99m, Description = "Moisturizing face cream for all skin types." },
                 new Product { Id = 8, Name = "Board Game", CategoryId = 7, Price = 29.99m, Description = "Fun and engaging board game for the whole family." },
                 new Product { Id = 9, Name = "Car Battery", CategoryId = 8, Price = 99.99m, Description = "Durable and long-lasting car battery." },
                 new Product { Id = 10, Name = "Yoga Mat", CategoryId = 9, Price = 19.99m, Description = "Non-slip yoga mat for comfortable workouts." }           
            });
   
        }
    }
}

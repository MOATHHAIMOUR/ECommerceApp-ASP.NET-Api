using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrstructure.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Devices and gadgets including phones, laptops, and more.", "Electronics" },
                    { 2, "Wide range of books from different genres and authors.", "Books" },
                    { 3, "Men's, women's, and children's clothing for all seasons.", "Clothing" },
                    { 4, "Appliances, furniture, and decor for your home.", "Home & Kitchen" },
                    { 5, "Equipment and gear for various sports and outdoor activities.", "Sports & Outdoors" },
                    { 6, "Skincare, makeup, and personal hygiene products.", "Beauty & Personal Care" },
                    { 7, "Toys, games, and educational materials for children.", "Toys & Games" },
                    { 8, "Car parts, accessories, and tools for vehicle maintenance.", "Automotive" },
                    { 9, "Health supplements, fitness equipment, and wellness products.", "Health & Wellness" },
                    { 10, "Stationery, organizers, and other essentials for office use.", "Office Supplies" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Latest model smartphone with advanced features.", "Smartphone", 599.99m },
                    { 2, 1, "High-performance laptop suitable for gaming and work.", "Laptop", 999.99m },
                    { 3, 2, "Bestselling fiction novel by a renowned author.", "Fiction Novel", 14.99m },
                    { 4, 3, "Warm and stylish jacket for winter.", "Men's Jacket", 79.99m },
                    { 5, 4, "High-speed blender perfect for smoothies and soups.", "Blender", 49.99m },
                    { 6, 5, "Professional-grade tennis racket for serious players.", "Tennis Racket", 129.99m },
                    { 7, 6, "Moisturizing face cream for all skin types.", "Face Cream", 24.99m },
                    { 8, 7, "Fun and engaging board game for the whole family.", "Board Game", 29.99m },
                    { 9, 8, "Durable and long-lasting car battery.", "Car Battery", 99.99m },
                    { 10, 9, "Non-slip yoga mat for comfortable workouts.", "Yoga Mat", 19.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}

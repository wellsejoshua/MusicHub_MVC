using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicHub.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsAndSongsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Album = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Collaborators = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Discriminator", "ImageUrl", "ListPrice", "Name", "Price", "Price100", "Price50", "Type" },
                values: new object[] { 1, 2, "Shirt based off of the Home single by Daniel Fears.", "Product", null, 30.0, "Coming Home Shirt", 30.0, 22.0, 25.0, "Physical" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Album", "Artist", "CategoryId", "Collaborators", "Description", "Discriminator", "ImageUrl", "Label", "ListPrice", "Name", "Price", "Price100", "Price50", "ReleaseDate", "Type" },
                values: new object[,]
                {
                    { 2, null, "Daniel Fears", 1, "[\"Nathaniel Earl\"]", "Home (Live from the Draylen Mason Music Studio)", "Song", null, null, 2.0, "Home (Live from the Draylen Mason Music Studio)", 2.0, 2.0, 2.0, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digital" },
                    { 3, null, "Daniel Fears", 1, null, "Your Light Is Enough", "Song", null, null, 2.0, "Enough", 2.0, 2.0, 2.0, new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digital" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

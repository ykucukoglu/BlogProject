using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("5be059bf-e1a0-4064-86a2-69c05e5a17fe"), "Admin", new DateTime(2024, 2, 18, 1, 38, 8, 217, DateTimeKind.Local).AddTicks(7273), null, null, false, null, null, "Ekonomi" },
                    { new Guid("e8661e76-15bb-438d-a259-d5639fe02087"), "Admin", new DateTime(2024, 2, 18, 1, 38, 8, 217, DateTimeKind.Local).AddTicks(7268), null, null, false, null, null, "Spor" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("c114004b-8d5b-4882-a5f4-909b5ea2f766"), "Admin", new DateTime(2024, 2, 18, 1, 38, 8, 217, DateTimeKind.Local).AddTicks(7514), null, null, "Image 1", "jpg", false, null, null },
                    { new Guid("e9c490b2-9834-4baf-973b-003a3f938b74"), "Admin", new DateTime(2024, 2, 18, 1, 38, 8, 217, DateTimeKind.Local).AddTicks(7521), null, null, "Image 2", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("25b8681c-837f-4d01-8736-3cb338b88a2d"), new Guid("5be059bf-e1a0-4064-86a2-69c05e5a17fe"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin", new DateTime(2024, 2, 18, 1, 38, 8, 217, DateTimeKind.Local).AddTicks(6801), null, null, new Guid("e9c490b2-9834-4baf-973b-003a3f938b74"), false, null, null, "Deneme Makale 2", 15 },
                    { new Guid("359e6e70-a545-4721-98e9-e63f09e0df3c"), new Guid("e8661e76-15bb-438d-a259-d5639fe02087"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin", new DateTime(2024, 2, 18, 1, 38, 8, 217, DateTimeKind.Local).AddTicks(6787), null, null, new Guid("c114004b-8d5b-4882-a5f4-909b5ea2f766"), false, null, null, "Deneme Makale 1", 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("25b8681c-837f-4d01-8736-3cb338b88a2d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("359e6e70-a545-4721-98e9-e63f09e0df3c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5be059bf-e1a0-4064-86a2-69c05e5a17fe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8661e76-15bb-438d-a259-d5639fe02087"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c114004b-8d5b-4882-a5f4-909b5ea2f766"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e9c490b2-9834-4baf-973b-003a3f938b74"));
        }
    }
}

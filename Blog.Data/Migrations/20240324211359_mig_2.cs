using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Blog.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6cfafa54-b1c1-42ad-b94a-8fe8af77dff7"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e1357d19-0d58-4bbb-a327-672a733f4f46"));

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
                columns: table => new
                {
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitors", x => new { x.ArticleId, x.VisitorId });
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("74e6c183-4438-451e-a738-d7dbf59b0a90"), new Guid("5be059bf-e1a0-4064-86a2-69c05e5a17fe"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin", new DateTime(2024, 3, 25, 0, 13, 59, 222, DateTimeKind.Local).AddTicks(1653), null, null, new Guid("e9c490b2-9834-4baf-973b-003a3f938b74"), false, null, null, "Deneme Makale 2", new Guid("9d07d919-2662-44a7-bef3-1e2d4c52cfca"), 15 },
                    { new Guid("a94b6109-ffcf-4d64-85cb-4204aa773906"), new Guid("e8661e76-15bb-438d-a259-d5639fe02087"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin", new DateTime(2024, 3, 25, 0, 13, 59, 222, DateTimeKind.Local).AddTicks(1637), null, null, new Guid("c114004b-8d5b-4882-a5f4-909b5ea2f766"), false, null, null, "Deneme Makale 1", new Guid("621a6b12-5ae7-410c-8762-5a75c548078c"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("75f08b66-24e2-4235-b171-e25fd9da4650"),
                column: "ConcurrencyStamp",
                value: "2fa4788e-9c7b-4cae-b28d-7cf9971705fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8a1cf120-7e01-4a16-bcf1-4d9e86e75f5d"),
                column: "ConcurrencyStamp",
                value: "ac40259f-974b-43b8-b281-67c9ae428d71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("afd769ff-e920-4880-bbf2-93afe86160e5"),
                column: "ConcurrencyStamp",
                value: "ac2e4858-b56b-4cf2-8a32-7437bd086aa9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("621a6b12-5ae7-410c-8762-5a75c548078c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc81d263-b9e2-460e-847c-4f8d6af12d89", "AQAAAAEAACcQAAAAEGY5Z8gUrwLhTVyZbyfLyybd6aR2b0ZScc/XSHiaXP1mpXgWgUhDir+XCT+XnwUPKQ==", "8f24f15d-07a7-480d-9cd9-abb2b538a195" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d07d919-2662-44a7-bef3-1e2d4c52cfca"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6ad4e06-c047-4cb3-a3ee-07bbd7b5bb1c", "AQAAAAEAACcQAAAAEJ9o+w5e3trzTp32MFyDfYQUKOxXrjYX1emybGq2CIWHFOqfYAiuM98j6eyn+m/z/Q==", "7f17212c-12f8-4b5c-943e-71273ed2b79c" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5be059bf-e1a0-4064-86a2-69c05e5a17fe"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 0, 13, 59, 222, DateTimeKind.Local).AddTicks(5051));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8661e76-15bb-438d-a259-d5639fe02087"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 0, 13, 59, 222, DateTimeKind.Local).AddTicks(5024));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c114004b-8d5b-4882-a5f4-909b5ea2f766"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 0, 13, 59, 222, DateTimeKind.Local).AddTicks(5318));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e9c490b2-9834-4baf-973b-003a3f938b74"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 25, 0, 13, 59, 222, DateTimeKind.Local).AddTicks(5324));

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("74e6c183-4438-451e-a738-d7dbf59b0a90"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("a94b6109-ffcf-4d64-85cb-4204aa773906"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "ModifiedBy", "ModifiedDate", "Title", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("6cfafa54-b1c1-42ad-b94a-8fe8af77dff7"), new Guid("e8661e76-15bb-438d-a259-d5639fe02087"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin", new DateTime(2024, 2, 20, 23, 33, 30, 690, DateTimeKind.Local).AddTicks(391), null, null, new Guid("c114004b-8d5b-4882-a5f4-909b5ea2f766"), false, null, null, "Deneme Makale 1", new Guid("621a6b12-5ae7-410c-8762-5a75c548078c"), 15 },
                    { new Guid("e1357d19-0d58-4bbb-a327-672a733f4f46"), new Guid("5be059bf-e1a0-4064-86a2-69c05e5a17fe"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", "Admin", new DateTime(2024, 2, 20, 23, 33, 30, 690, DateTimeKind.Local).AddTicks(405), null, null, new Guid("e9c490b2-9834-4baf-973b-003a3f938b74"), false, null, null, "Deneme Makale 2", new Guid("9d07d919-2662-44a7-bef3-1e2d4c52cfca"), 15 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("75f08b66-24e2-4235-b171-e25fd9da4650"),
                column: "ConcurrencyStamp",
                value: "5b77d540-3a50-43a5-a4c0-b7d9db6de378");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8a1cf120-7e01-4a16-bcf1-4d9e86e75f5d"),
                column: "ConcurrencyStamp",
                value: "fe85ae57-1c0c-4878-b21f-6f3579aa6413");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("afd769ff-e920-4880-bbf2-93afe86160e5"),
                column: "ConcurrencyStamp",
                value: "a65db9af-d51d-4258-ae86-82b4d0d0416b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("621a6b12-5ae7-410c-8762-5a75c548078c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24565767-22b7-48ed-a147-415d2fe837b3", "AQAAAAEAACcQAAAAEM2CUJ4a0S/8G7c+JXbFtVARo2OeQ3W16F8yNpGrVngvjUCl8a4PJIDiKDT4AQPjqQ==", "deb61aad-6141-41bb-b42d-29264305a704" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9d07d919-2662-44a7-bef3-1e2d4c52cfca"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6569d770-20f8-46d1-aafc-0248da08d6ce", "AQAAAAEAACcQAAAAEDdXK9k+LByz7nS5VzGZ5Bktr4P+VqekS75zVMJzj7Rq8O316BgL3iLCOgfhbIEnyg==", "ea690084-161c-4221-84d3-23a188615279" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5be059bf-e1a0-4064-86a2-69c05e5a17fe"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 23, 33, 30, 690, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e8661e76-15bb-438d-a259-d5639fe02087"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 23, 33, 30, 690, DateTimeKind.Local).AddTicks(729));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("c114004b-8d5b-4882-a5f4-909b5ea2f766"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 23, 33, 30, 690, DateTimeKind.Local).AddTicks(881));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("e9c490b2-9834-4baf-973b-003a3f938b74"),
                column: "CreatedDate",
                value: new DateTime(2024, 2, 20, 23, 33, 30, 690, DateTimeKind.Local).AddTicks(886));
        }
    }
}

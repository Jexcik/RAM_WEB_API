using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Migrations
{
    /// <inheritdoc />
    public partial class MigrationTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentications", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b74c6bba-0401-42c7-86c7-850e2b943eec", "AQAAAAIAAYagAAAAECAOAbP6fLlyECtxN0WfzE7zEMu6wxmkcUIQw0sURTzjmYTr/RR56s7VTW5InHH4xw==", "1f41ab08-ee8f-4b39-be61-28fc484788b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49a4a9c3-7330-4881-b91b-5dccca2d5ed4", "AQAAAAIAAYagAAAAEF6bMH9IgnhRSx9oOGO1DjNNgEwlAVzgDS7FpRLQT+S6YA+iz7BhLcQCdVxM1BPAIA==", "db2b54e5-44b7-4d55-bbc7-8cdade727921" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authentications");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d994e70-1fa7-42a9-8ffe-866e1788af33", "AQAAAAIAAYagAAAAEADheR8fXl610G2fSMgQQS3zwCv13WLzV82t4mOZ8RLzHSRCZLatShKuNTecxNVHQQ==", "f3d46e82-4c46-4c0f-a81f-16135586454b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c2c24eac-cce1-4f1d-86ea-d211b5f955bb", "AQAAAAIAAYagAAAAECqS3AM/ucl93mO4V1LSJwl1UJACUy8cdBGqJqH1gyH7Ikj3TqXeg5Zf0gobZuIPlA==", "ffa4e82a-8fb7-4db9-a3ee-828b7475dc3a" });
        }
    }
}

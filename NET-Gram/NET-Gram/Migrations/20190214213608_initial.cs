using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NET_Gram.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Caption = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "ID", "Caption", "Rating", "Title", "URL" },
                values: new object[,]
                {
                    { 1, "In a field of dreams", 4, "flowers", "flowers.jpg" },
                    { 2, "In a bathtub", 3, "bubbles", "bubbles.jpg" },
                    { 3, "On cloud nine", 4, "clouds", "cloud.jpg" },
                    { 4, "I love food", 5, "food", "food.jpg" },
                    { 5, "I like it", 4, "makeup", "makeup.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}

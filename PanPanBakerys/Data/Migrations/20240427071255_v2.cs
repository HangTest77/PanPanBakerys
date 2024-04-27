using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanPanBakerys.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFileName",
                table: "CakeBookings",
                newName: "ImageName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageName",
                table: "CakeBookings",
                newName: "ImageFileName");
        }
    }
}

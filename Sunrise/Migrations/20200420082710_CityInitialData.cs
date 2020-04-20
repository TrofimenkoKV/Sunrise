using Microsoft.EntityFrameworkCore.Migrations;

namespace sunrise.Migrations
{
    public partial class CityInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO `dotnet`.`city` (`city_name`, `longitude`, `latitude`) VALUES ('Lviv', '12.43', '12.32');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}

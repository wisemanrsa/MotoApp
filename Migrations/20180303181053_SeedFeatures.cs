using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCOREDEMO.Migrations
{
    public partial class SeedFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('Cruise Control')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('PDC')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('App Connect')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('USB')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('Fog Lights')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('Cornering Lights')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('Sunroof')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('Leather Seats')");
            migrationBuilder.Sql("INSERT INTO  Features (Name) VALUES('Alloy Wheels')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");
            migrationBuilder.Sql("delete from  Features");
        }
    }
}

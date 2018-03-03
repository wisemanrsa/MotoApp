using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ASPNETCOREDEMO.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MAKES(Name) VALUES('Volswagen')");
            migrationBuilder.Sql("INSERT INTO MAKES(Name) VALUES('Audi')");
            migrationBuilder.Sql("INSERT INTO MAKES(Name) VALUES('BMW')");
            migrationBuilder.Sql("INSERT INTO MAKES(Name) VALUES('Mercedez Benz')");
            migrationBuilder.Sql("INSERT INTO MAKES(Name) VALUES('Renault')");


            //VW Models
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Polo', (SELECT Id FROM MAKES where Name='Volswagen'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Tiguan', (SELECT Id FROM MAKES where Name='Volswagen'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Golf', (SELECT Id FROM MAKES where Name='Volswagen'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Kumbi', (SELECT Id FROM MAKES where Name='Volswagen'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Up', (SELECT Id FROM MAKES where Name='Volswagen'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Jetta', (SELECT Id FROM MAKES where Name='Volswagen'))");


            //Audi Models
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('A1', (SELECT Id FROM MAKES where Name='Audi'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('A3', (SELECT Id FROM MAKES where Name='Audi'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('A4', (SELECT Id FROM MAKES where Name='Audi'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('A5', (SELECT Id FROM MAKES where Name='Audi'))");
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('RS3', (SELECT Id FROM MAKES where Name='Audi'))");

            //BMW Models
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('1 Series', (SELECT Id FROM MAKES where Name='BMW'))");         
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('X6', (SELECT Id FROM MAKES where Name='BMW'))");         
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('M6', (SELECT Id FROM MAKES where Name='BMW'))");         
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('3 Series', (SELECT Id FROM MAKES where Name='BMW'))");         
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('i8', (SELECT Id FROM MAKES where Name='BMW'))");     

            //Mercedez Models
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('A Class', (SELECT Id FROM MAKES where Name='Mercedez Benz'))");            
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('B Class', (SELECT Id FROM MAKES where Name='Mercedez Benz'))");            
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('C Class', (SELECT Id FROM MAKES where Name='Mercedez Benz'))");            
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Coupe', (SELECT Id FROM MAKES where Name='Mercedez Benz'))");

            //Renault
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Clio', (SELECT Id FROM MAKES where Name='Renault'))");      
            migrationBuilder.Sql("INSERT INTO Models(Name, MakeId) VALUES ('Kwid', (SELECT Id FROM MAKES where Name='Renault'))");      

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.Sql("DELETE FROM MAKES where Name IN ('Renault', 'Mercedez Benz', 'BMW', 'Audi', 'Volswagen')");
        }
    }
} 

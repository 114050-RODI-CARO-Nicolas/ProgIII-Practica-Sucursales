using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Sucursales_Practica.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("1ffea04c-7a46-4551-8ed3-0df6cd6fac2f"));

            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("54428a1a-8523-4a3c-95e8-5623066a3515"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("1f2d4f9b-bb35-48ce-b02d-9d3587bafff0"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("3f7af306-b9c2-4c50-b291-ab4fab33161a"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("8249917f-7c96-43cb-8c72-f7460ed65ff6"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("65e3efe6-bc45-4038-ae5a-787900a56ca5"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("91c544ee-eadf-4694-9fff-a05e31d3e028"));

            migrationBuilder.InsertData(
                table: "Configuraciones",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[,]
                {
                    { new Guid("0afc4a45-f373-4672-a9ec-70c21f1d4241"), "padding-top", "50px" },
                    { new Guid("13aff489-c1db-45ee-8cee-9d33ac83e6eb"), "padding-left", "100px" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("747df057-f50b-45e0-b3dd-1eb8170a8f57"), "Buenos Aires" },
                    { new Guid("c25e4add-ae58-45e9-b738-0d1283f79090"), "Santa Fe" },
                    { new Guid("d1eca1f9-720c-4af0-94d6-bce8610f8175"), "Cordoba" }
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("a668009c-1598-44f6-a271-6fb645c24cf6"), "Pequeña" },
                    { new Guid("c82c4b6f-15ee-4223-a31c-8a36df93defe"), "Grande" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("0afc4a45-f373-4672-a9ec-70c21f1d4241"));

            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("13aff489-c1db-45ee-8cee-9d33ac83e6eb"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("747df057-f50b-45e0-b3dd-1eb8170a8f57"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("c25e4add-ae58-45e9-b738-0d1283f79090"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("d1eca1f9-720c-4af0-94d6-bce8610f8175"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("a668009c-1598-44f6-a271-6fb645c24cf6"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("c82c4b6f-15ee-4223-a31c-8a36df93defe"));

            migrationBuilder.InsertData(
                table: "Configuraciones",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[,]
                {
                    { new Guid("1ffea04c-7a46-4551-8ed3-0df6cd6fac2f"), "padding-top", "50px" },
                    { new Guid("54428a1a-8523-4a3c-95e8-5623066a3515"), "padding-left", "100px" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("1f2d4f9b-bb35-48ce-b02d-9d3587bafff0"), "Buenos Aires" },
                    { new Guid("3f7af306-b9c2-4c50-b291-ab4fab33161a"), "Cordoba" },
                    { new Guid("8249917f-7c96-43cb-8c72-f7460ed65ff6"), "Santa Fe" }
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("65e3efe6-bc45-4038-ae5a-787900a56ca5"), "Grande" },
                    { new Guid("91c544ee-eadf-4694-9fff-a05e31d3e028"), "Pequeña" }
                });
        }
    }
}

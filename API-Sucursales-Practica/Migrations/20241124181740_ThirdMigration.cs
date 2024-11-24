using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Sucursales_Practica.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("418cd697-aecc-440c-93c4-f2d0f8c9e4fb"), "padding-left", "100px" },
                    { new Guid("a4abfabb-c1c1-4bad-ab6a-5b57280398b4"), "padding-top", "50px" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("3c303cf7-5158-469f-bd54-674cbf7a4919"), "Cordoba" },
                    { new Guid("4ba03300-6238-4324-9e71-d28e909cfe3a"), "Santa Fe" },
                    { new Guid("72a6acca-d30b-44b1-b56d-7c07c7806a3e"), "Buenos Aires" }
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("5508f652-5d4e-4e35-9b64-4a3fd033d4d1"), "Grande" },
                    { new Guid("8b832d7b-44c9-4158-95b4-1e01b0a1b285"), "Pequeña" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("418cd697-aecc-440c-93c4-f2d0f8c9e4fb"));

            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("a4abfabb-c1c1-4bad-ab6a-5b57280398b4"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("3c303cf7-5158-469f-bd54-674cbf7a4919"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("4ba03300-6238-4324-9e71-d28e909cfe3a"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("72a6acca-d30b-44b1-b56d-7c07c7806a3e"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("5508f652-5d4e-4e35-9b64-4a3fd033d4d1"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("8b832d7b-44c9-4158-95b4-1e01b0a1b285"));

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
    }
}

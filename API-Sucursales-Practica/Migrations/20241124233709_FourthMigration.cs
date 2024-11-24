using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API_Sucursales_Practica.Migrations
{
    /// <inheritdoc />
    public partial class FourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ApellidoTitual",
                table: "Sucursales",
                newName: "ApellidoTitular");

            migrationBuilder.InsertData(
                table: "Configuraciones",
                columns: new[] { "Id", "Nombre", "Valor" },
                values: new object[,]
                {
                    { new Guid("43da7009-eabb-4616-a888-8d50714a219d"), "padding-left", "100px" },
                    { new Guid("455c5498-77ee-4589-99da-32c7cb7a62ce"), "padding-top", "50px" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("3b04a1ad-fafd-4142-837e-5f02816c3649"), "Cordoba" },
                    { new Guid("a76b2a6c-3ef4-49dc-b8e5-690dda627417"), "Buenos Aires" },
                    { new Guid("e34a14e4-7c89-4609-a06b-86954e690aca"), "Santa Fe" }
                });

            migrationBuilder.InsertData(
                table: "Tipos",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { new Guid("4a3e9f04-c7a7-4b4e-98a5-2f7277599bcc"), "Pequeña" },
                    { new Guid("cc8c9384-1290-4d66-b379-a5d0b24fcaa4"), "Grande" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("43da7009-eabb-4616-a888-8d50714a219d"));

            migrationBuilder.DeleteData(
                table: "Configuraciones",
                keyColumn: "Id",
                keyValue: new Guid("455c5498-77ee-4589-99da-32c7cb7a62ce"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("3b04a1ad-fafd-4142-837e-5f02816c3649"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("a76b2a6c-3ef4-49dc-b8e5-690dda627417"));

            migrationBuilder.DeleteData(
                table: "Provincias",
                keyColumn: "Id",
                keyValue: new Guid("e34a14e4-7c89-4609-a06b-86954e690aca"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("4a3e9f04-c7a7-4b4e-98a5-2f7277599bcc"));

            migrationBuilder.DeleteData(
                table: "Tipos",
                keyColumn: "Id",
                keyValue: new Guid("cc8c9384-1290-4d66-b379-a5d0b24fcaa4"));

            migrationBuilder.RenameColumn(
                name: "ApellidoTitular",
                table: "Sucursales",
                newName: "ApellidoTitual");

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
    }
}

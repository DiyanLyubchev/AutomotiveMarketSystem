using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutomotiveMarketSystem.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarModelId",
                table: "CAR",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishDate",
                table: "ADVERTISEMENTS",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "7b22e9f9-d4e5-4bb6-928e-139376d26ee4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f05a8a98-154a-430a-9778-791a5e339791", "AQAAAAEAACcQAAAAEN6R0tOsGW1AGb06eXNj8hqvMkapVn77lsNDmPFuHOoWtC184a3gSDrSj9INB1qzbQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "94fea588-b741-4b13-8a18-fc0081b202ab", "AQAAAAEAACcQAAAAEGwsVG/732Ojr3WktB2jAcpJifeU/xKJpkUKsvkzX7JaBatI385TzZZ9k+mQ2HTTQQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "CAR");

            migrationBuilder.DropColumn(
                name: "PublishDate",
                table: "ADVERTISEMENTS");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca678235-7571-4177-984f-e9d1957b0187",
                column: "ConcurrencyStamp",
                value: "ce259295-2494-419f-ac68-b9c0d2051936");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c23c3678-6194-4b7e-a928-09614190eb62",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4ad11f0d-4d63-4ffc-895c-1fb94ec295fb", "AQAAAAEAACcQAAAAENGymNN87dKbBYryfGxAx2n67ZG0Gfkpp+ulm3+le94q+7oEEkPqrSFoMtkUBB+owA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a66c0ba3-517f-469f-9c80-2e55f20c9eef", "AQAAAAEAACcQAAAAENo+KL5ZMkQdZ5QDZxLli9vZ7mWpT/fbgyCMlZUWcfXPIaB1OPxrAMD1fpXZKRhAzw==" });
        }
    }
}

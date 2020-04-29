using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace AutomotiveMarketSystem.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CARBRAND",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    BRANDNAME = table.Column<string>(type: "VARCHAR2(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARBRAND", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENGINETYPESTATUS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    ENGINETYPE = table.Column<string>(type: "VARCHAR2(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENGINETYPESTATUS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CARMODEL",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    MODELNAME = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CARBRANDID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARMODEL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CARMODEL_CARBRAND_CARBRANDID",
                        column: x => x.CARBRANDID,
                        principalTable: "CARBRAND",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CAR",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    CARBRANDID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ENGINE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DOOR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PRODUCTIONYEAR = table.Column<DateTime>(type: "DATE", nullable: false),
                    PRICE = table.Column<decimal>(type: "NUMBER", nullable: false),
                    EngineTypeStatusId = table.Column<int>(nullable: false),
                    AdvertisementId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CAR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CAR_CARBRAND_CARBRANDID",
                        column: x => x.CARBRANDID,
                        principalTable: "CARBRAND",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CAR_ENGINETYPESTATUS_EngineTypeStatusId",
                        column: x => x.EngineTypeStatusId,
                        principalTable: "ENGINETYPESTATUS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ADVERTISEMENTS",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true),
                    CARID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADVERTISEMENTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ADVERTISEMENTS_CAR_CARID",
                        column: x => x.CARID,
                        principalTable: "CAR",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ADVERTISEMENTS_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "ca678235-7571-4177-984f-e9d1957b0187", "92237e4a-e193-44ae-82d2-5a340f3ea298", "UserRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c23c3678-6194-4b7e-a928-09614190eb62", 0, "4952d522-a862-4544-83e6-cbeab6f85070", "admin1@admin.com", false, true, null, "ADMIN1@ADMIN.COM", "DIYAN", "AQAAAAEAACcQAAAAENXgIFbhPnTwwMIJqW5USRb7VbDdRlmHsaUYY6JGUCmtVNaVHIkyrzTv1nYv0bZjtg==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "Diyan" },
                    { "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c", 0, "b1a7f4ae-d1e2-41ad-b28a-02a3335b3383", "admin2@admin.com", false, true, null, "ADMIN2@ADMIN.COM", "IVAN", "AQAAAAEAACcQAAAAELZ2Ux6w8hhKBf0I8KoK7UvmbLEYBEqgFMmV4tR+HYZvIxt543/Q7x1UUwWdQvG8og==", null, false, "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU", false, "Ivan" }
                });

            migrationBuilder.InsertData(
                table: "CARBRAND",
                columns: new[] { "Id", "BRANDNAME" },
                values: new object[,]
                {
                    { 1, "Seat" },
                    { 2, "Renault" }
                });

            migrationBuilder.InsertData(
                table: "ENGINETYPESTATUS",
                columns: new[] { "Id", "ENGINETYPE" },
                values: new object[,]
                {
                    { 1, "Gas" },
                    { 2, "Diesel" },
                    { 3, "Electric" },
                    { 4, "Hybrid" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "c23c3678-6194-4b7e-a928-09614190eb62", "ca678235-7571-4177-984f-e9d1957b0187" },
                    { "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c", "ca678235-7571-4177-984f-e9d1957b0187" }
                });

            migrationBuilder.InsertData(
                table: "CARMODEL",
                columns: new[] { "Id", "CARBRANDID", "MODELNAME" },
                values: new object[,]
                {
                    { 1, 1, "Alhambra" },
                    { 2, 1, "Ibiza" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADVERTISEMENTS_CARID",
                table: "ADVERTISEMENTS",
                column: "CARID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ADVERTISEMENTS_UserId",
                table: "ADVERTISEMENTS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CAR_CARBRANDID",
                table: "CAR",
                column: "CARBRANDID");

            migrationBuilder.CreateIndex(
                name: "IX_CAR_EngineTypeStatusId",
                table: "CAR",
                column: "EngineTypeStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CARMODEL_CARBRANDID",
                table: "CARMODEL",
                column: "CARBRANDID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADVERTISEMENTS");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CARMODEL");

            migrationBuilder.DropTable(
                name: "CAR");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CARBRAND");

            migrationBuilder.DropTable(
                name: "ENGINETYPESTATUS");
        }
    }
}

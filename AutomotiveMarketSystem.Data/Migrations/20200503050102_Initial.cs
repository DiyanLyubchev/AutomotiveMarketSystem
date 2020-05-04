using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Oracle.EntityFrameworkCore.Metadata;

namespace AutomotiveMarketSystem.Data.Migrations
{
    public partial class Initial : Migration
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
                    DOOR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PRODUCTIONYEAR = table.Column<DateTime>(type: "DATE", nullable: false),
                    PRICE = table.Column<decimal>(type: "NUMBER", nullable: false),
                    CARBRANDID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CarModelId = table.Column<int>(nullable: false),
                    ENGINETYPESTATUSID = table.Column<int>(type: "NUMBER(10)", nullable: false)
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
                        name: "FK_CAR_ENGINETYPESTATUS_ENGINETYPESTATUSID",
                        column: x => x.ENGINETYPESTATUSID,
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
                    CARID = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PublishDate = table.Column<DateTime>(nullable: false)
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
                values: new object[] { "ca678235-7571-4177-984f-e9d1957b0187", "348dea58-4bf5-4f63-9168-0e6acbee9695", "UserRole", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c23c3678-6194-4b7e-a928-09614190eb62", 0, "b57e86ee-039a-4525-a650-278b0f469ce3", "admin1@admin.com", false, true, null, "ADMIN1@ADMIN.COM", "DIYAN", "AQAAAAEAACcQAAAAEC9Pa7EMr9x5oVXuRFR0zVKml6jrrKom52ed6y1qBoYEB1Cp6RnfiJLMSzo2gnK2vg==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "Diyan" },
                    { "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c", 0, "9565b94e-c298-443c-8fcd-a0af6479fd23", "admin2@admin.com", false, true, null, "ADMIN2@ADMIN.COM", "IVAN", "AQAAAAEAACcQAAAAELprfrSNSpEMEeDaeDWJ68uT7BNlmnsWssj6H2trq1ns6Ic1clgX1ccAsMQtEGvGMA==", null, false, "74CLJEIXNYLPRXMVXXNSWXZH6R6KJRRU", false, "Ivan" }
                });

            migrationBuilder.InsertData(
                table: "CARBRAND",
                columns: new[] { "Id", "BRANDNAME" },
                values: new object[,]
                {
                    { 24, "Land Rover" },
                    { 25, "Dodge" },
                    { 26, "Chrysler" },
                    { 27, "Ford" },
                    { 28, "Hummer" },
                    { 29, "Hyundai" },
                    { 30, "Infiniti" },
                    { 32, "Jeep" },
                    { 33, "Nissan" },
                    { 34, "Volvo" },
                    { 35, "Daewoo" },
                    { 36, "Fiat" },
                    { 37, "MINI" },
                    { 38, "Rover" },
                    { 39, "Smart" },
                    { 31, "Jaguar" },
                    { 22, "Audi" },
                    { 23, "Kia" },
                    { 20, "Mercedes-Benz" },
                    { 2, "Renault" },
                    { 3, "Peugeot" },
                    { 4, "Dacia" },
                    { 5, "Citro�n" },
                    { 6, "Opel" },
                    { 7, "Alfa Romeo" },
                    { 21, "Saab" },
                    { 9, "Chevrolet" },
                    { 10, "Porsche" },
                    { 8, "Skoda" },
                    { 12, "Subaru" },
                    { 13, "Mazda" },
                    { 14, "Mitsubishi" },
                    { 15, "Lexus" },
                    { 16, "Toyota" },
                    { 17, "BMW" },
                    { 18, "Volkswagen" },
                    { 19, "Suzuki" },
                    { 11, "Honda" },
                    { 1, "Seat" }
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
                    { "d5b2211a-4ddc-4451-af5e-36b5cfad9a2c", "ca678235-7571-4177-984f-e9d1957b0187" },
                    { "c23c3678-6194-4b7e-a928-09614190eb62", "ca678235-7571-4177-984f-e9d1957b0187" }
                });

            migrationBuilder.InsertData(
                table: "CARMODEL",
                columns: new[] { "Id", "CARBRANDID", "MODELNAME" },
                values: new object[,]
                {
                    { 852, 39, "Fortwo cabrio" },
                    { 564, 23, "Sephia" },
                    { 565, 23, "Shuma" },
                    { 566, 23, "Sorento" },
                    { 567, 23, "Soul" },
                    { 568, 23, "Sportage" },
                    { 569, 23, "Venga" },
                    { 570, 24, "Discovery" },
                    { 571, 24, "Defender" },
                    { 572, 24, "Discovery Sport" },
                    { 573, 24, "Range Rover" },
                    { 563, 23, "Rio sedan" },
                    { 574, 24, "Freelander" },
                    { 576, 24, "Range Rover Sport" },
                    { 577, 25, "Challenger" },
                    { 578, 25, "Caliber" },
                    { 579, 25, "Charger" },
                    { 580, 25, "Journey" },
                    { 581, 25, "Grand Caravan" },
                    { 582, 25, "Stealth" },
                    { 583, 25, "Magnum" },
                    { 584, 25, "RAM" },
                    { 585, 25, "Nitro" },
                    { 575, 24, "Range Rover Evoque" },
                    { 562, 23, "Rio Combi" },
                    { 561, 23, "Rio" },
                    { 560, 23, "Pro Cee`d" },
                    { 537, 22, "S4 Cabriolet" },
                    { 538, 22, "S4/S4 Avant" },
                    { 539, 22, "S5/S5 Cabriolet" },
                    { 540, 22, "S6/RS6" },
                    { 541, 22, "S7" },
                    { 542, 22, "S8" },
                    { 543, 22, "SQ5" },
                    { 544, 22, "TT Coupe" },
                    { 545, 22, "TT Roadster" },
                    { 546, 22, "TTS" },
                    { 547, 23, "Carens" },
                    { 548, 23, "Besta" },
                    { 549, 23, "Carnival" },
                    { 550, 23, "Cee`d SW" },
                    { 551, 23, "Cee`d" },
                    { 552, 23, "Opirus" },
                    { 553, 23, "Cerato" },
                    { 554, 23, "Magentis" },
                    { 555, 23, "K 2500" },
                    { 556, 23, "Pregio" },
                    { 557, 23, "Picanto" },
                    { 558, 23, "Optima" },
                    { 559, 23, "Pride" },
                    { 586, 25, "Viper" },
                    { 536, 22, "S3/S3 Sportback" },
                    { 587, 26, "300 M" },
                    { 589, 26, "Crossfire" },
                    { 617, 27, "Focus kombi" },
                    { 618, 27, "Fusion" },
                    { 619, 27, "Galaxy" },
                    { 620, 27, "Grand C-Max" },
                    { 621, 27, "Ka" },
                    { 622, 27, "Kuga" },
                    { 623, 27, "Maverick" },
                    { 624, 27, "Mondeo" },
                    { 625, 27, "Mondeo Combi" },
                    { 626, 27, "Mustang" },
                    { 616, 27, "Focus CC" },
                    { 627, 27, "Orion" },
                    { 629, 27, "Ranger" },
                    { 630, 27, "S-Max" },
                    { 631, 27, "Sierra" },
                    { 632, 27, "Street Ka" },
                    { 633, 27, "Tourneo Connect" },
                    { 634, 27, "Tourneo Custom" },
                    { 635, 27, "Transit" },
                    { 636, 27, "Transit" },
                    { 637, 27, "Transit Bus" },
                    { 638, 27, "Transit Connect LWB" },
                    { 628, 27, "Puma" },
                    { 615, 27, "Focus C-Max" },
                    { 614, 27, "Focus" },
                    { 613, 27, "F-150" },
                    { 590, 26, "LHS" },
                    { 591, 26, "Grand Voyager" },
                    { 592, 26, "PT Cruiser" },
                    { 593, 26, "Neon" },
                    { 594, 26, "Plymouth" },
                    { 595, 26, "Pacifica" },
                    { 596, 26, "Stratus" },
                    { 597, 26, "Sebring Convertible" },
                    { 598, 26, "Sebring" },
                    { 599, 26, "Stratus Cabrio" },
                    { 600, 26, "Town & Country" },
                    { 601, 26, "Voyager" },
                    { 602, 27, "C-Max" },
                    { 603, 27, "B-Max" },
                    { 604, 27, "Cortina" },
                    { 605, 27, "Edge" },
                    { 606, 27, "Cougar" },
                    { 607, 27, "Explorer" },
                    { 608, 27, "Escort" },
                    { 609, 27, "Escort kombi" },
                    { 610, 27, "Escort Cabrio" },
                    { 611, 27, "Fiesta" },
                    { 612, 27, "F-250" },
                    { 588, 26, "300 C Touring" },
                    { 535, 22, "RS7" },
                    { 534, 22, "RS6 Avant" },
                    { 533, 22, "RS5" },
                    { 457, 20, "AMG GT" },
                    { 458, 20, "Trieda B" },
                    { 459, 20, "Trieda C" },
                    { 460, 20, "C" },
                    { 461, 20, "C Sportcoupe" },
                    { 462, 20, "C T" },
                    { 463, 20, "Citan" },
                    { 464, 20, "CL" },
                    { 465, 20, "CL" },
                    { 466, 20, "CLA" },
                    { 456, 20, "A L" },
                    { 467, 20, "CLC" },
                    { 469, 20, "CLK Coupe" },
                    { 470, 20, "CLS" },
                    { 471, 20, "Trieda E" },
                    { 472, 20, "E" },
                    { 473, 20, "E Cabrio" },
                    { 474, 20, "E Coupe" },
                    { 475, 20, "E T" },
                    { 476, 20, "Trieda G" },
                    { 477, 20, "G Cabrio" },
                    { 478, 20, "GL" },
                    { 468, 20, "CLK Cabrio" },
                    { 455, 20, "A" },
                    { 454, 20, "Trieda A" },
                    { 453, 20, "500 - 600 SEC Coupe" },
                    { 430, 19, "Kizashi" },
                    { 431, 19, "SX4" },
                    { 432, 19, "Swift" },
                    { 433, 19, "Splash" },
                    { 434, 19, "SX4 Sedan" },
                    { 435, 19, "Vitara" },
                    { 436, 19, "Wagon R+" },
                    { 437, 20, "124" },
                    { 438, 20, "115" },
                    { 439, 20, "126" },
                    { 440, 20, "190 D" },
                    { 441, 20, "190" },
                    { 442, 20, "200 E" },
                    { 443, 20, "190 E" },
                    { 444, 20, "200 D" },
                    { 445, 20, "200 - 300" },
                    { 446, 20, "310 Van" },
                    { 447, 20, "210 kombi" },
                    { 448, 20, "210 Van" },
                    { 449, 20, "310 kombi" },
                    { 450, 20, "230 - 300 CE Coupe" },
                    { 451, 20, "260 - 560 SE" },
                    { 452, 20, "260 - 560 SEL" },
                    { 479, 20, "GLA" },
                    { 480, 20, "GLC" },
                    { 481, 20, "GLE" },
                    { 482, 20, "GLK" },
                    { 510, 22, "A3" },
                    { 511, 22, "A2" },
                    { 512, 22, "A4" },
                    { 513, 22, "A3 Sportback" },
                    { 514, 22, "A3 Limuzina" },
                    { 515, 22, "A4 Allroad" },
                    { 516, 22, "A4 Avant" },
                    { 517, 22, "A4 Cabriolet" },
                    { 518, 22, "A5" },
                    { 519, 22, "A5 Cabriolet" },
                    { 520, 22, "A5 Sportback" },
                    { 521, 22, "A6" },
                    { 522, 22, "A6 Allroad" },
                    { 523, 22, "A6 Avant" },
                    { 524, 22, "A7" },
                    { 525, 22, "A8" },
                    { 526, 22, "A8 Long" },
                    { 527, 22, "Q3" },
                    { 528, 22, "Q5" },
                    { 529, 22, "Q7" },
                    { 530, 22, "R8" },
                    { 531, 22, "RS4 Cabriolet" },
                    { 532, 22, "RS4/RS4 Avant" },
                    { 509, 22, "A1" },
                    { 639, 27, "Transit Courier" },
                    { 508, 22, "A3 Cabriolet" },
                    { 506, 22, "90" },
                    { 483, 20, "Trieda M" },
                    { 484, 20, "MB 100" },
                    { 485, 20, "Trieda R" },
                    { 486, 20, "Trieda S" },
                    { 487, 20, "S" },
                    { 488, 20, "S Coupe" },
                    { 489, 20, "SL" },
                    { 490, 20, "SLC" },
                    { 491, 20, "SLK" },
                    { 492, 20, "SLR" },
                    { 493, 20, "Sprinter" }
                });

            migrationBuilder.InsertData(
                table: "CARMODEL",
                columns: new[] { "Id", "CARBRANDID", "MODELNAME" },
                values: new object[,]
                {
                    { 494, 21, "9-3 Coupe" },
                    { 495, 21, "9-3 Cabriolet" },
                    { 496, 21, "9-3 SportCombi" },
                    { 497, 21, "9-5 SportCombi" },
                    { 498, 21, "9-5" },
                    { 499, 21, "9000" },
                    { 500, 21, "900" },
                    { 501, 21, "900 C Turbo" },
                    { 502, 21, "900 C" },
                    { 503, 22, "80" },
                    { 504, 22, "100 Avant" },
                    { 505, 22, "80 Avant" },
                    { 507, 22, "80 Cabrio" },
                    { 853, 39, "Roadster" },
                    { 640, 27, "Transit Custom" },
                    { 642, 27, "Transit Tourneo" },
                    { 777, 35, "Matiz" },
                    { 778, 35, "Nubira" },
                    { 779, 35, "Nexia" },
                    { 780, 35, "Tico" },
                    { 781, 35, "Tacuma" },
                    { 782, 35, "Racer" },
                    { 783, 36, "500" },
                    { 784, 36, "126" },
                    { 785, 36, "500L" },
                    { 786, 36, "850" },
                    { 776, 35, "Nubira kombi" },
                    { 787, 36, "500X" },
                    { 789, 36, "Barchetta" },
                    { 790, 36, "Cinquecento" },
                    { 791, 36, "Brava" },
                    { 792, 36, "Doblo Cargo" },
                    { 793, 36, "Doblo" },
                    { 794, 36, "Croma" },
                    { 795, 36, "Doblo Cargo Combi" },
                    { 796, 36, "Ducato" },
                    { 797, 36, "Ducato Van" },
                    { 798, 36, "Ducato Kombi" },
                    { 788, 36, "Coupe" },
                    { 775, 35, "Leganza" },
                    { 774, 35, "Lublin" },
                    { 773, 35, "Lanos" },
                    { 750, 34, "340" },
                    { 751, 34, "460" },
                    { 752, 34, "850 kombi" },
                    { 753, 34, "850" },
                    { 754, 34, "C70 Coupe" },
                    { 755, 34, "C30" },
                    { 756, 34, "C70 Cabrio" },
                    { 757, 34, "C70" },
                    { 758, 34, "S70" },
                    { 759, 34, "S60" },
                    { 760, 34, "S40" },
                    { 761, 34, "S80" },
                    { 762, 34, "S90" },
                    { 763, 34, "V40" },
                    { 764, 34, "V50" },
                    { 765, 34, "V60" },
                    { 766, 34, "V70" },
                    { 767, 34, "V90" },
                    { 768, 34, "XC60" },
                    { 769, 34, "XC70" },
                    { 770, 34, "XC90" },
                    { 771, 35, "Lacetti" },
                    { 772, 35, "Kalos" },
                    { 799, 36, "Ducato Podvozok" },
                    { 749, 34, "360" },
                    { 800, 36, "Florino" },
                    { 802, 36, "Freemont" },
                    { 830, 37, "Cooper Clubman" },
                    { 831, 37, "Cooper Cabrio" },
                    { 832, 37, "Cooper D" },
                    { 833, 37, "Cooper S" },
                    { 834, 37, "Cooper D Clubman" },
                    { 835, 37, "Mini One" },
                    { 836, 37, "Cooper S Cabrio" },
                    { 837, 37, "Countryman" },
                    { 838, 37, "Cooper S Clubman" },
                    { 839, 37, "One D" },
                    { 829, 36, "X1/9" },
                    { 840, 38, "218" },
                    { 842, 38, "25" },
                    { 843, 38, "414" },
                    { 844, 38, "400" },
                    { 845, 38, "416" },
                    { 846, 38, "75" },
                    { 847, 38, "620" },
                    { 848, 39, "Compact Pulse" },
                    { 849, 39, "City-Coupe" },
                    { 850, 39, "Forfour" },
                    { 851, 39, "Fortwo coupe" },
                    { 841, 38, "214" },
                    { 828, 36, "Uno" },
                    { 827, 36, "Ulysse" },
                    { 826, 36, "Tipo" },
                    { 803, 36, "Grande Punto" },
                    { 804, 36, "Idea" },
                    { 805, 36, "Linea" },
                    { 806, 36, "Marea" },
                    { 807, 36, "Marea Weekend" },
                    { 808, 36, "Multipla" },
                    { 809, 36, "Palio Weekend" },
                    { 810, 36, "Panda" },
                    { 811, 36, "Panda Van" },
                    { 812, 36, "Punto" },
                    { 813, 36, "Punto Cabriolet" },
                    { 814, 36, "Punto Evo" },
                    { 815, 36, "Punto Van" },
                    { 816, 36, "Qubo" },
                    { 817, 36, "Scudo" },
                    { 818, 36, "Scudo Van" },
                    { 819, 36, "Scudo Kombi" },
                    { 820, 36, "Sedici" },
                    { 821, 36, "Seicento" },
                    { 822, 36, "Stilo" },
                    { 823, 36, "Stilo Multiwagon" },
                    { 824, 36, "Strada" },
                    { 825, 36, "Talento" },
                    { 801, 36, "Florino Combi" },
                    { 748, 33, "X-Trail" },
                    { 747, 33, "Vanette Cargo" },
                    { 746, 33, "Trade" },
                    { 670, 29, "Lantra" },
                    { 671, 29, "Matrix" },
                    { 672, 29, "Santa Fe" },
                    { 673, 29, "Sonata" },
                    { 674, 29, "Terracan" },
                    { 675, 29, "Trajet" },
                    { 676, 29, "Tucson" },
                    { 677, 29, "Veloster" },
                    { 678, 30, "G" },
                    { 679, 30, "FX" },
                    { 669, 29, "ix55" },
                    { 680, 30, "G Coupe" },
                    { 682, 30, "M" },
                    { 683, 30, "QX" },
                    { 684, 31, "F-Type" },
                    { 685, 31, "F-Pace" },
                    { 686, 31, "S-Type" },
                    { 687, 31, "X-Type" },
                    { 688, 31, "Sovereign" },
                    { 689, 31, "XJ" },
                    { 690, 31, "X-type Estate" },
                    { 691, 31, "XF" },
                    { 681, 30, "Q" },
                    { 668, 29, "ix35" },
                    { 667, 29, "ix20" },
                    { 666, 29, "i40 CW" },
                    { 643, 27, "Transit Valnik" },
                    { 644, 27, "Transit Van" },
                    { 645, 27, "Transit Van 350" },
                    { 646, 27, "Windstar" },
                    { 647, 28, "H3" },
                    { 648, 29, "Atos Prime" },
                    { 649, 29, "Atos" },
                    { 650, 29, "Coupe" },
                    { 651, 29, "Galloper" },
                    { 652, 29, "Elantra" },
                    { 653, 29, "H 350" },
                    { 654, 29, "Genesis" },
                    { 655, 29, "Grandeur" },
                    { 656, 29, "Getz" },
                    { 657, 29, "H1 Van" },
                    { 658, 29, "H1 Bus" },
                    { 659, 29, "H1" },
                    { 660, 29, "H200" },
                    { 661, 29, "i10" },
                    { 662, 29, "i20" },
                    { 663, 29, "i30" },
                    { 664, 29, "i30 CW" },
                    { 665, 29, "i40" },
                    { 692, 31, "XE" },
                    { 693, 31, "XJ8" },
                    { 694, 31, "XJ6" },
                    { 695, 31, "XJ12" },
                    { 723, 33, "Maxima QX" },
                    { 724, 33, "Micra" },
                    { 725, 33, "Murano" },
                    { 726, 33, "Navara" },
                    { 727, 33, "Note" },
                    { 728, 33, "NP300 Pickup" },
                    { 729, 33, "NV200" },
                    { 730, 33, "NV400" },
                    { 731, 33, "Pathfinder" },
                    { 732, 33, "Patrol" },
                    { 733, 33, "Patrol GR" },
                    { 734, 33, "Pickup" },
                    { 735, 33, "Pixo" },
                    { 736, 33, "Primastar" },
                    { 737, 33, "Primastar Combi" },
                    { 738, 33, "Primera" },
                    { 739, 33, "Primera Combi" },
                    { 740, 33, "Pulsar" },
                    { 741, 33, "Qashqai" },
                    { 742, 33, "Serena" },
                    { 743, 33, "Sunny" },
                    { 744, 33, "Terrano" },
                    { 745, 33, "Tiida" },
                    { 722, 33, "Maxima" },
                    { 429, 19, "Liana" }
                });

            migrationBuilder.InsertData(
                table: "CARMODEL",
                columns: new[] { "Id", "CARBRANDID", "MODELNAME" },
                values: new object[,]
                {
                    { 721, 33, "Leaf" },
                    { 719, 33, "GT-R" },
                    { 696, 31, "XJ8" },
                    { 697, 31, "XJR" },
                    { 698, 31, "XK" },
                    { 699, 31, "XK8 Convertible" },
                    { 700, 31, "XKR" },
                    { 701, 31, "XKR Convertible" },
                    { 702, 32, "Compass" },
                    { 703, 32, "Commander" },
                    { 704, 32, "Grand Cherokee" },
                    { 705, 32, "Renegade" },
                    { 706, 32, "Patriot" },
                    { 707, 32, "Wrangler" },
                    { 708, 33, "350 Z" },
                    { 709, 33, "200 SX" },
                    { 710, 33, "350 Z Roadster" },
                    { 711, 33, "Almera" },
                    { 712, 33, "370 Z" },
                    { 713, 33, "e-NV200" },
                    { 714, 33, "Almera Tino" },
                    { 715, 33, "Cabstar TL2 Valnik" },
                    { 716, 33, "Cabstar E - T" },
                    { 717, 33, "Juke" },
                    { 718, 33, "Insterstar" },
                    { 720, 33, "King Cab" },
                    { 641, 27, "Transit kombi" },
                    { 428, 19, "Jimny" },
                    { 426, 19, "Grand Vitara XL-7" },
                    { 136, 6, "Vivaro Kombi" },
                    { 137, 6, "Zafira" },
                    { 138, 7, "147" },
                    { 139, 7, "146" },
                    { 140, 7, "155" },
                    { 141, 7, "156 Sportwagon" },
                    { 142, 7, "156" },
                    { 143, 7, "166" },
                    { 144, 7, "159" },
                    { 145, 7, "164" },
                    { 135, 6, "Vivaro" },
                    { 146, 7, "159 Sportwagon" },
                    { 148, 7, "Brera" },
                    { 149, 7, "4C" },
                    { 150, 7, "MiTo" },
                    { 151, 7, "Crosswagon" },
                    { 152, 7, "Spider" },
                    { 153, 7, "GT" },
                    { 154, 7, "Giulietta" },
                    { 155, 7, "Giulia" },
                    { 156, 8, "Citigo" },
                    { 157, 8, "Felicia" },
                    { 147, 7, "GTV" },
                    { 134, 6, "Vectra Caravan" },
                    { 133, 6, "Vectra" },
                    { 132, 6, "Signum" },
                    { 109, 5, "Jumpy" },
                    { 110, 5, "Saxo" },
                    { 111, 5, "Nemo" },
                    { 112, 5, "Xantia" },
                    { 113, 5, "Xsara" },
                    { 114, 6, "Antara" },
                    { 115, 6, "Ampera" },
                    { 116, 6, "Astra" },
                    { 117, 6, "Astra caravan" },
                    { 118, 6, "Astra cabrio" },
                    { 119, 6, "Cascada" },
                    { 120, 6, "Astra coupe" },
                    { 121, 6, "Campo" },
                    { 122, 6, "Calibra" },
                    { 123, 6, "Insignia" },
                    { 124, 6, "Frontera" },
                    { 125, 6, "Corsa" },
                    { 126, 6, "Insignia kombi" },
                    { 127, 6, "Kadett" },
                    { 128, 6, "Meriva" },
                    { 129, 6, "Mokka" },
                    { 130, 6, "Movano" },
                    { 131, 6, "Omega" },
                    { 158, 8, "Fabia" },
                    { 159, 8, "Fabia Sedan" },
                    { 160, 8, "Fabia Combi" },
                    { 161, 8, "Roomster" },
                    { 189, 9, "Spark" },
                    { 190, 9, "Suburban" },
                    { 191, 9, "Tacuma" },
                    { 192, 9, "Tahoe" },
                    { 193, 9, "Trax" },
                    { 194, 10, "911 Targa" },
                    { 195, 10, "911 Carrera Cabrio" },
                    { 196, 10, "911 Turbo" },
                    { 197, 10, "944" },
                    { 198, 10, "924" },
                    { 199, 10, "Cayman" },
                    { 200, 10, "997" },
                    { 201, 10, "Cayenne" },
                    { 202, 10, "Boxster" },
                    { 203, 10, "Panamera" },
                    { 204, 10, "Macan" },
                    { 205, 11, "Accord Tourer" },
                    { 206, 11, "Accord Coupe" },
                    { 207, 11, "City" },
                    { 208, 11, "Civic Aerodeck" },
                    { 209, 11, "Civic" },
                    { 210, 11, "CR-V" },
                    { 211, 11, "Civic Coupe" },
                    { 188, 9, "Orlando" },
                    { 108, 5, "Jumper" },
                    { 187, 9, "Nubira" },
                    { 185, 9, "Matiz" },
                    { 162, 8, "Felicia Combi" },
                    { 163, 8, "Octavia Combi" },
                    { 164, 8, "Octavia" },
                    { 165, 8, "Rapid Spaceback" },
                    { 166, 8, "Rapid" },
                    { 167, 8, "Yeti" },
                    { 168, 8, "Superb" },
                    { 169, 8, "Superb Combi" },
                    { 170, 9, "Camaro" },
                    { 171, 9, "Aveo" },
                    { 172, 9, "Captiva" },
                    { 173, 9, "Cruze" },
                    { 174, 9, "Corvette" },
                    { 175, 9, "Evanda" },
                    { 176, 9, "Cruze SW" },
                    { 177, 9, "Equinox" },
                    { 178, 9, "Epica" },
                    { 179, 9, "Lacetti" },
                    { 180, 9, "Kalos" },
                    { 181, 9, "HHR" },
                    { 182, 9, "Lacetti SW" },
                    { 183, 9, "Lumina" },
                    { 184, 9, "Malibu" },
                    { 186, 9, "Monte Carlo" },
                    { 212, 11, "Civic Type R" },
                    { 107, 5, "Evasion" },
                    { 105, 5, "DS4" },
                    { 29, 2, "Latitude" },
                    { 30, 2, "Mascott" },
                    { 31, 2, "Megane" },
                    { 32, 2, "Megane CC" },
                    { 33, 2, "Megane Combi" },
                    { 34, 2, "Megane Grandtour" },
                    { 35, 2, "Megane Coupe" },
                    { 36, 2, "Megane Scenic" },
                    { 37, 2, "Scenic" },
                    { 38, 2, "Talisman" },
                    { 28, 2, "Laguna Grandtour" },
                    { 39, 2, "Talisman Grandtour" },
                    { 41, 2, "Twingo" },
                    { 42, 2, "Wind" },
                    { 43, 2, "Zoe" },
                    { 44, 3, "106" },
                    { 45, 3, "107" },
                    { 46, 3, "108" },
                    { 47, 3, "205" },
                    { 48, 3, "2008" },
                    { 49, 3, "206 SW" },
                    { 50, 3, "205 Cabrio" },
                    { 40, 2, "Thalia" },
                    { 27, 2, "Laguna" },
                    { 26, 2, "Kangoo" },
                    { 25, 2, "Kangoo Express" },
                    { 2, 1, "Altea" },
                    { 3, 1, "Arosa" },
                    { 4, 1, "Cordoba Vario" },
                    { 5, 1, "Cordoba" },
                    { 6, 1, "Exeo ST" },
                    { 7, 1, "Exeo" },
                    { 8, 1, "Ibiza ST" },
                    { 9, 1, "Ibiza" },
                    { 10, 1, "Inca" },
                    { 11, 1, "Leon ST" },
                    { 12, 1, "Leon" },
                    { 13, 1, "Mii" },
                    { 14, 1, "Toledo" },
                    { 15, 2, "Clio Grandtour" },
                    { 16, 2, "Clio" },
                    { 17, 2, "Espace" },
                    { 18, 2, "Fluence" },
                    { 19, 2, "Express" },
                    { 20, 2, "Kadjar" },
                    { 21, 2, "Grand Espace" },
                    { 22, 2, "Grand Scenic" },
                    { 23, 2, "Grand Modus" },
                    { 24, 2, "Koleos" },
                    { 51, 3, "206 CC" },
                    { 52, 3, "206" },
                    { 53, 3, "207 SW" },
                    { 54, 3, "207 CC" },
                    { 82, 4, "Logan Van" },
                    { 83, 4, "Logan MCV" },
                    { 84, 4, "Sandero" },
                    { 85, 4, "Solenza" },
                    { 86, 5, "C-Elissee" },
                    { 87, 5, "C-Crosser" },
                    { 88, 5, "C-Zero" },
                    { 89, 5, "C2" },
                    { 90, 5, "C1" },
                    { 91, 5, "C4 Aircross" },
                    { 92, 5, "C3" }
                });

            migrationBuilder.InsertData(
                table: "CARMODEL",
                columns: new[] { "Id", "CARBRANDID", "MODELNAME" },
                values: new object[,]
                {
                    { 93, 5, "C4" },
                    { 94, 5, "C3 Picasso" },
                    { 95, 5, "C4 Grand Picasso" },
                    { 96, 5, "C4 Coupe" },
                    { 97, 5, "C4 Cactus" },
                    { 98, 5, "C4 Sedan" },
                    { 99, 5, "C5" },
                    { 100, 5, "C5 Break" },
                    { 101, 5, "C5 Tourer" },
                    { 102, 5, "C6" },
                    { 103, 5, "C8" },
                    { 104, 5, "DS3" },
                    { 81, 4, "Logan" },
                    { 106, 5, "DS5" },
                    { 80, 4, "Duster" },
                    { 78, 3, "RCZ" },
                    { 55, 3, "207" },
                    { 56, 3, "306" },
                    { 57, 3, "307" },
                    { 58, 3, "307 CC" },
                    { 59, 3, "307 SW" },
                    { 60, 3, "308" },
                    { 61, 3, "308 CC" },
                    { 62, 3, "308 SW" },
                    { 63, 3, "309" },
                    { 64, 3, "4007" },
                    { 65, 3, "4008" },
                    { 66, 3, "405" },
                    { 67, 3, "406" },
                    { 68, 3, "407" },
                    { 69, 3, "407 SW" },
                    { 70, 3, "5008" },
                    { 71, 3, "508" },
                    { 72, 3, "508 SW" },
                    { 73, 3, "605" },
                    { 74, 3, "806" },
                    { 75, 3, "607" },
                    { 76, 3, "807" },
                    { 77, 3, "Bipper" },
                    { 79, 4, "Lodgy" },
                    { 427, 19, "Samurai" },
                    { 213, 11, "Civic Tourer" },
                    { 215, 11, "CR-Z" },
                    { 350, 17, "Rad 3 Coupe" },
                    { 351, 17, "Rad 3 GT" },
                    { 352, 17, "Rad 3 Touring" },
                    { 353, 17, "Rad 4" },
                    { 354, 17, "Rad 4 Cabrio" },
                    { 355, 17, "Rad 4 Gran Coupe" },
                    { 356, 17, "Rad 5" },
                    { 357, 17, "Rad 5 GT" },
                    { 358, 17, "Rad 5 Touring" },
                    { 359, 17, "Rad 6" },
                    { 349, 17, "Rad 3 Compact" },
                    { 360, 17, "Rad 6 Cabrio" },
                    { 362, 17, "Rad 6 Gran Coupe" },
                    { 363, 17, "Rad 7" },
                    { 364, 17, "Rad 8 Coupe" },
                    { 365, 17, "X1" },
                    { 366, 17, "X3" },
                    { 367, 17, "X4" },
                    { 368, 17, "X5" },
                    { 369, 17, "X6" },
                    { 370, 17, "Z3" },
                    { 371, 17, "Z3 Coupe" },
                    { 361, 17, "Rad 6 Coupe" },
                    { 348, 17, "Rad 3 Cabrio" },
                    { 347, 17, "Rad 3" },
                    { 346, 17, "Rad 2 Active Tourer" },
                    { 323, 16, "Paseo" },
                    { 324, 16, "Picnic" },
                    { 325, 16, "Prius" },
                    { 326, 16, "RAV4" },
                    { 327, 16, "Sequoia" },
                    { 328, 16, "Starlet" },
                    { 329, 16, "Supra" },
                    { 330, 16, "Tundra" },
                    { 331, 16, "Urban Cruiser" },
                    { 332, 16, "Verso" },
                    { 333, 16, "Yaris" },
                    { 334, 16, "Yaris Verso" },
                    { 335, 17, "M3" },
                    { 336, 17, "i8" },
                    { 337, 17, "M4" },
                    { 338, 17, "M6" },
                    { 339, 17, "M5" },
                    { 340, 17, "Rad 2" },
                    { 341, 17, "Rad 1" },
                    { 342, 17, "Rad 1 Coupe" },
                    { 343, 17, "Rad 1 Cabrio" },
                    { 344, 17, "Rad 2 Gran Tourer" },
                    { 345, 17, "Rad 2 Coupe" },
                    { 372, 17, "Z3 Roadster" },
                    { 373, 17, "Z4" },
                    { 374, 17, "Z4 Roadster" },
                    { 375, 18, "Bora" },
                    { 403, 18, "Passat CC" },
                    { 404, 18, "Passat Variant" },
                    { 405, 18, "Passat Variant Van" },
                    { 406, 18, "Phaeton" },
                    { 407, 18, "Polo" },
                    { 408, 18, "Polo Van" },
                    { 409, 18, "Polo Variant" },
                    { 410, 18, "Scirocco" },
                    { 411, 18, "Sharan" },
                    { 412, 18, "T4" },
                    { 413, 18, "T4 Caravelle" },
                    { 414, 18, "T4 Multivan" },
                    { 415, 18, "T5" },
                    { 416, 18, "T5 Caravelle" },
                    { 417, 18, "T5 Multivan" },
                    { 418, 18, "T5 Transporter Shuttle" },
                    { 419, 18, "Tiguan" },
                    { 420, 18, "Touareg" },
                    { 421, 18, "Touran" },
                    { 422, 19, "Baleno kombi" },
                    { 423, 19, "Baleno" },
                    { 424, 19, "Grand Vitara" },
                    { 425, 19, "Ignis" },
                    { 402, 18, "Passat Alltrack" },
                    { 322, 16, "MR2" },
                    { 401, 18, "Passat" },
                    { 399, 18, "New Beetle" },
                    { 376, 18, "Beetle" },
                    { 377, 18, "Bora Variant" },
                    { 378, 18, "Caddy Van" },
                    { 379, 18, "Caddy" },
                    { 380, 18, "CC" },
                    { 381, 18, "Life" },
                    { 382, 18, "Caravelle" },
                    { 383, 18, "California" },
                    { 384, 18, "Crafter Kombi" },
                    { 385, 18, "Crafter Van" },
                    { 386, 18, "Crafter" },
                    { 387, 18, "CrossTouran" },
                    { 388, 18, "Eos" },
                    { 389, 18, "Fox" },
                    { 390, 18, "Golf" },
                    { 391, 18, "Golf Cabrio" },
                    { 392, 18, "Golf Plus" },
                    { 393, 18, "Golf Sportvan" },
                    { 394, 18, "Golf Variant" },
                    { 395, 18, "Jetta" },
                    { 396, 18, "LT" },
                    { 397, 18, "Lupo" },
                    { 398, 18, "Multivan" },
                    { 400, 18, "New Beetle Cabrio" },
                    { 214, 11, "FR-V" },
                    { 321, 16, "Land Cruiser" },
                    { 319, 16, "Highlander" },
                    { 243, 13, "6" },
                    { 244, 13, "5" },
                    { 245, 13, "B-Fighter" },
                    { 246, 13, "626 Combi" },
                    { 247, 13, "626" },
                    { 248, 13, "B2500" },
                    { 249, 13, "BT" },
                    { 250, 13, "CX-3" },
                    { 251, 13, "CX-5" },
                    { 252, 13, "CX-7" },
                    { 242, 13, "323 F" },
                    { 253, 13, "CX-9" },
                    { 255, 13, "MPV" },
                    { 256, 13, "MX-3" },
                    { 257, 13, "MX-5" },
                    { 258, 13, "MX-6" },
                    { 259, 13, "Premacy" },
                    { 260, 13, "RX-7" },
                    { 261, 13, "RX-8" },
                    { 262, 13, "Xedox 6" },
                    { 263, 14, "Carisma" },
                    { 264, 14, "ASX" },
                    { 254, 13, "Demio" },
                    { 241, 13, "6 Combi" },
                    { 240, 13, "323 Combi" },
                    { 239, 13, "323 Coupe" },
                    { 216, 11, "CR-X" },
                    { 217, 11, "HR-V" },
                    { 218, 11, "Insight" },
                    { 219, 11, "Integra" },
                    { 220, 11, "Jazz" },
                    { 221, 11, "Legend" },
                    { 222, 11, "Prelude" },
                    { 223, 12, "Impreza" },
                    { 224, 12, "Forester" },
                    { 225, 12, "Impreza Wagon" },
                    { 226, 12, "Legacy" },
                    { 227, 12, "Justy" },
                    { 228, 12, "Outback" },
                    { 229, 12, "Legacy Wagon" },
                    { 230, 12, "Levorg" },
                    { 231, 12, "Legacy Outback" },
                    { 232, 12, "Tribeca B9" },
                    { 233, 12, "Tribeca" },
                    { 234, 12, "SVX" },
                    { 235, 12, "XV" },
                    { 236, 13, "3" },
                    { 237, 13, "2" },
                    { 238, 13, "323" },
                    { 265, 14, "Colt" }
                });

            migrationBuilder.InsertData(
                table: "CARMODEL",
                columns: new[] { "Id", "CARBRANDID", "MODELNAME" },
                values: new object[,]
                {
                    { 266, 14, "Eclipse" },
                    { 267, 14, "Colt CC" },
                    { 268, 14, "Grandis" },
                    { 296, 15, "RX" },
                    { 297, 15, "RC F" },
                    { 298, 15, "NX" },
                    { 299, 15, "RX 300" },
                    { 300, 15, "RX 400h" },
                    { 301, 15, "RX 450h" },
                    { 302, 15, "SC 430" },
                    { 303, 16, "Avensis" },
                    { 304, 16, "Auris" },
                    { 305, 16, "Avensis Combi" },
                    { 306, 16, "Aygo" },
                    { 307, 16, "Avensis Van Verso" },
                    { 308, 16, "Corolla" },
                    { 309, 16, "Camry" },
                    { 310, 16, "Celica" },
                    { 311, 16, "Carina" },
                    { 312, 16, "Corolla Verso" },
                    { 313, 16, "Corolla sedan" },
                    { 314, 16, "Corolla Combi" },
                    { 315, 16, "FJ Cruiser" },
                    { 316, 16, "GT86" },
                    { 317, 16, "Hiace" },
                    { 318, 16, "Hiace Van" },
                    { 295, 15, "IS-F" },
                    { 320, 16, "Hilux" },
                    { 294, 15, "LS" },
                    { 292, 15, "LX" },
                    { 269, 14, "Fuso canter" },
                    { 270, 14, "Galant Combi" },
                    { 271, 14, "Galant" },
                    { 272, 14, "L200 Pick up Allrad" },
                    { 273, 14, "L200 Pick up" },
                    { 274, 14, "L200" },
                    { 275, 14, "L300" },
                    { 276, 14, "Lancer" },
                    { 277, 14, "Lancer Combi" },
                    { 278, 14, "Lancer Evo" },
                    { 279, 14, "Lancer Sportback" },
                    { 280, 14, "Outlander" },
                    { 281, 14, "Pajero" },
                    { 282, 14, "Pajeto Pinin" },
                    { 283, 14, "Pajero Pinin Wagon" },
                    { 284, 14, "Pajero Sport" },
                    { 285, 14, "Pajero Wagon" },
                    { 286, 14, "Space Star" },
                    { 287, 15, "GS 300" },
                    { 288, 15, "GS" },
                    { 289, 15, "GX" },
                    { 290, 15, "IS 200" },
                    { 291, 15, "IS" },
                    { 293, 15, "IS 250 C" },
                    { 1, 1, "Altea XL" }
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
                name: "IX_CAR_ENGINETYPESTATUSID",
                table: "CAR",
                column: "ENGINETYPESTATUSID",
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

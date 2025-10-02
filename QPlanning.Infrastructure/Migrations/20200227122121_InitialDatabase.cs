using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QPlanning.Infrastructure.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "logging");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Voornaam = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndirecteUren",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true),
                    IsActief = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndirecteUren", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedewerkerFunctie",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TechnischeNaam = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Beschrijving = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedewerkerFunctie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opdracht",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Omschrijving = table.Column<string>(nullable: true),
                    IsActief = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opdracht", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    IsActief = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomLogging",
                schema: "logging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    RequestObjectName = table.Column<string>(nullable: true),
                    RequestJsonObject = table.Column<string>(nullable: true),
                    DestinationObjectName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomLogging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogging",
                schema: "logging",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    RequestHost = table.Column<string>(nullable: true),
                    ExceptionLogMessage = table.Column<string>(nullable: true),
                    HeaderInfo = table.Column<string>(nullable: true),
                    ContextUser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogging", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
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
                    UserId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
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
                name: "Medewerker",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    TussenVoegsel = table.Column<string>(nullable: true),
                    Achternaam = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tarief = table.Column<int>(nullable: true),
                    InternTarief = table.Column<int>(nullable: true),
                    MedewerkerFunctieId = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: false),
                    IsActief = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medewerker", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medewerker_MedewerkerFunctie_MedewerkerFunctieId",
                        column: x => x.MedewerkerFunctieId,
                        principalSchema: "dbo",
                        principalTable: "MedewerkerFunctie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medewerker_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Klant",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Naam = table.Column<string>(nullable: true),
                    Startdatum = table.Column<DateTime>(nullable: true),
                    Einddatum = table.Column<DateTime>(nullable: true),
                    VerantwoordelijkTeamId = table.Column<int>(nullable: false),
                    MedewerkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Klant_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalSchema: "dbo",
                        principalTable: "Medewerker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Klant_Team_VerantwoordelijkTeamId",
                        column: x => x.VerantwoordelijkTeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boeking",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Jaar = table.Column<int>(nullable: true),
                    Boekjaar = table.Column<int>(nullable: true),
                    Maand = table.Column<int>(nullable: true),
                    Weeknummer = table.Column<int>(nullable: true),
                    EersteDagVanDeWeek = table.Column<int>(nullable: true),
                    Uren = table.Column<int>(nullable: false),
                    MedewerkerId = table.Column<int>(nullable: false),
                    KlantId = table.Column<int>(nullable: true),
                    OpdrachtId = table.Column<int>(nullable: true),
                    IndirecteUrenId = table.Column<int>(nullable: true),
                    IsIndirect = table.Column<bool>(nullable: false),
                    MoetNogGeplandWorden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boeking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boeking_IndirecteUren_IndirecteUrenId",
                        column: x => x.IndirecteUrenId,
                        principalSchema: "dbo",
                        principalTable: "IndirecteUren",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boeking_Klant_KlantId",
                        column: x => x.KlantId,
                        principalSchema: "dbo",
                        principalTable: "Klant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boeking_Medewerker_MedewerkerId",
                        column: x => x.MedewerkerId,
                        principalSchema: "dbo",
                        principalTable: "Medewerker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Boeking_Opdracht_OpdrachtId",
                        column: x => x.OpdrachtId,
                        principalSchema: "dbo",
                        principalTable: "Opdracht",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Boekjaar",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    KlantId = table.Column<int>(nullable: false),
                    Jaar = table.Column<int>(nullable: false),
                    Budget = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boekjaar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Boekjaar_Klant_KlantId",
                        column: x => x.KlantId,
                        principalSchema: "dbo",
                        principalTable: "Klant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KlantPlanbaarDoorTeams",
                schema: "dbo",
                columns: table => new
                {
                    KlantId = table.Column<int>(nullable: false),
                    TeamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlantPlanbaarDoorTeams", x => new { x.KlantId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_KlantPlanbaarDoorTeams_Klant_KlantId",
                        column: x => x.KlantId,
                        principalSchema: "dbo",
                        principalTable: "Klant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KlantPlanbaarDoorTeams_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "dbo",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Achternaam", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Voornaam" },
                values: new object[,]
                {
                    { 1, 0, "Mengelers", "fe269abb-4fe0-472b-86fd-df72ea1c1b3f", "roy.mengelers@zuyd.nl", true, false, null, "roy.mengelers@zuyd.nl", "roy.mengelers@zuyd.nl", "AQAAAAEAACcQAAAAEKJ/FtPC/HBzXeUeYmNIcugWQFE6DkSPGvJTZYoIwEj68s/WdFy3OaAhopKKBln5Rw==", null, false, "", false, "roy.mengelers@zuyd.nl", "Roy" }});

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "IndirecteUren",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActief", "Modified", "ModifiedBy", "Omschrijving" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Feestdag" },
                    { 2, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Interne Projecten" },
                    { 3, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Overig" },
                    { 4, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Parttime" },
                    { 5, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Verlof" },
                    { 6, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Studie" },
                    { 7, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Ziek" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "MedewerkerFunctie",
                columns: new[] { "Id", "Beschrijving", "DisplayName", "TechnischeNaam" },
                values: new object[,]
                {
                    { 10, "Dit is een tijdelijke toekenning waarna een definitieve kan volgen", "PlaceHolder", "PlaceHolder" },
                    { 9, "Inhuur van een IT functie", "IT Digle", "IT" },
                    { 8, "Inhuur van een Externe functie", "Extern", "Extern" },
                    { 7, "Inhuur van een persoon, dit kan ook vanuit een ander team zijn", "Inhuur", "Inhuur" },
                    { 6, "Deze persoon heeft de functie Stagiair", "Stagiair", "Stagiair" },
                    { 4, "Deze persoon heeft de functie SeniorAssosiate", "Senior assosiate", "SeniorAssosiate" },
                    { 3, "Deze persoon heeft de functie AssistantManager", "Assistant manager", "AssistantManager" },
                    { 2, "Deze persoon heeft de functie Manager", "Manager", "Manager" },
                    { 1, "Deze persoon heeft de functie Partner", "Partner", "Partner" },
                    { 5, "Deze persoon heeft de functie Assosiatie", "Assosiatie", "Assosiatie" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Opdracht",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActief", "Modified", "ModifiedBy", "Omschrijving" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Interem" },
                    { 2, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Balanscontrole" },
                    { 3, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Inventarisatie" },
                    { 4, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Overig" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Team",
                columns: new[] { "Id", "Created", "CreatedBy", "IsActief", "Modified", "ModifiedBy", "Naam" },
                values: new object[,]
                {
                    { 3, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Den Bosch" },
                    { 1, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Limburg" },
                    { 2, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Healthcare" },
                    { 4, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", true, new DateTime(2019, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "RM", "Rotterdam" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[] { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Boeking_IndirecteUrenId",
                schema: "dbo",
                table: "Boeking",
                column: "IndirecteUrenId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeking_KlantId",
                schema: "dbo",
                table: "Boeking",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeking_MedewerkerId",
                schema: "dbo",
                table: "Boeking",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Boeking_OpdrachtId",
                schema: "dbo",
                table: "Boeking",
                column: "OpdrachtId");

            migrationBuilder.CreateIndex(
                name: "IX_Boekjaar_KlantId",
                schema: "dbo",
                table: "Boekjaar",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Klant_MedewerkerId",
                schema: "dbo",
                table: "Klant",
                column: "MedewerkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Klant_VerantwoordelijkTeamId",
                schema: "dbo",
                table: "Klant",
                column: "VerantwoordelijkTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_KlantPlanbaarDoorTeams_TeamId",
                schema: "dbo",
                table: "KlantPlanbaarDoorTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_Email",
                schema: "dbo",
                table: "Medewerker",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_MedewerkerFunctieId",
                schema: "dbo",
                table: "Medewerker",
                column: "MedewerkerFunctieId");

            migrationBuilder.CreateIndex(
                name: "IX_Medewerker_TeamId",
                schema: "dbo",
                table: "Medewerker",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Boeking",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Boekjaar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "KlantPlanbaarDoorTeams",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CustomLogging",
                schema: "logging");

            migrationBuilder.DropTable(
                name: "ExceptionLogging",
                schema: "logging");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "IndirecteUren",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Opdracht",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Klant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Medewerker",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedewerkerFunctie",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "dbo");
        }
    }
}

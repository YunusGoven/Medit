using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medit1.Migrations
{
    public partial class final : Migration
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boat",
                columns: table => new
                {
                    BoatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    NbConvives = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boat", x => x.BoatId);
                });

            migrationBuilder.CreateTable(
                name: "Commodite",
                columns: table => new
                {
                    CommoditeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodite", x => x.CommoditeId);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.ParticipantId);
                });

            migrationBuilder.CreateTable(
                name: "Port",
                columns: table => new
                {
                    PortId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Latitude = table.Column<float>(nullable: false),
                    Longitude = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Port", x => x.PortId);
                });

            migrationBuilder.CreateTable(
                name: "TypeCruise",
                columns: table => new
                {
                    TypeCruiseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    AdultOnly = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCruise", x => x.TypeCruiseId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "Cruise",
                columns: table => new
                {
                    CruiseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    DateDepart = table.Column<DateTime>(nullable: false),
                    DateArrivee = table.Column<DateTime>(nullable: false),
                    DistanceTotal = table.Column<float>(nullable: false),
                    AdultOnly = table.Column<bool>(nullable: false),
                    BoatId = table.Column<int>(nullable: true),
                    TypeCruiseId = table.Column<int>(nullable: true),
                    PortDepartPortId = table.Column<int>(nullable: true),
                    ArrivalPortPortId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cruise", x => x.CruiseId);
                    table.ForeignKey(
                        name: "FK_Cruise_Port_ArrivalPortPortId",
                        column: x => x.ArrivalPortPortId,
                        principalTable: "Port",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cruise_Boat_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boat",
                        principalColumn: "BoatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cruise_Port_PortDepartPortId",
                        column: x => x.PortDepartPortId,
                        principalTable: "Port",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cruise_TypeCruise_TypeCruiseId",
                        column: x => x.TypeCruiseId,
                        principalTable: "TypeCruise",
                        principalColumn: "TypeCruiseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CruiseCommodites",
                columns: table => new
                {
                    CruiseId = table.Column<int>(nullable: false),
                    CommoditeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CruiseCommodites", x => new { x.CruiseId, x.CommoditeId });
                    table.ForeignKey(
                        name: "FK_CruiseCommodites_Commodite_CommoditeId",
                        column: x => x.CommoditeId,
                        principalTable: "Commodite",
                        principalColumn: "CommoditeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CruiseCommodites_Cruise_CruiseId",
                        column: x => x.CruiseId,
                        principalTable: "Cruise",
                        principalColumn: "CruiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CruisePorts",
                columns: table => new
                {
                    CruiseId = table.Column<int>(nullable: false),
                    PortId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CruisePorts", x => new { x.CruiseId, x.PortId });
                    table.ForeignKey(
                        name: "FK_CruisePorts_Cruise_CruiseId",
                        column: x => x.CruiseId,
                        principalTable: "Cruise",
                        principalColumn: "CruiseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CruisePorts_Port_PortId",
                        column: x => x.PortId,
                        principalTable: "Port",
                        principalColumn: "PortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: false),
                    CruiseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Cruise_CruiseId",
                        column: x => x.CruiseId,
                        principalTable: "Cruise",
                        principalColumn: "CruiseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CruiseId = table.Column<int>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Cruise_CruiseId",
                        column: x => x.CruiseId,
                        principalTable: "Cruise",
                        principalColumn: "CruiseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParticipantReservation",
                columns: table => new
                {
                    ParticipantId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantReservation", x => new { x.ParticipantId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ParticipantReservation_Participant_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participant",
                        principalColumn: "ParticipantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantReservation_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservation",
                        principalColumn: "ReservationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Boat",
                columns: new[] { "BoatId", "Description", "Name", "NbConvives", "Type" },
                values: new object[,]
                {
                    { 1, "https://www.lindependant.fr/2018/06/25/port-vendres-le-plus-grand-voilier-de-luxe-au-monde-ancre-dans-les-eaux-catalanes,4564616.php", "La Maltese Falcon", 10, "Monocoque" },
                    { 2, "https://journalduluxe.fr/catamaran-hemisphere/", "Hémisphère", 11, "Catamaran" },
                    { 3, "https://www.bateaux.com/article/20117/Le-Neel-65-nouveau-trimaran-de-croisiere-rapide-du-chantier-Neel-Trimaran", "Neel 65", 10, "Trimaran" }
                });

            migrationBuilder.InsertData(
                table: "Commodite",
                columns: new[] { "CommoditeId", "Name" },
                values: new object[,]
                {
                    { 1, "Internet" },
                    { 2, "Réseaux EU" },
                    { 3, "Réseaux AN" },
                    { 4, "Réseaux USA" }
                });

            migrationBuilder.InsertData(
                table: "Participant",
                columns: new[] { "ParticipantId", "BirthDate", "FirstName", "Name" },
                values: new object[,]
                {
                    { 757, new DateTime(2001, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bremit", "Bremit" },
                    { 756, new DateTime(1999, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chritian", "PasDior" },
                    { 755, new DateTime(2000, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yunus", "GVN" }
                });

            migrationBuilder.InsertData(
                table: "Port",
                columns: new[] { "PortId", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 15, 34.666805f, 33.041073f, "Limassol" },
                    { 14, 36.83431f, 30.606443f, "Antalya" },
                    { 13, 37.938103f, 23.648191f, "La Pirée" },
                    { 12, 40.636024f, 22.92165f, "Salonique" },
                    { 11, 37.06541f, 15.278924f, "Syracuse" },
                    { 10, 39.20836f, 9.105776f, "Cagliari" },
                    { 9, 38.130196f, 13.363785f, "Palerme" },
                    { 4, 41.38599f, 9.151511f, "Bonifacio" },
                    { 7, 40.84301f, 14.26315f, "Naples" },
                    { 6, 44.40996f, 8.909803f, "Port de Gênes" },
                    { 5, 43.679646f, 7.230929f, "Nice" },
                    { 3, 41.919163f, 8.743635f, "Ajaccio" },
                    { 2, 43.014458f, 3.062417f, "Port-la-Nouvelle" },
                    { 1, 42.520794f, 3.113759f, "Port-Vendres" },
                    { 8, 40.67283f, 14.769201f, "Salerne" }
                });

            migrationBuilder.InsertData(
                table: "TypeCruise",
                columns: new[] { "TypeCruiseId", "AdultOnly", "Description", "Name" },
                values: new object[,]
                {
                    { 2, false, "Court trajet et escales longues afin de découvrir la culture locale.", "Découverte" },
                    { 1, true, "Soirées mémorables aux sons de la salsa.", "Rencontre" },
                    { 3, false, "Voyage paisible avec escales pour ravitailler", "Farniente" }
                });

            migrationBuilder.InsertData(
                table: "Cruise",
                columns: new[] { "CruiseId", "AdultOnly", "ArrivalPortPortId", "BoatId", "DateArrivee", "DateDepart", "Description", "DistanceTotal", "Name", "PortDepartPortId", "TypeCruiseId" },
                values: new object[] { 100, true, 2, 2, new DateTime(2030, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Une tournée aux bords de la mer méditéerannéene avec votre famille", 0f, "La croisière du futur", 1, 1 });

            migrationBuilder.InsertData(
                table: "Cruise",
                columns: new[] { "CruiseId", "AdultOnly", "ArrivalPortPortId", "BoatId", "DateArrivee", "DateDepart", "Description", "DistanceTotal", "Name", "PortDepartPortId", "TypeCruiseId" },
                values: new object[] { 101, false, 7, 1, new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vous avez kiffé la v1 nous vous propossons la v2 biensur avec les meme conditions que la v1", 0f, "Medit'On Flux v2", 6, 2 });

            migrationBuilder.InsertData(
                table: "Cruise",
                columns: new[] { "CruiseId", "AdultOnly", "ArrivalPortPortId", "BoatId", "DateArrivee", "DateDepart", "Description", "DistanceTotal", "Name", "PortDepartPortId", "TypeCruiseId" },
                values: new object[] { 102, false, 10, 3, new DateTime(2030, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2030, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Une croisière de luxe avec des lits afin que vous poussiez dormir tranquillement pendant vous voyager", 0f, "Hotel Boats Dream", 10, 3 });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ReservationId", "CruiseId", "UserId" },
                values: new object[] { 215, 100, "1" });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ReservationId", "CruiseId", "UserId" },
                values: new object[] { 216, 101, "1" });

            migrationBuilder.InsertData(
                table: "ParticipantReservation",
                columns: new[] { "ParticipantId", "ReservationId" },
                values: new object[] { 755, 215 });

            migrationBuilder.InsertData(
                table: "ParticipantReservation",
                columns: new[] { "ParticipantId", "ReservationId" },
                values: new object[] { 756, 215 });

            migrationBuilder.InsertData(
                table: "ParticipantReservation",
                columns: new[] { "ParticipantId", "ReservationId" },
                values: new object[] { 757, 216 });

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
                name: "IX_Cruise_ArrivalPortPortId",
                table: "Cruise",
                column: "ArrivalPortPortId");

            migrationBuilder.CreateIndex(
                name: "IX_Cruise_BoatId",
                table: "Cruise",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_Cruise_PortDepartPortId",
                table: "Cruise",
                column: "PortDepartPortId");

            migrationBuilder.CreateIndex(
                name: "IX_Cruise_TypeCruiseId",
                table: "Cruise",
                column: "TypeCruiseId");

            migrationBuilder.CreateIndex(
                name: "IX_CruiseCommodites_CommoditeId",
                table: "CruiseCommodites",
                column: "CommoditeId");

            migrationBuilder.CreateIndex(
                name: "IX_CruisePorts_PortId",
                table: "CruisePorts",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_CruiseId",
                table: "Image",
                column: "CruiseId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantReservation_ReservationId",
                table: "ParticipantReservation",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CruiseId",
                table: "Reservation",
                column: "CruiseId");
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
                name: "CruiseCommodites");

            migrationBuilder.DropTable(
                name: "CruisePorts");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "ParticipantReservation");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Commodite");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Cruise");

            migrationBuilder.DropTable(
                name: "Port");

            migrationBuilder.DropTable(
                name: "Boat");

            migrationBuilder.DropTable(
                name: "TypeCruise");
        }
    }
}

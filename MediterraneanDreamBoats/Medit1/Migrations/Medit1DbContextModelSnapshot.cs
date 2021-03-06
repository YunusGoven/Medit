// <auto-generated />
using System;
using Medit1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Medit1.Migrations
{
    [DbContext(typeof(Medit1DbContext))]
    partial class Medit1DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Medit1.Models.Boat", b =>
                {
                    b.Property<int>("BoatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NbConvives")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BoatId");

                    b.ToTable("Boat");

                    b.HasData(
                        new
                        {
                            BoatId = 1,
                            Description = "https://www.lindependant.fr/2018/06/25/port-vendres-le-plus-grand-voilier-de-luxe-au-monde-ancre-dans-les-eaux-catalanes,4564616.php",
                            Name = "La Maltese Falcon",
                            NbConvives = 10,
                            Type = "Monocoque"
                        },
                        new
                        {
                            BoatId = 2,
                            Description = "https://journalduluxe.fr/catamaran-hemisphere/",
                            Name = "Hémisphère",
                            NbConvives = 11,
                            Type = "Catamaran"
                        },
                        new
                        {
                            BoatId = 3,
                            Description = "https://www.bateaux.com/article/20117/Le-Neel-65-nouveau-trimaran-de-croisiere-rapide-du-chantier-Neel-Trimaran",
                            Name = "Neel 65",
                            NbConvives = 10,
                            Type = "Trimaran"
                        });
                });

            modelBuilder.Entity("Medit1.Models.Commodite", b =>
                {
                    b.Property<int>("CommoditeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommoditeId");

                    b.ToTable("Commodite");

                    b.HasData(
                        new
                        {
                            CommoditeId = 1,
                            Name = "Internet"
                        },
                        new
                        {
                            CommoditeId = 2,
                            Name = "Réseaux EU"
                        },
                        new
                        {
                            CommoditeId = 3,
                            Name = "Réseaux AN"
                        },
                        new
                        {
                            CommoditeId = 4,
                            Name = "Réseaux USA"
                        });
                });

            modelBuilder.Entity("Medit1.Models.Cruise", b =>
                {
                    b.Property<int>("CruiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AdultOnly")
                        .HasColumnType("bit");

                    b.Property<int?>("ArrivalPortPortId")
                        .HasColumnType("int");

                    b.Property<int?>("BoatId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateArrivee")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDepart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DistanceTotal")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PortDepartPortId")
                        .HasColumnType("int");

                    b.Property<int?>("TypeCruiseId")
                        .HasColumnType("int");

                    b.HasKey("CruiseId");

                    b.HasIndex("ArrivalPortPortId");

                    b.HasIndex("BoatId");

                    b.HasIndex("PortDepartPortId");

                    b.HasIndex("TypeCruiseId");

                    b.ToTable("Cruise");

                    b.HasData(
                        new
                        {
                            CruiseId = 100,
                            AdultOnly = true,
                            ArrivalPortPortId = 2,
                            BoatId = 2,
                            DateArrivee = new DateTime(2030, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateDepart = new DateTime(2030, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Une tournée aux bords de la mer méditéerannéene avec votre famille",
                            DistanceTotal = 0f,
                            Name = "La croisière du futur",
                            PortDepartPortId = 1,
                            TypeCruiseId = 1
                        },
                        new
                        {
                            CruiseId = 101,
                            AdultOnly = false,
                            ArrivalPortPortId = 7,
                            BoatId = 1,
                            DateArrivee = new DateTime(2023, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateDepart = new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Vous avez kiffé la v1 nous vous propossons la v2 biensur avec les meme conditions que la v1",
                            DistanceTotal = 0f,
                            Name = "Medit'On Flux v2",
                            PortDepartPortId = 6,
                            TypeCruiseId = 2
                        },
                        new
                        {
                            CruiseId = 102,
                            AdultOnly = false,
                            ArrivalPortPortId = 10,
                            BoatId = 3,
                            DateArrivee = new DateTime(2030, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateDepart = new DateTime(2030, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Une croisière de luxe avec des lits afin que vous poussiez dormir tranquillement pendant vous voyager",
                            DistanceTotal = 0f,
                            Name = "Hotel Boats Dream",
                            PortDepartPortId = 10,
                            TypeCruiseId = 3
                        });
                });

            modelBuilder.Entity("Medit1.Models.CruiseCommodite", b =>
                {
                    b.Property<int>("CruiseId")
                        .HasColumnType("int");

                    b.Property<int>("CommoditeId")
                        .HasColumnType("int");

                    b.HasKey("CruiseId", "CommoditeId");

                    b.HasIndex("CommoditeId");

                    b.ToTable("CruiseCommodites");
                });

            modelBuilder.Entity("Medit1.Models.CruisePort", b =>
                {
                    b.Property<int>("CruiseId")
                        .HasColumnType("int");

                    b.Property<int>("PortId")
                        .HasColumnType("int");

                    b.HasKey("CruiseId", "PortId");

                    b.HasIndex("PortId");

                    b.ToTable("CruisePorts");
                });

            modelBuilder.Entity("Medit1.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CruiseId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("CruiseId");

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Medit1.Models.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParticipantId");

                    b.ToTable("Participant");

                    b.HasData(
                        new
                        {
                            ParticipantId = 755,
                            BirthDate = new DateTime(2000, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Yunus",
                            Name = "GVN"
                        },
                        new
                        {
                            ParticipantId = 756,
                            BirthDate = new DateTime(1999, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Chritian",
                            Name = "PasDior"
                        },
                        new
                        {
                            ParticipantId = 757,
                            BirthDate = new DateTime(2001, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Bremit",
                            Name = "Bremit"
                        });
                });

            modelBuilder.Entity("Medit1.Models.ParticipantReservation", b =>
                {
                    b.Property<int>("ParticipantId")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("ParticipantId", "ReservationId");

                    b.HasIndex("ReservationId");

                    b.ToTable("ParticipantReservation");

                    b.HasData(
                        new
                        {
                            ParticipantId = 755,
                            ReservationId = 215
                        },
                        new
                        {
                            ParticipantId = 756,
                            ReservationId = 215
                        },
                        new
                        {
                            ParticipantId = 757,
                            ReservationId = 216
                        });
                });

            modelBuilder.Entity("Medit1.Models.Port", b =>
                {
                    b.Property<int>("PortId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PortId");

                    b.ToTable("Port");

                    b.HasData(
                        new
                        {
                            PortId = 1,
                            Latitude = 42.520794f,
                            Longitude = 3.113759f,
                            Name = "Port-Vendres"
                        },
                        new
                        {
                            PortId = 2,
                            Latitude = 43.014458f,
                            Longitude = 3.062417f,
                            Name = "Port-la-Nouvelle"
                        },
                        new
                        {
                            PortId = 3,
                            Latitude = 41.919163f,
                            Longitude = 8.743635f,
                            Name = "Ajaccio"
                        },
                        new
                        {
                            PortId = 4,
                            Latitude = 41.38599f,
                            Longitude = 9.151511f,
                            Name = "Bonifacio"
                        },
                        new
                        {
                            PortId = 5,
                            Latitude = 43.679646f,
                            Longitude = 7.230929f,
                            Name = "Nice"
                        },
                        new
                        {
                            PortId = 6,
                            Latitude = 44.40996f,
                            Longitude = 8.909803f,
                            Name = "Port de Gênes"
                        },
                        new
                        {
                            PortId = 7,
                            Latitude = 40.84301f,
                            Longitude = 14.26315f,
                            Name = "Naples"
                        },
                        new
                        {
                            PortId = 8,
                            Latitude = 40.67283f,
                            Longitude = 14.769201f,
                            Name = "Salerne"
                        },
                        new
                        {
                            PortId = 9,
                            Latitude = 38.130196f,
                            Longitude = 13.363785f,
                            Name = "Palerme"
                        },
                        new
                        {
                            PortId = 10,
                            Latitude = 39.20836f,
                            Longitude = 9.105776f,
                            Name = "Cagliari"
                        },
                        new
                        {
                            PortId = 11,
                            Latitude = 37.06541f,
                            Longitude = 15.278924f,
                            Name = "Syracuse"
                        },
                        new
                        {
                            PortId = 12,
                            Latitude = 40.636024f,
                            Longitude = 22.92165f,
                            Name = "Salonique"
                        },
                        new
                        {
                            PortId = 13,
                            Latitude = 37.938103f,
                            Longitude = 23.648191f,
                            Name = "La Pirée"
                        },
                        new
                        {
                            PortId = 14,
                            Latitude = 36.83431f,
                            Longitude = 30.606443f,
                            Name = "Antalya"
                        },
                        new
                        {
                            PortId = 15,
                            Latitude = 34.666805f,
                            Longitude = 33.041073f,
                            Name = "Limassol"
                        });
                });

            modelBuilder.Entity("Medit1.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CruiseId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReservationId");

                    b.HasIndex("CruiseId");

                    b.ToTable("Reservation");

                    b.HasData(
                        new
                        {
                            ReservationId = 215,
                            CruiseId = 100,
                            UserId = "1"
                        },
                        new
                        {
                            ReservationId = 216,
                            CruiseId = 101,
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("Medit1.Models.TypeCruise", b =>
                {
                    b.Property<int>("TypeCruiseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AdultOnly")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeCruiseId");

                    b.ToTable("TypeCruise");

                    b.HasData(
                        new
                        {
                            TypeCruiseId = 1,
                            AdultOnly = true,
                            Description = "Soirées mémorables aux sons de la salsa.",
                            Name = "Rencontre"
                        },
                        new
                        {
                            TypeCruiseId = 2,
                            AdultOnly = false,
                            Description = "Court trajet et escales longues afin de découvrir la culture locale.",
                            Name = "Découverte"
                        },
                        new
                        {
                            TypeCruiseId = 3,
                            AdultOnly = false,
                            Description = "Voyage paisible avec escales pour ravitailler",
                            Name = "Farniente"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Medit1.Models.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Medit1.Models.Cruise", b =>
                {
                    b.HasOne("Medit1.Models.Port", "ArrivalPort")
                        .WithMany()
                        .HasForeignKey("ArrivalPortPortId");

                    b.HasOne("Medit1.Models.Boat", "Boat")
                        .WithMany()
                        .HasForeignKey("BoatId");

                    b.HasOne("Medit1.Models.Port", "PortDepart")
                        .WithMany()
                        .HasForeignKey("PortDepartPortId");

                    b.HasOne("Medit1.Models.TypeCruise", "TypeCruise")
                        .WithMany()
                        .HasForeignKey("TypeCruiseId");
                });

            modelBuilder.Entity("Medit1.Models.CruiseCommodite", b =>
                {
                    b.HasOne("Medit1.Models.Commodite", "Commodite")
                        .WithMany()
                        .HasForeignKey("CommoditeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medit1.Models.Cruise", "Cruise")
                        .WithMany("Commodites")
                        .HasForeignKey("CruiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Medit1.Models.CruisePort", b =>
                {
                    b.HasOne("Medit1.Models.Cruise", "Cruise")
                        .WithMany("TransitPorts")
                        .HasForeignKey("CruiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medit1.Models.Port", "Port")
                        .WithMany("TransitPorts")
                        .HasForeignKey("PortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Medit1.Models.Image", b =>
                {
                    b.HasOne("Medit1.Models.Cruise", "Cruise")
                        .WithMany("Images")
                        .HasForeignKey("CruiseId");
                });

            modelBuilder.Entity("Medit1.Models.ParticipantReservation", b =>
                {
                    b.HasOne("Medit1.Models.Participant", "Participant")
                        .WithMany("Reservations")
                        .HasForeignKey("ParticipantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Medit1.Models.Reservation", "Reservation")
                        .WithMany("Participants")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Medit1.Models.Reservation", b =>
                {
                    b.HasOne("Medit1.Models.Cruise", "Cruise")
                        .WithMany()
                        .HasForeignKey("CruiseId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

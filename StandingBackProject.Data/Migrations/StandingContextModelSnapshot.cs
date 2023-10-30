﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StandingBackProject.Data;

#nullable disable

namespace StandingBackProject.Data.Migrations
{
    [DbContext(typeof(StandingContext))]
    partial class StandingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StandingBackProject.Data.Entities.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Club");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateFinish")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.ResultTournamentPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PersonId");

                    b.HasIndex("TournamentId");

                    b.ToTable("ResultTournamentPlayer");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("JudgeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.HasIndex("GameId");

                    b.HasIndex("JudgeId");

                    b.ToTable("Tournament");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.ResultTournamentPlayer", b =>
                {
                    b.HasOne("StandingBackProject.Data.Entities.Game", "Game")
                        .WithMany("ResultTournamentPlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StandingBackProject.Data.Entities.Person", "Person")
                        .WithMany("ResultTournamentPlayers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StandingBackProject.Data.Entities.Tournament", "Tournament")
                        .WithMany("ResultTournamentPlayers")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Person");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Tournament", b =>
                {
                    b.HasOne("StandingBackProject.Data.Entities.Club", "Club")
                        .WithMany("Tournaments")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StandingBackProject.Data.Entities.Game", "Game")
                        .WithMany("Tournaments")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StandingBackProject.Data.Entities.Person", "Judge")
                        .WithMany("Tournaments")
                        .HasForeignKey("JudgeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Club");

                    b.Navigation("Game");

                    b.Navigation("Judge");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Club", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Game", b =>
                {
                    b.Navigation("ResultTournamentPlayers");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Person", b =>
                {
                    b.Navigation("ResultTournamentPlayers");

                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("StandingBackProject.Data.Entities.Tournament", b =>
                {
                    b.Navigation("ResultTournamentPlayers");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using BookClubLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookClubLibrary.Migrations
{
    [DbContext(typeof(BookClubDbContext))]
    partial class BookClubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookClubLibrary.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookName = "Преступление и наказание"
                        },
                        new
                        {
                            Id = 2,
                            BookName = "Мастер и Маргарита"
                        },
                        new
                        {
                            Id = 3,
                            BookName = "Война и Мир"
                        },
                        new
                        {
                            Id = 4,
                            BookName = "Дубровский"
                        },
                        new
                        {
                            Id = 5,
                            BookName = "Анна Каренина"
                        });
                });

            modelBuilder.Entity("BookClubLibrary.Models.ClubReader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("ClubReaders");
                });

            modelBuilder.Entity("BookClubLibrary.Models.ClubReaderBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("ClubReaderId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "ClubReaderId");

                    b.HasIndex("ClubReaderId");

                    b.ToTable("ClubReaderBook");
                });

            modelBuilder.Entity("BookClubLibrary.Models.ClubReaderBook", b =>
                {
                    b.HasOne("BookClubLibrary.Models.Book", "Book")
                        .WithMany("ClubReaderBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookClubLibrary.Models.ClubReader", "ClubReader")
                        .WithMany("ClubReaderBooks")
                        .HasForeignKey("ClubReaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

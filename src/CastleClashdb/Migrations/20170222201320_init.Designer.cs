using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CastleClashdb.Data;

namespace CastleClashdb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170222201320_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CastleClashdb.Models.CastleClash.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CastleClashdb.Models.CastleClash.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<int>("level");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("CastleClashdb.Models.CastleClash.Hero", b =>
                {
                    b.HasOne("CastleClashdb.Models.CastleClash.Category")
                        .WithMany("Hero")
                        .HasForeignKey("CategoryId");
                });
        }
    }
}

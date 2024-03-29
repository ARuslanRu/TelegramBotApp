﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelegramBotApp.Models;

namespace TelegramBotApp.Migrations
{
    [DbContext(typeof(TelegramBotAppDbContext))]
    partial class TelegramBotAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TelegramBotApp.Models.BotButton", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ButtonName");

                    b.Property<int>("Column");

                    b.Property<string>("Content");

                    b.Property<int>("ParentId");

                    b.Property<int>("Row");

                    b.HasKey("Id");

                    b.ToTable("BotButtons");
                });
#pragma warning restore 612, 618
        }
    }
}

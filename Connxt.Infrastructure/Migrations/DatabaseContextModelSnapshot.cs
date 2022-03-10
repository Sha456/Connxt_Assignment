﻿// <auto-generated />
using System;
using Connxt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Connxt.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Connxt.Core.Entities.CreditCardProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardBeginsWithDigit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreditCardValidationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreditCardValidationId");

                    b.ToTable("CreditCardProperties", (string)null);
                });

            modelBuilder.Entity("Connxt.Core.Entities.CreditCardValidation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CardName")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("CardValidationConfiguration")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("ModifiedDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("CreditCardValidations", (string)null);
                });

            modelBuilder.Entity("Connxt.Core.Entities.CreditCardProperty", b =>
                {
                    b.HasOne("Connxt.Core.Entities.CreditCardValidation", "CreditCardValidation")
                        .WithMany("CreditCardProperties")
                        .HasForeignKey("CreditCardValidationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreditCardValidation");
                });

            modelBuilder.Entity("Connxt.Core.Entities.CreditCardValidation", b =>
                {
                    b.Navigation("CreditCardProperties");
                });
#pragma warning restore 612, 618
        }
    }
}

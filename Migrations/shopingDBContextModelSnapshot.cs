﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyECommerceWebSite2022.Models;

namespace MyECommerceWebSite2022.Migrations
{
    [DbContext(typeof(shopingDBContext))]
    partial class shopingDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyECommerceWebSite2022.Models.CompanyData", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutDescreptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AboutDescreptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyNameAr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaceBookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InstgramLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedinLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CompanyDatas");
                });

            modelBuilder.Entity("MyECommerceWebSite2022.Models.Curunces", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CuruncyNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CuruncyNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isDefualtCuruncy")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("Curunces");
                });

            modelBuilder.Entity("MyECommerceWebSite2022.Models.Groups", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GroupImgFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMainGroup")
                        .HasColumnType("bit");

                    b.Property<int>("mainGroupId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("MyECommerceWebSite2022.Models.InvoiceDetailes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsViewed")
                        .HasColumnType("bit");

                    b.Property<int>("invNo")
                        .HasColumnType("int");

                    b.Property<string>("itemCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("masterId")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.ToTable("InvoiceDetailes");
                });

            modelBuilder.Entity("MyECommerceWebSite2022.Models.InvoiceMaster", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("InvoiceStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("InvoiceTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleverd")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPayed")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerMobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customerTel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("deleverMethod")
                        .HasColumnType("int");

                    b.Property<DateTime>("invoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("paymentMethod")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("InvoiceMaster");
                });

            modelBuilder.Entity("MyECommerceWebSite2022.Models.Items", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("curuncyId")
                        .HasColumnType("int");

                    b.Property<int>("groupId")
                        .HasColumnType("int");

                    b.Property<string>("itemDescreptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemDescreptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemImgFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("itemNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("specialItem")
                        .HasColumnType("bit");

                    b.Property<int>("subGroupId")
                        .HasColumnType("int");

                    b.Property<int>("unitId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("MyECommerceWebSite2022.Models.Slider", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DescreptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescreptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HedarAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HedarEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Slider");
                });

            modelBuilder.Entity("MyECommerceWebSite2022.Models.Units", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UnitNameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitNameEn")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Units");
                });
#pragma warning restore 612, 618
        }
    }
}

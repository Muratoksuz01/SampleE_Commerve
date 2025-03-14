﻿// <auto-generated />
using System;
using E_ticaret.Models.Sınıflar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Ticaret.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250301114519_UpdateFatura1")]
    partial class UpdateFatura1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Cariler", b =>
                {
                    b.Property<int>("CariID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CariID"));

                    b.Property<string>("CariAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CariMail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CariSehir")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CariSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Durum")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CariID");

                    b.ToTable("Carilers");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Admin", b =>
                {
                    b.Property<int>("Adminid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Adminid"));

                    b.Property<string>("KullanıcıAd")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("Varchar");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("Varchar");

                    b.Property<string>("Yetki")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("Char");

                    b.HasKey("Adminid");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Departman", b =>
                {
                    b.Property<int>("DepartmanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("DepartmanID"));

                    b.Property<string>("DepartmanAd")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Durum")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("DepartmanID");

                    b.ToTable("Departmans");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.FaturaKalem", b =>
                {
                    b.Property<int>("FaturaKalemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FaturaKalemID"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<decimal>("BirimFiyat")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("FaturalarFaturaID")
                        .HasColumnType("int");

                    b.Property<int>("Miktar")
                        .HasColumnType("int");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("FaturaKalemID");

                    b.HasIndex("FaturalarFaturaID");

                    b.ToTable("FaturaKalems");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Faturalar", b =>
                {
                    b.Property<int>("FaturaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("FaturaID"));

                    b.Property<string>("FaturaSeriNo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FaturaSıraNo")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Saat")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TeslimAlan")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TeslimEden")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Toplam")
                        .HasColumnType("int");

                    b.Property<string>("VergiDairesi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("FaturaID");

                    b.ToTable("Faturas");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Gider", b =>
                {
                    b.Property<int>("GiderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("GiderID"));

                    b.Property<string>("Aciklama")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Tutar")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("GiderID");

                    b.ToTable("Giders");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Kategori", b =>
                {
                    b.Property<int>("KategoriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("KategoriID"));

                    b.Property<string>("KategoriAd")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("KategoriID");

                    b.ToTable("Kategoris");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Personel", b =>
                {
                    b.Property<int>("PersonelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PersonelID"));

                    b.Property<int>("DepartmanID")
                        .HasColumnType("int");

                    b.Property<string>("PersonelAd")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PersonelGorsel")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PersonelSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("PersonelID");

                    b.HasIndex("DepartmanID");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.SatisHareket", b =>
                {
                    b.Property<int>("Satisid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Satisid"));

                    b.Property<int>("Adet")
                        .HasColumnType("int");

                    b.Property<int>("CarilerCariID")
                        .HasColumnType("int");

                    b.Property<int>("Fiyat")
                        .HasColumnType("int");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Toplam")
                        .HasColumnType("int");

                    b.Property<int>("ToplamTutar")
                        .HasColumnType("int");

                    b.Property<int>("UrunID")
                        .HasColumnType("int");

                    b.HasKey("Satisid");

                    b.HasIndex("CarilerCariID");

                    b.HasIndex("PersonelID");

                    b.HasIndex("UrunID");

                    b.ToTable("SatisHarekets");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Urun", b =>
                {
                    b.Property<int>("UrunID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("UrunID"));

                    b.Property<int>("AlisFiyat")
                        .HasColumnType("int");

                    b.Property<bool>("Durum")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("KategoriID")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<int>("SatisFiyat")
                        .HasColumnType("int");

                    b.Property<short>("Stok")
                        .HasColumnType("smallint");

                    b.Property<string>("UrunAd")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar");

                    b.Property<string>("UrunGorsel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("UrunID");

                    b.HasIndex("KategoriID");

                    b.ToTable("Uruns");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.FaturaKalem", b =>
                {
                    b.HasOne("E_ticaret.Models.Sınıflar.Faturalar", "Faturalar")
                        .WithMany("FaturaKalems")
                        .HasForeignKey("FaturalarFaturaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faturalar");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Personel", b =>
                {
                    b.HasOne("E_ticaret.Models.Sınıflar.Departman", "Departman")
                        .WithMany("Personels")
                        .HasForeignKey("DepartmanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departman");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.SatisHareket", b =>
                {
                    b.HasOne("Cariler", "Cariler")
                        .WithMany("SatisHarekets")
                        .HasForeignKey("CarilerCariID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_ticaret.Models.Sınıflar.Personel", "Personel")
                        .WithMany("SatisHarekets")
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_ticaret.Models.Sınıflar.Urun", "Urun")
                        .WithMany("SatisHarekets")
                        .HasForeignKey("UrunID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cariler");

                    b.Navigation("Personel");

                    b.Navigation("Urun");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Urun", b =>
                {
                    b.HasOne("E_ticaret.Models.Sınıflar.Kategori", "Kategori")
                        .WithMany("Uruns")
                        .HasForeignKey("KategoriID");

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("Cariler", b =>
                {
                    b.Navigation("SatisHarekets");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Departman", b =>
                {
                    b.Navigation("Personels");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Faturalar", b =>
                {
                    b.Navigation("FaturaKalems");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Kategori", b =>
                {
                    b.Navigation("Uruns");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Personel", b =>
                {
                    b.Navigation("SatisHarekets");
                });

            modelBuilder.Entity("E_ticaret.Models.Sınıflar.Urun", b =>
                {
                    b.Navigation("SatisHarekets");
                });
#pragma warning restore 612, 618
        }
    }
}

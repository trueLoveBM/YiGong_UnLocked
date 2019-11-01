﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YiGong.EntityFrameworkCore.OA.EntityFrameworkCore;

namespace YiGong.EntityFrameworkCore.OA.Migrations
{
    [DbContext(typeof(YiGongOADbContext))]
    [Migration("20190801080429_initdatabase")]
    partial class initdatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("YiGong.OAEntities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OrgAddress")
                        .HasMaxLength(500);

                    b.Property<string>("OrgClassification")
                        .HasMaxLength(50);

                    b.Property<string>("OrgCode");

                    b.Property<string>("OrgName")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("OrgPhone")
                        .HasMaxLength(50);

                    b.Property<string>("OrgType")
                        .HasMaxLength(50);

                    b.Property<int?>("ParentOrg_Id");

                    b.HasKey("Id");

                    b.HasIndex("ParentOrg_Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("YiGong.OAEntities.Organization", b =>
                {
                    b.HasOne("YiGong.OAEntities.Organization", "ParentOrg")
                        .WithMany("ChildOrgs")
                        .HasForeignKey("ParentOrg_Id");
                });
#pragma warning restore 612, 618
        }
    }
}

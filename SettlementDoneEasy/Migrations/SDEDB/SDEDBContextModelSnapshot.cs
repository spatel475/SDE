﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SDE_Server.Domain.Entities;

namespace SDE_Server.Migrations.SDEDB
{
    [DbContext(typeof(SDEDBContext))]
    partial class SDEDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SDE_Server.Domain.Entities.Document", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Data")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("TemplateID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TemplateID");

                    b.HasIndex("UserID");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentAudit", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("DocID")
                        .HasColumnType("int");

                    b.Property<string>("FlowState")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DocID");

                    b.ToTable("DocumentAudit");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentData", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<byte[]>("AdjustedData")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ArchiveData")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.ToTable("DocumentData");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentTemplate", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int?>("Creator")
                        .HasColumnType("int");

                    b.Property<byte[]>("Data")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("FlowTemplate")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Creator");

                    b.HasIndex("FlowTemplate");

                    b.HasIndex("OrganizationID");

                    b.ToTable("DocumentTemplate");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentTemplateData", b =>
                {
                    b.Property<byte[]>("Template")
                        .HasColumnType("varbinary(max)");

                    b.Property<int?>("TemplateID")
                        .HasColumnType("int");

                    b.ToTable("DocumentTemplateData");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentUser", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int?>("DocID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DocID");

                    b.HasIndex("UserID");

                    b.ToTable("DocumentUser");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.FlowTemplate", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Machine")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ID");

                    b.ToTable("FlowTemplate");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.Organization", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Type")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.Document", b =>
                {
                    b.HasOne("SDE_Server.Domain.Entities.DocumentTemplate", "Template")
                        .WithMany("Document")
                        .HasForeignKey("TemplateID")
                        .HasConstraintName("FK_Document_DocumentTemplate");

                    b.HasOne("SDE_Server.Domain.Entities.User", "User")
                        .WithMany("Document")
                        .HasForeignKey("UserID")
                        .HasConstraintName("FK_Document.UserID");

                    b.Navigation("Template");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentAudit", b =>
                {
                    b.HasOne("SDE_Server.Domain.Entities.Document", "Doc")
                        .WithMany("DocumentAudit")
                        .HasForeignKey("DocID")
                        .HasConstraintName("FK_DocumentAudit_Document");

                    b.Navigation("Doc");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentData", b =>
                {
                    b.HasOne("SDE_Server.Domain.Entities.Document", "IDNavigation")
                        .WithOne("DocumentData")
                        .HasForeignKey("SDE_Server.Domain.Entities.DocumentData", "ID")
                        .HasConstraintName("FK_DocumentData_Document")
                        .IsRequired();

                    b.Navigation("IDNavigation");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentTemplate", b =>
                {
                    b.HasOne("SDE_Server.Domain.Entities.User", "CreatorNavigation")
                        .WithMany("DocumentTemplate")
                        .HasForeignKey("Creator")
                        .HasConstraintName("FK_DocumentTemplate_Users");

                    b.HasOne("SDE_Server.Domain.Entities.FlowTemplate", "FlowTemplateNavigation")
                        .WithMany("DocumentTemplate")
                        .HasForeignKey("FlowTemplate")
                        .HasConstraintName("FK_DocumentTemplate_FlowTemplate");

                    b.HasOne("SDE_Server.Domain.Entities.Organization", "Organization")
                        .WithMany("DocumentTemplate")
                        .HasForeignKey("OrganizationID")
                        .HasConstraintName("FK_DocumentTemplate.OrganizationID");

                    b.Navigation("CreatorNavigation");

                    b.Navigation("FlowTemplateNavigation");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentUser", b =>
                {
                    b.HasOne("SDE_Server.Domain.Entities.Document", "Doc")
                        .WithMany("DocumentUser")
                        .HasForeignKey("DocID")
                        .HasConstraintName("FK_DocumentUser_Document");

                    b.HasOne("SDE_Server.Domain.Entities.User", "User")
                        .WithMany("DocumentUser")
                        .HasForeignKey("UserID")
                        .HasConstraintName("FK_DocumentUser.UserID");

                    b.Navigation("Doc");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.User", b =>
                {
                    b.HasOne("SDE_Server.Domain.Entities.Organization", "Organization")
                        .WithMany("Users")
                        .HasForeignKey("OrganizationID")
                        .HasConstraintName("FK_Users.OrganizationID");

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.Document", b =>
                {
                    b.Navigation("DocumentAudit");

                    b.Navigation("DocumentData");

                    b.Navigation("DocumentUser");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.DocumentTemplate", b =>
                {
                    b.Navigation("Document");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.FlowTemplate", b =>
                {
                    b.Navigation("DocumentTemplate");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.Organization", b =>
                {
                    b.Navigation("DocumentTemplate");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("SDE_Server.Domain.Entities.User", b =>
                {
                    b.Navigation("Document");

                    b.Navigation("DocumentTemplate");

                    b.Navigation("DocumentUser");
                });
#pragma warning restore 612, 618
        }
    }
}

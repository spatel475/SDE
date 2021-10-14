﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SDE_Server.Domain.Entities
{
    public partial class sqldbsdedevContext : DbContext
    {
        public sqldbsdedevContext()
        {
        }

        public sqldbsdedevContext(DbContextOptions<sqldbsdedevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<DocumentAudit> DocumentAudit { get; set; }
        public virtual DbSet<DocumentData> DocumentData { get; set; }
        public virtual DbSet<DocumentTemplate> DocumentTemplate { get; set; }
        public virtual DbSet<DocumentTemplateData> DocumentTemplateData { get; set; }
        public virtual DbSet<DocumentUser> DocumentUser { get; set; }
        public virtual DbSet<FlowTemplate> FlowTemplate { get; set; }
        public virtual DbSet<Organization> Organization { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sqldb-sde.hastings-network.com;Database=sqldb-sde-dev;User Id=svc-sde-dev;Password=W3HUOsZI9GJ4QsPIfgmT");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Data).IsUnicode(false);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.TemplateID)
                    .HasConstraintName("FK_Document_DocumentTemplate");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_Document.UserID");
            });

            modelBuilder.Entity<DocumentAudit>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FlowState).IsUnicode(false);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocumentAudit)
                    .HasForeignKey(d => d.DocID)
                    .HasConstraintName("FK_DocumentAudit_Document");
            });

            modelBuilder.Entity<DocumentData>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.IDNavigation)
                    .WithOne(p => p.DocumentData)
                    .HasForeignKey<DocumentData>(d => d.ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentData_Document");
            });

            modelBuilder.Entity<DocumentTemplate>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.DocumentTemplate)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_DocumentTemplate_Users");

                entity.HasOne(d => d.FlowTemplateNavigation)
                    .WithMany(p => p.DocumentTemplate)
                    .HasForeignKey(d => d.FlowTemplate)
                    .HasConstraintName("FK_DocumentTemplate_FlowTemplate");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.DocumentTemplate)
                    .HasForeignKey(d => d.OrganizationID)
                    .HasConstraintName("FK_DocumentTemplate.OrganizationID");
            });

            modelBuilder.Entity<DocumentTemplateData>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<DocumentUser>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocumentUser)
                    .HasForeignKey(d => d.DocID)
                    .HasConstraintName("FK_DocumentUser_Document");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DocumentUser)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_DocumentUser.UserID");
            });

            modelBuilder.Entity<FlowTemplate>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Machine)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Username).IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OrganizationID)
                    .HasConstraintName("FK_Users.OrganizationID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
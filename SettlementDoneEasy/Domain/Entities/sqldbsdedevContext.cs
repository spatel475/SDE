using System;
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

        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentAudit> DocumentAudits { get; set; }
        public virtual DbSet<DocumentDatum> DocumentData { get; set; }
        public virtual DbSet<DocumentTemplate> DocumentTemplates { get; set; }
        public virtual DbSet<DocumentTemplateDatum> DocumentTemplateData { get; set; }
        public virtual DbSet<DocumentUser> DocumentUsers { get; set; }
        public virtual DbSet<FlowTemplate> FlowTemplates { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppSettings.GetSettings().DBConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Data).IsUnicode(false);

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.TemplateID)
                    .HasConstraintName("FK_Document_DocumentTemplate");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_Document.UserID");
            });

            modelBuilder.Entity<DocumentAudit>(entity =>
            {
                entity.ToTable("DocumentAudit");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FlowState).IsUnicode(false);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocumentAudits)
                    .HasForeignKey(d => d.DocID)
                    .HasConstraintName("FK_DocumentAudit_Document");
            });

            modelBuilder.Entity<DocumentDatum>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.IDNavigation)
                    .WithOne(p => p.DocumentDatum)
                    .HasForeignKey<DocumentDatum>(d => d.ID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentData_Document");
            });

            modelBuilder.Entity<DocumentTemplate>(entity =>
            {
                entity.ToTable("DocumentTemplate");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.DocumentTemplates)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_DocumentTemplate_Users");

                entity.HasOne(d => d.FlowTemplateNavigation)
                    .WithMany(p => p.DocumentTemplates)
                    .HasForeignKey(d => d.FlowTemplate)
                    .HasConstraintName("FK_DocumentTemplate_FlowTemplate");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.DocumentTemplates)
                    .HasForeignKey(d => d.OrganizationID)
                    .HasConstraintName("FK_DocumentTemplate.OrganizationID");
            });

            modelBuilder.Entity<DocumentTemplateDatum>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<DocumentUser>(entity =>
            {
                entity.ToTable("DocumentUser");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocumentUsers)
                    .HasForeignKey(d => d.DocID)
                    .HasConstraintName("FK_DocumentUser_Document");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DocumentUsers)
                    .HasForeignKey(d => d.UserID)
                    .HasConstraintName("FK_DocumentUser.UserID");
            });

            modelBuilder.Entity<FlowTemplate>(entity =>
            {
                entity.ToTable("FlowTemplate");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Machine)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Type).IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
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

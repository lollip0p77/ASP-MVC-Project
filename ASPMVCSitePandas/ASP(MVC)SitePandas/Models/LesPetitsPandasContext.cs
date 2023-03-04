using System;
using System.Collections.Generic;
using ASP_MVC_SitePandas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASP_MVC_SitePandas.Models
{
    public partial class LesPetitsPandasContext : DbContext
    {
        public LesPetitsPandasContext()
        {
        }

        public LesPetitsPandasContext(DbContextOptions<LesPetitsPandasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AllergiesEnfant> AllergiesEnfants { get; set; } = null!;
        public virtual DbSet<Allergy> Allergies { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        /**/
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; } = null!;
        /**/
        public virtual DbSet<DocumentsGenerale> DocumentsGenerales { get; set; } = null!;
        public virtual DbSet<DocumentsParent> DocumentsParents { get; set; } = null!;
        public virtual DbSet<Educatrice> Educatrices { get; set; } = null!;
        public virtual DbSet<Enfant> Enfants { get; set; } = null!;
        public virtual DbSet<Evenement> Evenements { get; set; } = null!;
        public virtual DbSet<Garderie> Garderies { get; set; } = null!;
        public virtual DbSet<ListeDattente> ListeDattentes { get; set; } = null!;
        public virtual DbSet<Medicament> Medicaments { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<PersonnesAutoriser> PersonnesAutorisers { get; set; } = null!;
        public virtual DbSet<Presence> Presences { get; set; } = null!;
        public virtual DbSet<Repondant> Repondants { get; set; } = null!;
        public virtual DbSet<TypeEvenement> TypeEvenements { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AllergiesEnfant>(entity =>
            {
                entity.HasOne(d => d.Allergie)
                    .WithMany(p => p.AllergiesEnfants)
                    .HasForeignKey(d => d.AllergieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllergiesEnfant_Allergies");

                entity.HasOne(d => d.Enfant)
                    .WithMany(p => p.AllergiesEnfants)
                    .HasForeignKey(d => d.EnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AllergiesEnfant_Enfants");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.HasMany(d => d.Roles);
                    //.WithMany(p => p.Users)
                    //.UsingEntity<Dictionary<string, object>>(
                    //    "AspNetUserRole",
                    //    l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    //    r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    //    j =>
                    //    {
                    //        j.HasKey("UserId", "RoleId");

                    //        j.ToTable("AspNetUserRoles");

                    //        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    //    });
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });
            // A ajouter pour la gestion des utilisateurs
            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey("UserId", "RoleId");

                entity.HasOne(r => r.Role)
               .WithMany(ur => ur.UserRoles)
               .HasForeignKey(r => r.RoleId);

                entity.HasOne(r => r.User)
               .WithMany(ur => ur.UserRoles)
               .HasForeignKey(r => r.UserId);

            });
            
            modelBuilder.Entity<DocumentsParent>(entity =>
            {
                entity.HasOne(d => d.Repondant)
                    .WithMany(p => p.DocumentsParents)
                    .HasForeignKey(d => d.RepondantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DocumentsParent_Repondant");
            });

            modelBuilder.Entity<Educatrice>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Educatrices)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Educatrices_AspNetUsers");
            });

            modelBuilder.Entity<Enfant>(entity =>
            {
                entity.HasOne(d => d.Repondant)
                    .WithMany(p => p.Enfants)
                    .HasForeignKey(d => d.RepondantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Enfants_Repondant");
            });

            modelBuilder.Entity<Evenement>(entity =>
            {
                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Evenements)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evenements_TypeEvenement");
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.HasOne(d => d.Enfant)
                    .WithMany(p => p.Medicaments)
                    .HasForeignKey(d => d.EnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Medicaments_Enfants");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.Property(e => e.Envoyeur).IsFixedLength();

                entity.HasOne(d => d.Educatrice)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.EducatriceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Educatrices1");

                entity.HasOne(d => d.Repondant)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.RepondantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Repondant");
            });

            modelBuilder.Entity<PersonnesAutoriser>(entity =>
            {
                entity.HasOne(d => d.Enfant)
                    .WithMany(p => p.PersonnesAutorisers)
                    .HasForeignKey(d => d.EnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PersonnesAutoriser_Enfants");
            });

            modelBuilder.Entity<Presence>(entity =>
            {
                entity.HasKey(e => new { e.EnfantId, e.EvenementId })
                    .HasName("PK__Presence__6D87D42FCA11B811");

                entity.HasOne(d => d.Enfant)
                    .WithMany(p => p.Presences)
                    .HasForeignKey(d => d.EnfantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Presences__Enfan__33D4B598");

                entity.HasOne(d => d.Evenement)
                    .WithMany(p => p.Presences)
                    .HasForeignKey(d => d.EvenementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Presences__Evene__34C8D9D1");
            });

            modelBuilder.Entity<Repondant>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Repondants)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Repondant_AspNetUsers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PetAdoptionApp.Models
{
    public partial class PetAdoptionAppContext : DbContext
    {
        public PetAdoptionAppContext()
        {
        }

        public PetAdoptionAppContext(DbContextOptions<PetAdoptionAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavPet> FavPets { get; set; }
        public virtual DbSet<LocationAddress> LocationAddresses { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Roll> Rolls { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<UserClient> UserClients { get; set; }
        public virtual DbSet<Vacine> Vacines { get; set; }
        public virtual DbSet<WebsiteLink> WebsiteLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(Local);Database=PetAdoptionApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavPet>(entity =>
            {
                entity.ToTable("FavPet");

                entity.Property(e => e.PetIdFk).HasColumnName("PetId_FK");

                entity.Property(e => e.UserIdFk).HasColumnName("UserId_FK");

                entity.HasOne(d => d.PetIdFkNavigation)
                    .WithMany(p => p.FavPets)
                    .HasForeignKey(d => d.PetIdFk)
                    .HasConstraintName("FK__FavPet__PetId_FK__07C12930");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.FavPets)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("FK__FavPet__UserId_F__06CD04F7");
            });

            modelBuilder.Entity<LocationAddress>(entity =>
            {
                entity.ToTable("LocationAddress");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pet>(entity =>
            {
                entity.ToTable("Pet");

                entity.Property(e => e.Bio)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Breed)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageIdFk).HasColumnName("ImageId_FK");

                entity.Property(e => e.LocationIdFk).HasColumnName("LocationId_FK");

                entity.Property(e => e.PetName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetTypeIdFk).HasColumnName("PetTypeID_FK");

                entity.Property(e => e.Sex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamps)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserIdFk).HasColumnName("UserId_FK");

                entity.HasOne(d => d.ImageIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.ImageIdFk)
                    .HasConstraintName("FK__Pet__ImageId_FK__7C4F7684");

                entity.HasOne(d => d.LocationIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.LocationIdFk)
                    .HasConstraintName("FK__Pet__LocationId___7D439ABD");

                entity.HasOne(d => d.PetTypeIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.PetTypeIdFk)
                    .HasConstraintName("FK__Pet__PetTypeID_F__7B5B524B");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("FK__Pet__UserId_FK__7A672E12");
            });

            modelBuilder.Entity<PetType>(entity =>
            {
                entity.ToTable("PetType");

                entity.Property(e => e.PetType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PetType");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");

                entity.Property(e => e.PicturePath)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Roll>(entity =>
            {
                entity.ToTable("Roll");

                entity.Property(e => e.ClientRole)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Treatment>(entity =>
            {
                entity.ToTable("Treatment");

                entity.Property(e => e.AplicationDate).HasColumnType("date");

                entity.Property(e => e.PetIdFk).HasColumnName("PetId_FK");

                entity.Property(e => e.TreatmentLabel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PetIdFkNavigation)
                    .WithMany(p => p.Treatments)
                    .HasForeignKey(d => d.PetIdFk)
                    .HasConstraintName("FK__Treatment__PetId__03F0984C");
            });

            modelBuilder.Entity<UserClient>(entity =>
            {
                entity.ToTable("UserClient");

                entity.HasIndex(e => e.Email, "UQ__UserClie__A9D10534591EC65C")
                    .IsUnique();

                entity.Property(e => e.Bio)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailVerifiedAt)
                    .HasColumnType("date")
                    .HasColumnName("Email_Verified_At");

                entity.Property(e => e.ImageIdFk).HasColumnName("ImageId_FK");

                entity.Property(e => e.IsActive)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationIdFk).HasColumnName("LocationId_FK");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RollIdFk).HasColumnName("RollId_FK");

                entity.Property(e => e.Timestamps)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ImageIdFkNavigation)
                    .WithMany(p => p.UserClients)
                    .HasForeignKey(d => d.ImageIdFk)
                    .HasConstraintName("FK__UserClien__Image__71D1E811");

                entity.HasOne(d => d.LocationIdFkNavigation)
                    .WithMany(p => p.UserClients)
                    .HasForeignKey(d => d.LocationIdFk)
                    .HasConstraintName("FK__UserClien__Locat__70DDC3D8");

                entity.HasOne(d => d.RollIdFkNavigation)
                    .WithMany(p => p.UserClients)
                    .HasForeignKey(d => d.RollIdFk)
                    .HasConstraintName("FK__UserClien__RollI__6FE99F9F");
            });

            modelBuilder.Entity<Vacine>(entity =>
            {
                entity.ToTable("Vacine");

                entity.Property(e => e.AplicationDate).HasColumnType("date");

                entity.Property(e => e.AplicationPlace)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetIdFk).HasColumnName("PetId_FK");

                entity.Property(e => e.VacineLabel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PetIdFkNavigation)
                    .WithMany(p => p.Vacines)
                    .HasForeignKey(d => d.PetIdFk)
                    .HasConstraintName("FK__Vacine__PetId_FK__01142BA1");
            });

            modelBuilder.Entity<WebsiteLink>(entity =>
            {
                entity.ToTable("WebsiteLink");

                entity.Property(e => e.Link)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.UserIdFk).HasColumnName("UserId_FK");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.WebsiteLinks)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("FK__WebsiteLi__UserI__75A278F5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

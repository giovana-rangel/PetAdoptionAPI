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

        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(Local);Database=PetAdoptionApp;Trusted_Connection=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breed>(entity =>
            {
                entity.ToTable("Breed");

                entity.Property(e => e.Breed1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Breed");

                entity.Property(e => e.PetTypeIdFk).HasColumnName("PetTypeId_FK");

                entity.HasOne(d => d.PetTypeIdFkNavigation)
                    .WithMany(p => p.Breeds)
                    .HasForeignKey(d => d.PetTypeIdFk)
                    .HasConstraintName("FK__Breed__PetTypeId__37FA4C37");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("Color");

                entity.Property(e => e.Color1)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("Color");
            });

            modelBuilder.Entity<FavPet>(entity =>
            {
                entity.ToTable("FavPet");

                entity.Property(e => e.PetIdFk).HasColumnName("PetId_FK");

                entity.Property(e => e.UserIdFk).HasColumnName("UserId_FK");

                entity.HasOne(d => d.PetIdFkNavigation)
                    .WithMany(p => p.FavPets)
                    .HasForeignKey(d => d.PetIdFk)
                    .HasConstraintName("FK__FavPet__PetId_FK__4CF5691D");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.FavPets)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("FK__FavPet__UserId_F__4C0144E4");
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

                entity.Property(e => e.Age)
                    .HasColumnType("numeric(1, 0)")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Bio)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.BreedIdFk).HasColumnName("BreedId_FK");

                entity.Property(e => e.ColorIdFk).HasColumnName("ColorId_FK");

                entity.Property(e => e.ImageIdFk).HasColumnName("ImageId_FK");

                entity.Property(e => e.IsAdopted)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("is_adopted")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LocationIdFk).HasColumnName("LocationId_FK");

                entity.Property(e => e.PetName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PetTypeIdFk).HasColumnName("PetTypeId_FK");

                entity.Property(e => e.Sex)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("sex")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Timestamps)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserIdFk).HasColumnName("UserId_FK");

                entity.HasOne(d => d.BreedIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.BreedIdFk)
                    .HasConstraintName("FK__Pet__BreedId_FK__3F9B6DFF");

                entity.HasOne(d => d.ColorIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.ColorIdFk)
                    .HasConstraintName("FK__Pet__ColorId_FK__3EA749C6");

                entity.HasOne(d => d.ImageIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.ImageIdFk)
                    .HasConstraintName("FK__Pet__ImageId_FK__4183B671");

                entity.HasOne(d => d.LocationIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.LocationIdFk)
                    .HasConstraintName("FK__Pet__LocationId___4277DAAA");

                entity.HasOne(d => d.PetTypeIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.PetTypeIdFk)
                    .HasConstraintName("FK__Pet__PetTypeId_F__3DB3258D");

                entity.HasOne(d => d.UserIdFkNavigation)
                    .WithMany(p => p.Pets)
                    .HasForeignKey(d => d.UserIdFk)
                    .HasConstraintName("FK__Pet__UserId_FK__408F9238");
            });

            modelBuilder.Entity<PetType>(entity =>
            {
                entity.ToTable("PetType");

                entity.Property(e => e.PetType1)
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
                    .HasConstraintName("FK__Treatment__PetId__4924D839");
            });

            modelBuilder.Entity<UserClient>(entity =>
            {
                entity.ToTable("UserClient");

                entity.HasIndex(e => e.Email, "UQ__UserClie__A9D105348FC892A2")
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
                    .HasConstraintName("FK__UserClien__Image__2D7CBDC4");

                entity.HasOne(d => d.LocationIdFkNavigation)
                    .WithMany(p => p.UserClients)
                    .HasForeignKey(d => d.LocationIdFk)
                    .HasConstraintName("FK__UserClien__Locat__2C88998B");

                entity.HasOne(d => d.RollIdFkNavigation)
                    .WithMany(p => p.UserClients)
                    .HasForeignKey(d => d.RollIdFk)
                    .HasConstraintName("FK__UserClien__RollI__2B947552");
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
                    .HasConstraintName("FK__Vacine__PetId_FK__46486B8E");
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
                    .HasConstraintName("FK__WebsiteLi__UserI__314D4EA8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

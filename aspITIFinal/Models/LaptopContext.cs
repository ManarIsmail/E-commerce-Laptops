using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace aspITIFinal.Models
{
    public partial class LaptopContext : DbContext
    {
        public LaptopContext()
        {
        }

        public LaptopContext(DbContextOptions<LaptopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<Subscribe> Subscribes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KIRITO\\MSSQLSERVER2;Database=Laptop;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Arabic_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category1).HasColumnName("category");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Message).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .HasColumnName("subject");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Color).HasColumnName("color");

                entity.Property(e => e.GraphicsCardBrand).HasColumnName("graphics_card_brand");

                entity.Property(e => e.GraphicsCardCapacity).HasColumnName("graphics_card_capacity");

                entity.Property(e => e.HardDiskCapacity).HasColumnName("hard_disk_capacity");

                entity.Property(e => e.IdCat).HasColumnName("id_cat");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.ModelName).HasColumnName("model_name");

                entity.Property(e => e.OperatingSystem).HasColumnName("operating_system");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.ProcessorCore).HasColumnName("processor_core");

                entity.Property(e => e.ProcessorType).HasColumnName("processor_type");

                entity.Property(e => e.RamCapacity).HasColumnName("RAM_capacity");

                entity.Property(e => e.ScreenSize).HasColumnName("screen_size");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.IdCatNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCat)
                    .HasConstraintName("FK_Product_Category");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_Product_images_Product");
            });

            modelBuilder.Entity<Subscribe>(entity =>
            {
                entity.ToTable("Subscribe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRentalLibrary.Models
{
    public partial class CarRentalDBContext : DbContext
    {
        public CarRentalDBContext()
        {
        }

        public CarRentalDBContext(DbContextOptions<CarRentalDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Carrental> Carrentals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=mysqlserver4api.cbavqb8qhxfj.ca-central-1.rds.amazonaws.com,1433;Initial Catalog=CarRentalDB;User Id=teenaabraham;Password=teenaabraham;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("booking");

                entity.Property(e => e.Bookingid).HasColumnName("bookingid");

                entity.Property(e => e.Bookingdate)
                    .HasColumnType("date")
                    .HasColumnName("bookingdate");

                entity.Property(e => e.Carid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carid");

                entity.Property(e => e.Carrentalcompanyid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carrentalcompanyid");

                entity.Property(e => e.Customername)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("customername");

                entity.Property(e => e.InsuranceNeeded).HasColumnName("insurance_needed");

                entity.Property(e => e.Luggagespace).HasColumnName("luggagespace");

                entity.Property(e => e.Numberofpeople).HasColumnName("numberofpeople");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Carid)
                    .HasConstraintName("FK__booking__carid__3B75D760");

                entity.HasOne(d => d.Carrentalcompany)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.Carrentalcompanyid)
                    .HasConstraintName("FK__booking__carrent__3C69FB99");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("car");

                entity.Property(e => e.Carid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carid");

                entity.Property(e => e.Caravailability)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("caravailability");

                entity.Property(e => e.Carmodel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("carmodel");

                entity.Property(e => e.Carrentalid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carrentalid");

                entity.Property(e => e.Freecancelation).HasColumnName("freecancelation");

                entity.Property(e => e.Fueltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fueltype");

                entity.Property(e => e.Geartype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("geartype");

                entity.Property(e => e.Insuranceamount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("insuranceamount");

                entity.Property(e => e.Luggagespace)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("luggagespace");

                entity.Property(e => e.Mileage)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mileage");

                entity.Property(e => e.Noofdoors).HasColumnName("noofdoors");

                entity.Property(e => e.Rentalpriceperday)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("rentalpriceperday");

                entity.HasOne(d => d.Carrental)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Carrentalid)
                    .HasConstraintName("FK__car__carrentalid__38996AB5");
            });

            modelBuilder.Entity<Carrental>(entity =>
            {
                entity.ToTable("carrental");

                entity.Property(e => e.Carrentalid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("carrentalid");

                entity.Property(e => e.Carrentalcompanyname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("carrentalcompanyname");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("location");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

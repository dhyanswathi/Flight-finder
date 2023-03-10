// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Flight_Finder.Api.Models
{
    public partial class FlightFinderDBContext : DbContext
    {
        public FlightFinderDBContext()
        {
        }

        public FlightFinderDBContext(DbContextOptions<FlightFinderDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<FlightRoute> FlightRoutes { get; set; }
        public virtual DbSet<Itinerary> Itineraries { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.BookingId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.Child).HasColumnName("child");

                entity.Property(e => e.FlightId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.FlightId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings__Flight__4316F928");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bookings__UserId__440B1D61");
            });

            modelBuilder.Entity<FlightRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PK__FlightRo__80979B4D9308333F");

                entity.Property(e => e.RouteId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalDestination)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureDestination)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Itinerary>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK__Itinerar__8A9E14EECCC0B374");

                entity.Property(e => e.FlightId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ArrivalAt).HasColumnType("datetime");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DepartureAt).HasColumnType("datetime");

                entity.Property(e => e.RouteId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.Itineraries)
                    .HasForeignKey(d => d.RouteId)
                    .HasConstraintName("FK__Itinerari__Route__3E52440B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
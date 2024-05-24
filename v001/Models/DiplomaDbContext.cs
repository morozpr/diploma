using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace v001.Models;

public partial class DiplomaDbContext : IdentityDbContext<User>
{
    public DiplomaDbContext()
    {
    }

    public DiplomaDbContext(DbContextOptions<DiplomaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookStatusType> BookStatusTypes { get; set; }

    public virtual DbSet<Cost> Costs { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomType> RoomTypes { get; set; }

    public virtual DbSet<Tariff> Tariffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5433;Database=diplomaDB;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("Book_pkey");

            entity.ToTable("Book");

            entity.Property(e => e.BookId)
                .ValueGeneratedNever()
                .HasColumnName("BookID");
            entity.Property(e => e.BookStatusTypeId).HasColumnName("BookStatusTypeID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");

            entity.HasOne(d => d.BookStatusType).WithMany(p => p.Books)
                .HasForeignKey(d => d.BookStatusTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("BookStatusTypeID");

            entity.HasOne(d => d.Order).WithMany(p => p.Books)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderID");
        });

        modelBuilder.Entity<BookStatusType>(entity =>
        {
            entity.HasKey(e => e.BookStatusTypeId).HasName("BookStatusType_pkey");

            entity.ToTable("BookStatusType");

            entity.Property(e => e.BookStatusTypeId)
                .ValueGeneratedNever()
                .HasColumnName("BookStatusTypeID");
            entity.Property(e => e.BookStatusTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Cost>(entity =>
        {
            entity.HasKey(e => e.CostId).HasName("Cost_pkey");

            entity.ToTable("Cost");

            entity.Property(e => e.CostId)
                .ValueGeneratedNever()
                .HasColumnName("CostID");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("Discount_pkey");

            entity.ToTable("Discount");

            entity.Property(e => e.DiscountId)
                .ValueGeneratedNever()
                .HasColumnName("DiscountID");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GuestId).HasName("Guest_pkey");

            entity.ToTable("Guest");

            entity.Property(e => e.GuestId)
                .ValueGeneratedNever()
                .HasColumnName("GuestID");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.SecondName).HasMaxLength(50);
            entity.Property(e => e.Sex).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId)
                .ValueGeneratedNever()
                .HasColumnName("OrderID");
            entity.Property(e => e.BookTimeFrom).HasPrecision(6);
            entity.Property(e => e.BookTimeTo).HasPrecision(6);
            entity.Property(e => e.CostId).HasColumnName("CostID");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.DiscountId).HasColumnName("DiscountID");
            entity.Property(e => e.GuestId).HasColumnName("GuestID");
            entity.Property(e => e.OrderStatusId).HasColumnName("OrderStatusID");
            entity.Property(e => e.RoomId).HasColumnName("RoomID");
            entity.Property(e => e.TariffId).HasColumnName("TariffID");

            entity.HasOne(d => d.Cost).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CostID");

            entity.HasOne(d => d.Discount).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DiscountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("DiscountID");

            entity.HasOne(d => d.Guest).WithMany(p => p.Orders)
                .HasForeignKey(d => d.GuestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("GuestID");

            entity.HasOne(d => d.OrderStatus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderStatusID");

            entity.HasOne(d => d.Room).WithMany(p => p.Orders)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoomID");

            entity.HasOne(d => d.Tariff).WithMany(p => p.Orders)
                .HasForeignKey(d => d.TariffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("TariffID");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.OrderStatusId).HasName("OrderStatus_pkey");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.OrderStatusId)
                .ValueGeneratedNever()
                .HasColumnName("OrderStatusID");
            entity.Property(e => e.OrderStatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("Room_pkey");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("RoomID");
            entity.Property(e => e.RoomName).HasMaxLength(50);
            entity.Property(e => e.RoomTypeId).HasColumnName("RoomTypeID");

            entity.HasOne(d => d.RoomType).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RoomTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("RoomTypeID");
        });

        modelBuilder.Entity<RoomType>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("RoomType_pkey");

            entity.ToTable("RoomType");

            entity.Property(e => e.RoomTypeId)
                .ValueGeneratedNever()
                .HasColumnName("RoomTypeID");
            entity.Property(e => e.RoomTypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.HasKey(e => e.TariffId).HasName("Tariff_pkey");

            entity.ToTable("Tariff");

            entity.Property(e => e.TariffId)
                .ValueGeneratedNever()
                .HasColumnName("TariffID");
            entity.Property(e => e.TariffName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

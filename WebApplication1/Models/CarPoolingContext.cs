using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Car_pooling.Models;

public partial class CarPoolingContext : DbContext
{
    public CarPoolingContext()
    {
    }

    public CarPoolingContext(DbContextOptions<CarPoolingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PoolingCreater> PoolingCreaters { get; set; }

    public virtual DbSet<PoolingUser> PoolingUsers { get; set; }

    public virtual DbSet<Subscribtion> Subscribtions { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CVC222;Initial Catalog=Car_pooling;Persist Security Info=True;User ID=sa;Password=cybage@123456;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PoolingCreater>(entity =>
        {
            entity.HasKey(e => e.PoolingCreaterIdPk).HasName("pooling_PoolingId_Pk");

            entity.ToTable("Pooling_Creater");

            entity.Property(e => e.PoolingCreaterIdPk).HasColumnName("PoolingCreaterId_pk");
            entity.Property(e => e.EndingDestination)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Ending_Destination");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.PoolCreaterIdFk).HasColumnName("PoolCreater_Id_fk");
            entity.Property(e => e.PoolDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pool_Date");
            entity.Property(e => e.PoolTime)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pool_time");
            entity.Property(e => e.SeatNumbers).HasColumnName("Seat_numbers");
            entity.Property(e => e.StartingDestination)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Starting_Destination");
            entity.Property(e => e.VehicleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vehicle_Name");
            entity.Property(e => e.VehicleRegNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Vehicle_reg_number");

            entity.HasOne(d => d.PoolCreaterIdFkNavigation).WithMany(p => p.PoolingCreaters)
                .HasForeignKey(d => d.PoolCreaterIdFk)
                .HasConstraintName("poolcreate_Userid_fk");
        });

        modelBuilder.Entity<PoolingUser>(entity =>
        {
            entity.HasKey(e => e.PoolingIdPk).HasName("poolinguser_PoolingId_Pk");

            entity.ToTable("Pooling_user");

            entity.Property(e => e.PoolingIdPk).HasColumnName("PoolingId_pk");
            entity.Property(e => e.EndingDestination)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Ending_Destination");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.PoolCreateIdFk).HasColumnName("PoolCreate_Id_fk");
            entity.Property(e => e.PoolUserIdFk).HasColumnName("PoolUser_Id_fk");
            entity.Property(e => e.StartingDestination)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Starting_Destination");

            entity.HasOne(d => d.PoolCreateIdFkNavigation).WithMany(p => p.PoolingUsers)
                .HasForeignKey(d => d.PoolCreateIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("poolinguser_createid_fk");

            entity.HasOne(d => d.PoolUserIdFkNavigation).WithMany(p => p.PoolingUsers)
                .HasForeignKey(d => d.PoolUserIdFk)
                .HasConstraintName("poolingUser_Userid_fk");
        });

        modelBuilder.Entity<Subscribtion>(entity =>
        {
            entity.HasKey(e => e.SubId).HasName("sub_SubID_Pk");

            entity.ToTable("Subscribtion");

            entity.Property(e => e.SubCalls).HasColumnName("sub_calls");
            entity.Property(e => e.SubType)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserIdPk).HasName("User_UserId_Pk");

            entity.HasIndex(e => e.UserEmail, "User_User_uq").IsUnique();

            entity.Property(e => e.UserIdPk).HasColumnName("UserId_pk");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isDeleted");
            entity.Property(e => e.UserCity)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPhonenumber).HasMaxLength(50);
            entity.Property(e => e.UserRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserSubFk).HasColumnName("UserSub_fk");

            entity.HasOne(d => d.UserSubFkNavigation).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserSubFk)
                .HasConstraintName("User_UserSub_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

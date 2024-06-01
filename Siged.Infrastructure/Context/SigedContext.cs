using Microsoft.EntityFrameworkCore;
using Siged.Domain.Entities;

namespace Siged.Domain;

public partial class SigedContext : DbContext
{
    public SigedContext()
    {
    }

    public SigedContext(DbContextOptions<SigedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C22CF6FC4");

            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CheckIn).HasColumnName("Check_in");
            entity.Property(e => e.CheckOut).HasColumnName("Check_out");
            entity.Property(e => e.HoursWorked)
                .HasComputedColumnSql("(CONVERT([decimal](5,2),datediff(minute,[Check_in],[Check_out])/(60.0)))", false)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Hours_worked");

            entity.HasOne(d => d.User).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Attendanc__UserI__4AB81AF0");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED890B3F84");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("PK__JobTitle__35382FE9F0106637");

            entity.ToTable("JobTitle");

            entity.Property(e => e.JobTitleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F19431910D");

            entity.ToTable("Rol");

            entity.Property(e => e.NameRol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__Salary__4BE20457DCCFF487");

            entity.ToTable("Salary");

            entity.Property(e => e.Amount)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C3752F288");

            entity.ToTable("UserInfo");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdentificationCard)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__UserInfo__Depart__44FF419A");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.JobTitleId)
                .HasConstraintName("FK__UserInfo__JobTit__440B1D61");

            entity.HasOne(d => d.Rol).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__UserInfo__RolId__4316F928");

            entity.HasOne(d => d.Salary).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.SalaryId)
                .HasConstraintName("FK__UserInfo__Salary__45F365D3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

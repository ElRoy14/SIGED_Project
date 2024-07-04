using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Siged.Domain;

namespace Siged.Infrastructure.Context;

public partial class DbSigedContext : DbContext
{
    public DbSigedContext()
    {
    }

    public DbSigedContext(DbContextOptions<DbSigedContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppliedTaxis> AppliedTaxes { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Evaluator> Evaluators { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<JobTitle> JobTitles { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }

    public virtual DbSet<PaymentServiceInvoiceStatus> PaymentServiceInvoiceStatuses { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PerformanceEvaluation> PerformanceEvaluations { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolMenu> RolMenus { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<ServiceName> ServiceNames { get; set; }

    public virtual DbSet<ServicePaymentInvoice> ServicePaymentInvoices { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TaskStatusEmployee> TaskStatusEmployees { get; set; }

    public virtual DbSet<TasksEmployee> TasksEmployees { get; set; }

    public virtual DbSet<TaxPercentage> TaxPercentages { get; set; }

    public virtual DbSet<Taxis> Taxes { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppliedTaxis>(entity =>
        {
            entity.HasKey(e => e.AppliedTaxesId).HasName("PK__AppliedT__A5E260D90AFDCFD0");

            entity.Property(e => e.TaxToApply)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69261C761E68D3");

            entity.ToTable("Attendance");

            entity.Property(e => e.AttendanceDate)
                .HasDefaultValueSql("(CONVERT(VARCHAR(30), GETDATE(), 103))")
                .HasColumnType("datetime");
            entity.Property(e => e.CheckIn).HasColumnName("Check_in");
            entity.Property(e => e.CheckOut).HasColumnName("Check_out");
            entity.Property(e => e.HoursWorked)
                .HasComputedColumnSql("(CONVERT([decimal](5,2),datediff(minute,[Check_in],[Check_out])/(60.0)))", false)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Hours_worked");

            entity.HasOne(d => d.User).WithMany(p => p.Attendances)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Attendanc__UserI__4F7CD00D");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D8E589EF36");

            entity.ToTable("Customer");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdentificationCard)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED736CFC23");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DiscountsId).HasName("PK__Discount__5752E261D70095D7");

            entity.Property(e => e.ServiceDiscount)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Evaluator>(entity =>
        {
            entity.HasKey(e => e.EvaluatorId).HasName("PK__Evaluato__7AA1AEEA0E0CB451");

            entity.ToTable("Evaluator");

            entity.HasOne(d => d.User).WithMany(p => p.Evaluators)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Evaluator__UserI__619B8048");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK__Goals__8A4FFFD1AA51D6C0");

            entity.Property(e => e.Goal1)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Goal");
            entity.Property(e => e.GoalValue)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<JobTitle>(entity =>
        {
            entity.HasKey(e => e.JobTitleId).HasName("PK__JobTitle__35382FE9D7177857");

            entity.ToTable("JobTitle");

            entity.Property(e => e.JobTitleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("PK__Menu__C99ED2307985A5E2");

            entity.ToTable("Menu");

            entity.Property(e => e.ActionPage)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Controller)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.DescriptionMenu)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IconMenu)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.ParentMenu).WithMany(p => p.InverseParentMenu)
                .HasForeignKey(d => d.ParentMenuId)
                .HasConstraintName("FK__Menu__ParentMenu__37A5467C");
        });

        modelBuilder.Entity<PaymentMethod>(entity =>
        {
            entity.HasKey(e => e.PaymentMethodId).HasName("PK__PaymentM__DC31C1D3D4A10A26");

            entity.ToTable("PaymentMethod");

            entity.Property(e => e.PaymentMethod1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PaymentMethod");
        });

        modelBuilder.Entity<PaymentServiceInvoiceStatus>(entity =>
        {
            entity.HasKey(e => e.PaymentServiceInvoiceStatusId).HasName("PK__PaymentS__A8E7BB1520D58DD6");

            entity.ToTable("PaymentServiceInvoiceStatus");

            entity.Property(e => e.ServicePaymentStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK__Payroll__99DFC67232ECB696");

            entity.ToTable("Payroll");

            entity.Property(e => e.PaymentDate)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Tax).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.TaxId)
                .HasConstraintName("FK__Payroll__TaxId__5CD6CB2B");

            entity.HasOne(d => d.User).WithMany(p => p.Payrolls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Payroll__UserId__5BE2A6F2");
        });

        modelBuilder.Entity<PerformanceEvaluation>(entity =>
        {
            entity.HasKey(e => e.PerformanceEvaluationId).HasName("PK__Performa__7479143382F93B57");

            entity.ToTable("PerformanceEvaluation");

            entity.Property(e => e.Rating)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Evaluator).WithMany(p => p.PerformanceEvaluations)
                .HasForeignKey(d => d.EvaluatorId)
                .HasConstraintName("FK__Performan__Evalu__6477ECF3");

            entity.HasOne(d => d.Goal).WithMany(p => p.PerformanceEvaluations)
                .HasForeignKey(d => d.GoalId)
                .HasConstraintName("FK__Performan__GoalI__656C112C");

            entity.HasOne(d => d.User).WithMany(p => p.PerformanceEvaluations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Performan__UserI__66603565");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Rol__F92302F106B6708D");

            entity.ToTable("Rol");

            entity.Property(e => e.NameRol)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.HasKey(e => e.RolMenuId).HasName("PK__RolMenu__8339C1FEF7982A58");

            entity.ToTable("RolMenu");

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Menu).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.MenuId)
                .HasConstraintName("FK__RolMenu__MenuId__3F466844");

            entity.HasOne(d => d.Rol).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__RolMenu__RolId__3E52440B");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__Salary__4BE20457D7BF393F");

            entity.ToTable("Salary");

            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<ServiceName>(entity =>
        {
            entity.HasKey(e => e.ServiceNameId).HasName("PK__ServiceN__318EB28E5761500B");

            entity.ToTable("ServiceName");

            entity.Property(e => e.ServiceName1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ServiceName");
        });

        modelBuilder.Entity<ServicePaymentInvoice>(entity =>
        {
            entity.HasKey(e => e.ServiceInvoiceId).HasName("PK__ServiceP__3D59F6C5E4D837FB");

            entity.ToTable("ServicePaymentInvoice");

            entity.Property(e => e.InvoiceNumber)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ServiceConsumedDetails)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.AppliedTaxes).WithMany(p => p.ServicePaymentInvoices)
                .HasForeignKey(d => d.AppliedTaxesId)
                .HasConstraintName("FK__ServicePa__Appli__00200768");

            entity.HasOne(d => d.Discounts).WithMany(p => p.ServicePaymentInvoices)
                .HasForeignKey(d => d.DiscountsId)
                .HasConstraintName("FK__ServicePa__Disco__01142BA1");

            entity.HasOne(d => d.PaymentMethod).WithMany(p => p.ServicePaymentInvoices)
                .HasForeignKey(d => d.PaymentMethodId)
                .HasConstraintName("FK__ServicePa__Payme__7F2BE32F");

            entity.HasOne(d => d.PaymentServiceInvoiceStatus).WithMany(p => p.ServicePaymentInvoices)
                .HasForeignKey(d => d.PaymentServiceInvoiceStatusId)
                .HasConstraintName("FK__ServicePa__Payme__02084FDA");

            entity.HasOne(d => d.ServiceName).WithMany(p => p.ServicePaymentInvoices)
                .HasForeignKey(d => d.ServiceNameId)
                .HasConstraintName("FK__ServicePa__Servi__7E37BEF6");

            entity.HasOne(d => d.User).WithMany(p => p.ServicePaymentInvoices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ServicePa__UserI__7D439ABD");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__4BE666B4CBED5CD6");

            entity.ToTable("Supplier");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IdentificationCard)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TaskStatusEmployee>(entity =>
        {
            entity.HasKey(e => e.TaskStatusId).HasName("PK__TaskStat__C023DD6CD633A7F0");

            entity.ToTable("TaskStatusEmployee");

            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TaskStatus)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TasksEmployee>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__TasksEmp__7C6949B13073CC41");

            entity.ToTable("TasksEmployee");

            entity.Property(e => e.DueDate)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NameTask)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.TaskStatus).WithMany(p => p.TasksEmployees)
                .HasForeignKey(d => d.TaskStatusId)
                .HasConstraintName("FK__TasksEmpl__TaskS__6D0D32F4");

            entity.HasOne(d => d.User).WithMany(p => p.TasksEmployees)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__TasksEmpl__UserI__6C190EBB");
        });

        modelBuilder.Entity<TaxPercentage>(entity =>
        {
            entity.HasKey(e => e.PercentageId).HasName("PK__TaxPerce__ECBED0465D2C4CD1");

            entity.ToTable("TaxPercentage");

            entity.Property(e => e.PercentageTax).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Taxis>(entity =>
        {
            entity.HasKey(e => e.TaxId).HasName("PK__Taxes__711BE0AC5B738553");

            entity.Property(e => e.NetSalary)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TaxName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Percentage).WithMany(p => p.Taxes)
                .HasForeignKey(d => d.PercentageId)
                .HasConstraintName("FK__Taxes__Percentag__5812160E");

            entity.HasOne(d => d.Salary).WithMany(p => p.Taxes)
                .HasForeignKey(d => d.SalaryId)
                .HasConstraintName("FK__Taxes__SalaryId__59063A47");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C8BE2F1C3");

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
                .HasConstraintName("FK__UserInfo__Depart__4AB81AF0");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.JobTitleId)
                .HasConstraintName("FK__UserInfo__JobTit__49C3F6B7");

            entity.HasOne(d => d.Rol).WithMany(p => p.UserInfos)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__UserInfo__RolId__48CFD27E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

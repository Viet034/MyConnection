using ConnectMySql.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConnectMySql.DB;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ánh xạ Product với bảng Products trong MySQL  
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products"); // Tên bảng trong MySQL  
            entity.HasKey(p => p.ProductId); // Đặt Id là khóa chính  
            entity.Property(p => p.Name)
                .IsRequired() // Thực sự yêu cầu tên  
                .HasMaxLength(100); // Đặt giới hạn độ dài cho tên  

            entity.Property(p => p.Price)
                .HasColumnType("decimal(18,2)").IsRequired(); // Kiểu dữ liệu cho Price
                                                 // 
            entity.HasMany(od => od.OrderDetails).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
        });

        // Ánh xạ Customer với bảng Customers trong MySQL
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.ToTable("Customers"); //Tên bảng trong MySql
            entity.HasKey(c => c.CustomerId);
            entity.Property(c => c.FullName).IsRequired().HasMaxLength(100);
            entity.Property(c => c.Age).IsRequired().HasColumnType("int");
            entity.Property(c => c.Phone).IsRequired().HasMaxLength(10);
            entity.Property(c => c.Address).HasMaxLength(100);
            entity.HasMany(o => o.Orders).WithOne(c => c.Customer).HasForeignKey(c => c.CustomerId);
        });

        // Ánh xạ Employee với bảng Employees trong MySQL
        modelBuilder.Entity<Employee>(entity => 
        {
            entity.ToTable("Employees");
            entity.HasKey(e => e.EmployeeId);
            entity.Property(e => e.EmployeeName).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Dob).IsRequired().HasColumnType("datetime");
            entity.Property(e => e.Gender).IsRequired().HasMaxLength(10);
            entity.HasMany(o => o.Orders).WithOne(e => e.Employee).HasForeignKey(e => e.EmployeeId);
        });

        // Ánh xạ Order với bảng Orders trong MySQL
        modelBuilder.Entity<Order>(entity => 
        {
            entity.ToTable("Orders");
            entity.HasKey(o => o.OrderId);
            entity.Property(o => o.OrderDate).IsRequired().HasColumnType("datetime");
            entity.Property(o => o.ShipAddress).IsRequired().HasMaxLength(100);
            entity.Property(o => o.ShipCity).IsRequired().HasMaxLength(100);

            entity.Property(o => o.Status).IsRequired().HasMaxLength(50)
            .HasConversion(status => status.ToString(),
            value => (OrderStatus)Enum.Parse(typeof(OrderStatus), value));

            entity.HasOne(c => c.Customer).WithMany(o => o.Orders).HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Employee).WithMany(o => o.Orders).HasForeignKey(e => e.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasMany(od => od.OrderDetails).WithOne(o => o.Order).HasForeignKey(o => o.OrderId);
        });

        // Ánh xạ OrderDetail với bảng OrderDetails trong MySQL
        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("OrderDetails");
            entity.HasKey(od => od.OrdersDetailId);
            entity.Property(od => od.Quantity).IsRequired();
            entity.Property(od => od.Price).HasColumnType("decimal(18,2)");
            entity.HasOne(p => p.Product).WithMany(od => od.OrderDetails).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(o => o.Order).WithMany(od => od.OrderDetails).HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Restrict);
        });
    }
}

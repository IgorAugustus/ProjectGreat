using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class LeaveDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<ClassLeave> ClassLeaves { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server = ADMIN\SQLEXPRESS; database = ProjectDb; TrustServerCertificate=True; Integrated security = true");
            //.LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(u => u.StudentId);
            modelBuilder.Entity<LeaveType>().HasKey(u => u.LeaveId);
            modelBuilder.Entity<ClassLeave>().HasKey(u => u.ClassId);

            modelBuilder.Entity<Student>().Property(u => u.StudentName).HasMaxLength(100);
            modelBuilder.Entity<Student>().Property(u => u.Title).HasMaxLength(225);
            modelBuilder.Entity<Student>().Property(u => u.StudentName).IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.Title).IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.LeaveDate).IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.Reason).IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.ClassId).IsRequired();
            modelBuilder.Entity<Student>().Property(u => u.LeaveId).IsRequired();
            // modelBuilder.Entity<Student>().Property(u => u.Status).IsRequired();
            modelBuilder.Entity<Student>().HasOne(u => u.ClassLeave).WithMany
             (u => u.Students).HasForeignKey(u => u.ClassId);
            modelBuilder.Entity<Student>().HasOne(u => u.LeaveType).WithMany
             (u => u.Students).HasForeignKey(u => u.LeaveId);


            var classLeave = new ClassLeave[]
            {
                new ClassLeave{ClassId=1,Name="Class .NET01" },
                new ClassLeave{ClassId=2,Name="Class .NET02" },
                new ClassLeave{ClassId=3,Name="Class .JAVA01" },
                new ClassLeave{ClassId=4,Name="Class .JAVA02" }
      

            };

            modelBuilder.Entity<ClassLeave>().HasData(classLeave);

            var leaveType = new LeaveType[]
            {
                new LeaveType{LeaveId=1,LeaveName="Late Coming" },
                new LeaveType{LeaveId=2,LeaveName="Early Leave" },
                new LeaveType{LeaveId=3,LeaveName="Leave a haft of day" },
                new LeaveType{LeaveId=4,LeaveName="Leave one day" }


            };

            modelBuilder.Entity<LeaveType>().HasData(leaveType);


            var students = new Student[]
            {
                new Student{StudentId=1,StudentName="Phan Anh",Title="AAA",LeaveDate=new DateTime(2019,8,8),Reason="No way", Status="Nothing",ClassId=1,LeaveId=1 },
                new Student{StudentId=2,StudentName="La Tuan",Title="AAC",LeaveDate=new DateTime(2022,7,7),Reason="No way", Status="Nothing",ClassId=2,LeaveId=2 },
                new Student{StudentId=3,StudentName="Ton Nguyen",Title="BBB",LeaveDate=new DateTime(2023,3,11),Reason="No way", Status="Nothing",ClassId=3,LeaveId=2 },
                new Student{StudentId=4,StudentName="Luu Bi",Title="CCC",LeaveDate=new DateTime(2021,3,10),Reason="No way", Status="Nothing",ClassId=4,LeaveId=3 },
                new Student{StudentId=5,StudentName="Tao Thao",Title="DDD",LeaveDate=new DateTime(2020,5,12),Reason="No money", Status="Nothing",ClassId=1,LeaveId=4 },
                new Student{StudentId=6,StudentName="Bang Thong",Title="EEE",LeaveDate=new DateTime(2020,09,09),Reason="No time", Status="Nothing",ClassId=4,LeaveId=3 }
                


            };

            modelBuilder.Entity<Student>().HasData(students);
        }
    }
}

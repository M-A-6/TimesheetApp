using Microsoft.EntityFrameworkCore;
using System;
using timesheet.model;

namespace timesheet.data
{
    public class TimesheetDb : DbContext
    {
        public TimesheetDb(DbContextOptions<TimesheetDb> options)
            : base(options)
        {
        }
        public TimesheetDb() {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TimesheetLogs> TimesheetLog { get; set; }
        public DbSet<EmployeeTasks> EmployeeTask { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=MAK-PC\\MSSQL14;Database=TimesheetDb;Trusted_Connection=True;");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using timesheet.data;
using timesheet.model;
using Microsoft.EntityFrameworkCore;

namespace timesheet.business
{
    public class EmployeeService : IEmployeeService, IDb
    {
        public TimesheetDb db { get; }
        public EmployeeService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<Employee> GetEmployees()
        {
            return this.db.Employees;

        }
        public List<vmEmployeeTimeSheet> GetEmployeesWithEfforts()
        {


            var log = (from emp in this.db.Employees
                       join timesheet in this.db.TimesheetLog.FromSql("sp_EmployeeWeeklyEfforts {0}", DateTime.Now.ToString("yyyyMMdd")).ToList()
                       on emp.Id equals timesheet.EmployeeId                      
                       into timesheetLeftTable
                       from linetimesheetLeftTable in timesheetLeftTable.DefaultIfEmpty()
                       select new vmEmployeeTimeSheet
                       {

                           Id = emp.Id,
                           Name = emp.Name,
                           Code = emp.Code,
                           rowId = linetimesheetLeftTable.Id,
                           weeklyEffort = linetimesheetLeftTable.Effort
                       }).ToList<vmEmployeeTimeSheet>();
            return log.GroupBy(empId => empId.Name).Select(effort => new vmEmployeeTimeSheet
            {
                Id = effort.First().Id,
                Code = effort.First().Code,
                Name = effort.First().Name,
                weeklyEffort = effort.Sum(ef => ef.weeklyEffort),

            }).ToList();
        }
    }
}
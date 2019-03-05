using System;
using System.Collections.Generic;
using System.Linq;
using timesheet.data;
using timesheet.model;

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
            var log = (from empTask in this.db.EmployeeTask
                       join emp in this.db.Employees on empTask.EmployeeId equals emp.Id
                       join task in this.db.Tasks on empTask.TaskId equals task.Id
                       join timesheetLog in this.db.TimesheetLog on emp.Id equals timesheetLog.EmployeeId
                       into leftTimesheetTable
                       from lineLeftTimeesheet in leftTimesheetTable.DefaultIfEmpty()
                       where lineLeftTimeesheet.LogDate >= DateTime.Now && lineLeftTimeesheet.LogDate <= DateTime.Now.AddDays(7)
                             
                       select new vmEmployeeTimeSheet
                       {
                           Id = emp.Id,
                           Name = emp.Name,
                           Code = emp.Code,
                           weeklyEffort = lineLeftTimeesheet.Effort
                       }).ToList<vmEmployeeTimeSheet>();


            return log.GroupBy(empId => empId.Id).Select(effort => new vmEmployeeTimeSheet
            {
                Id = effort.First().Id,
                Code = effort.First().Code,
                Name = effort.First().Name,
                weeklyEffort = effort.Sum(ef => ef.weeklyEffort),

            }).ToList();


        }
    }

}
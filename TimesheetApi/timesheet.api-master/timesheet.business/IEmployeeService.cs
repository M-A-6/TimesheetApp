using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public interface IEmployeeService
    {        
        IQueryable<Employee> GetEmployees();
        List<vmEmployeeTimeSheet> GetEmployeesWithEfforts();
    }
}

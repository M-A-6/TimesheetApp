using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.model;

namespace timesheet.business
{
    public interface ITaskService
    {
        IQueryable<Task> GetTasks();
    }
}

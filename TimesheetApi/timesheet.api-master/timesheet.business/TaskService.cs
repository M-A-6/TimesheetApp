using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.data;
using timesheet.model;

namespace timesheet.business
{
    public class TaskService : ITaskService, IDb
    {
        public TimesheetDb db { get; }
        public TaskService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<Task> GetTasks()
        {
            return this.db.Tasks;
        }
    }
}

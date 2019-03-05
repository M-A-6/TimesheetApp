using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace timesheet.model
{
    [NotMapped]
    public class vwEmployeeWeeklyTasks
    {

        public int TaskId { get; set; }
        public string Name { get; set; }
        public List<TimesheetLogs> timesheetLog { get; set; }
      
    }


}

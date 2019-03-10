using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using timesheet.business;
using timesheet.model;

namespace timesheet.api.controllers
{
  [Route("api/v1/timesheetlog")]
    [ApiController]
    public class TimesheetLogController : ControllerBase
    {
        private readonly ITimesheetLogService timesheetService;
        public TimesheetLogController(ITimesheetLogService timesheetService)
        {
            this.timesheetService = timesheetService;
        }

        [HttpPost("getall")]
        public List<vwEmployeeWeeklyTasks> GetAll([FromBody] TimesheetLogs timesheetlog)
        {   
            var items = this.timesheetService.getTimesheetlogValues(timesheetlog.EmployeeId, timesheetlog.LogDate);
            return items;
        }

        // POST: api/Valid
        [HttpPost("savetimesheet")]
        public void Post([FromBody] List<vwEmployeeWeeklyTasks> timesheet)
        {
           this.timesheetService.saveTimesheetLog(timesheet);
        }
    }
}

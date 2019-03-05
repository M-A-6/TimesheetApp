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

        [HttpGet("getall/{employeeId}")]
        public List<vwEmployeeWeeklyTasks> GetAll(int employeeId)
        {
            
            var items = this.timesheetService.getTimesheetlogValues(employeeId,DateTime.Now);
            return items;
        }

        // POST: api/Valid
        [HttpPost("postreq")]
        public void Post([FromBody] List<vwEmployeeWeeklyTasks> timesheet)
        {

           this.timesheetService.saveTimesheetLog(timesheet);


        }
    }
}

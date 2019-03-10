using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using timesheet.data;
using timesheet.model;



namespace timesheet.business
{
    public class TimesheetLogService : ITimesheetLogService, IDb
    {
        public TimesheetDb db { get; set; }
        public TimesheetLogService(TimesheetDb dbContext)
        {
            this.db = dbContext;
        }

        public IQueryable<vwEmployeeWeeklyTasks> GetTimesheetLog()
        {
            return null;
        }

        //public List<vwEmployeeWeeklyTasks> getTimesheetlogValues(int employeeId, DateTime date)
        //{
        //    //var log = from timesheet in this.db.TimesheetLog.FromSql("sp_GetTimesheetLogWeekly {0},{1}", date.ToString("yyyyMMdd"), employeeId.ToString()).ToList()
        //    //          join task in this.db.Tasks on timesheet.TaskId equals task.Id
        //    //      select new
        //    //      {
        //    //          timesheet.TaskId,
        //    //          task.Name,
        //    //          timesheet.Id,
        //    //          timesheet.LogDate,
        //    //          timesheet.EmployeeId,
        //    //          timesheet.Effort                      
        //    //      };

        //    List<vwEmployeeWeeklyTasks> listimesheetLogs = new List<vwEmployeeWeeklyTasks>();
        //    foreach (var taskId in log.Select(taskid => taskid.TaskId).Distinct())
        //    {
        //        vwEmployeeWeeklyTasks emptask = new vwEmployeeWeeklyTasks();

        //        foreach (var timesheet in log.Where(tskid=>tskid.TaskId==taskId))
        //               { 

                        
        //                emptask.TaskId = timesheet.TaskId;
        //                emptask.Name = timesheet.Name;

        //            foreach (var sheet in timesheet.Where(tskid => tskid.TaskId == taskId))
        //            {
        //                List<TimesheetLogs> timeshetlog = new List<TimesheetLogs>();
        //                timeshe
        //             }
        //    }
        //}


        public int saveTimesheetLog(List<vwEmployeeWeeklyTasks> timesheet)
        {
            int retVal = 0;

            try
            {
                foreach (var task in timesheet)
                {
                    foreach (var timesheetRecord in task.timesheetLog)
                    {
                        if (timesheetRecord.Id == 0)
                        {
                            TimesheetLogs timesheetlog = new TimesheetLogs();
                            timesheetlog.LogDate = timesheetRecord.LogDate;
                            timesheetlog.TaskId = timesheetRecord.TaskId;
                            timesheetlog.Effort = timesheetRecord.Effort;
                            timesheetlog.EmployeeId = timesheetRecord.EmployeeId;
                            this.db.TimesheetLog.Add(timesheetlog);
                            this.db.SaveChanges();
                        }
                        else
                        {
                            this.db.TimesheetLog.Update(timesheetRecord);
                            this.db.SaveChanges();
                        }
                    }
                }
                
                
                retVal = 1;
            }
            catch (Exception ex)
            {
                retVal = 0;
            }

            return retVal;            
        }



        public List<vwEmployeeWeeklyTasks> getTimesheetlogValues(int employeeId, DateTime date)
        {
            List<vwEmployeeWeeklyTasks> listimesheetLogs = new List<vwEmployeeWeeklyTasks>();

            var tasks = (from empTask in this.db.EmployeeTask
                         join emp in this.db.Employees on empTask.EmployeeId equals emp.Id
                         join task in this.db.Tasks on empTask.TaskId equals task.Id
                         select task).Distinct();


            foreach (var task in tasks)
            {
                vwEmployeeWeeklyTasks emptask = new vwEmployeeWeeklyTasks();
                emptask.TaskId = task.Id;
                emptask.Name = task.Name;

                List<TimesheetLogs> timeshetlog = new List<TimesheetLogs>();
                timeshetlog.Add(getWeeklyTimeSheet(employeeId, task.Id, date));

                timeshetlog.Add(getWeeklyTimeSheet(employeeId, task.Id, date.AddDays(1)));
                timeshetlog.Add(getWeeklyTimeSheet(employeeId, task.Id, date.AddDays(2)));
                timeshetlog.Add(getWeeklyTimeSheet(employeeId, task.Id, date.AddDays(3)));
                timeshetlog.Add(getWeeklyTimeSheet(employeeId, task.Id, date.AddDays(4)));
                timeshetlog.Add(getWeeklyTimeSheet(employeeId, task.Id, date.AddDays(5)));
                timeshetlog.Add(getWeeklyTimeSheet(employeeId, task.Id, date.AddDays(6)));
                emptask.timesheetLog = timeshetlog;
                listimesheetLogs.Add(emptask);

            }




            return listimesheetLogs;
        }

        public TimesheetLogs getWeeklyTimeSheet(int employeeId, int taskId, DateTime date)
        {


            var log = (from empTask in this.db.EmployeeTask
                       join emp in this.db.Employees on empTask.EmployeeId equals emp.Id
                       join task in this.db.Tasks on empTask.TaskId equals task.Id
                       join timesheetLog in this.db.TimesheetLog on emp.Id equals timesheetLog.EmployeeId
                       into leftTimesheetTable
                       from lineLeftTimeesheet in leftTimesheetTable.DefaultIfEmpty()

                       where lineLeftTimeesheet.EmployeeId == employeeId && lineLeftTimeesheet.TaskId == task.Id
                       && emp.Id == employeeId && lineLeftTimeesheet.LogDate.ToString("dd.MM.yyyy") == date.ToString("dd.MM.yyyy")
                       && task.Id == taskId
                       select lineLeftTimeesheet).FirstOrDefault<TimesheetLogs>();

            if (log == null)
            {
                log = new TimesheetLogs();
                log.Id = 0;
                log.LogDate = Convert.ToDateTime(date.ToShortDateString());
                log.TaskId = taskId;
                log.Effort = 0;
                log.EmployeeId = employeeId;

            }
            return log;

        }

    }
}
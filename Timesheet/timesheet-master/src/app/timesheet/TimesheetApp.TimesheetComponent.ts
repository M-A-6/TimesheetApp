import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { TimesheetLogService } from '../services/timesheetlog.service';

@Component({
    templateUrl: 'TimesheetApp.TimesheetView.html',
    styleUrls:['../employee/employee.component.scss']
    //used employee scss file because, can use same css
    //use boot strap
})

export class TimeSheetComponent implements OnInit {
   
    selectedEmployeeID:string;
    selectedDate:Date;
    employees: any;
    firstRecord:any;
    tasks:any;    
    showtable:boolean;

    

    constructor(private employeeService: EmployeeService,private  timesheetlog:TimesheetLogService) { }

    ngOnInit() {
        
        this.employeeService.getallemployees().subscribe(data => {
            this.employees = data;
        });
        //this.timesheetlog.getallTimesheetLogs(0).subscribe(data => {
        //    this.tasks = data;
        //});
        this.showtable=false;
        this.selectedDate = new Date();
    }
    selectChangeHandler (event: any)
    {
        this.selectedEmployeeID= event.target.value;
        if(this.selectedEmployeeID!="0")
          this.showtable=true;
        else
          this.showtable=false;

         this.loadTimesheetLog(this.selectedEmployeeID);
    }

    loadTimesheetLog(slectedVal:string)
    {
        this.tasks= null;
        var timesheetlogFor:any={};
        timesheetlogFor.EmployeeId =this.selectedEmployeeID;
        timesheetlogFor.LogDate = this.selectedDate;
        timesheetlogFor.Id=0;
        timesheetlogFor.TaskId=0;
        timesheetlogFor.Effort=0;

        this.timesheetlog.getallTimesheetLogs(timesheetlogFor).subscribe(data => {
            this.tasks = data;
            this.firstRecord= this.tasks[0].timesheetLog;
        });
    }
    SaveTimesheet()
    {
        this.timesheetlog.saveTimesheetLogs(this.tasks).subscribe(res=>this.Success(res),
        res=>this.Error(res));
    }
    Error(res) {
        console.debug(res);
      }
      Success(res) {
        console.debug(res);
      }

      getSum(dayVal)
      {       
        let sum=0;
        for (let task of this.tasks)
        {
          for(let log of task.timesheetLog)
          {
              if(log.logDate==dayVal)
              {
                sum= Number(log.effort)+ Number(sum);
              }
          }
        }
        return sum;
      } 

      setNextWeek()
      {
       this.selectedDate.setDate( this.selectedDate.getDate() + 7 );
       this.loadTimesheetLog(this.selectedEmployeeID);
      }
      setPreviousWeek()
      {
        this.selectedDate.setDate( this.selectedDate.getDate() - 7 );
        this.loadTimesheetLog(this.selectedEmployeeID);
      }
      getNextWeek()
      {
          var nextweekDate:Date;
          nextweekDate=new Date(); 
          nextweekDate.setDate(this.selectedDate.getDate() + 6 );
          return nextweekDate;
      }
      getCurrentWeekDate()
      {
        var currentDate:Date;
        currentDate=new Date(); 
        currentDate.setDate(this.selectedDate.getDate() );
        
        return currentDate;
      }
}
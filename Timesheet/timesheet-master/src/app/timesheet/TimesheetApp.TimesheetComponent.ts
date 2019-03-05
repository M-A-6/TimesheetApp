import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { TaskService } from '../services/task.service';
import { TimesheetLogService } from '../services/timesheetlog.service';
import { DatePipe } from '@angular/common';




@Component({
    
    templateUrl: 'TimesheetApp.TimesheetView.html',
    styleUrls:['./TimesheetApp.TimesheetStyle.scss']
    
})




export class TimeSheetComponent implements OnInit {
   
    selectedVal:string;
    employees: any;
    firstRecord:any;
    tasks:any;
    recordVal:any;
    dateFilter:any;
    showtable:boolean;
    //TotalRecord: Array<DaysTotal> = new Array<DaysTotal>();
    //pipe = new DatePipe('EEEE');
  
    constructor(private employeeService: EmployeeService,private  timesheetlog:TimesheetLogService) { }

    ngOnInit() {
        this.employeeService.getallemployees().subscribe(data => {
            this.employees = data;
        });
        this.timesheetlog.getallTimesheetLogs(0).subscribe(data => {
            this.tasks = data;
        });
        this.showtable=false;
     //   this.TotalRecord.push(new DaysTotal(1,0));
      //  this.TotalRecord.push(new DaysTotal(2,0));
      //  this.TotalRecord.push(new DaysTotal(3,0));
      //  this.TotalRecord.push(new DaysTotal(4,0));
     //   this.TotalRecord.push(new DaysTotal(5,0));
      //  this.TotalRecord.push(new DaysTotal(6,0));
      //  this.TotalRecord.push(new DaysTotal(7,0));
    }
    selectChangeHandler (event: any)
    {
        this.selectedVal= event.target.value;
        if(this.selectedVal!="0")
          this.showtable=true;
          else
          this.showtable=false;

         this.loadTimesheetLog(this.selectedVal);
    }

    loadTimesheetLog(slectedVal:string)
    {
        this.timesheetlog.getallTimesheetLogs(slectedVal).subscribe(data => {
            this.tasks = data;
            this.firstRecord= this.tasks[0].timesheetLog;
        });
    }
    SaveTimesheet()
    {
        
 
    
    this.timesheetlog.saveTimesheetLogs(this.tasks).subscribe(res=>this.Success(res),
    res=>this.Error(res));

    //this.loadTimesheetLog(this.selectedVal);
   
    }

    Error(res) {
        console.debug(res);

    
      }
      Success(res) {
        console.debug(res);
      }

      getSum(dayVal)
      {
       
        // working on calcution(need to fix)
        this.recordVal = this.tasks.map(timesheet=>timesheet.timesheetLog);
        this.dateFilter = this.recordVal.filter(day=>{
         return day.logDate == dayVal ;
        } );
    
            
        

    
        return '';
      }
 
}
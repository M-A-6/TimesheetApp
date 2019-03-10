import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';


@Component({
    
    templateUrl: 'employee.component.html',
    styleUrls:['./employee.component.scss']
})

export class EmployeeListComponent implements OnInit {    
    employees: any;
    constructor(private employeeService: EmployeeService) { }
    
    ngOnInit() {
     
        this.employeeService.getallemployeesWithEffort().subscribe(data => {
            this.employees = data;
        });        
    }    
    getCurrentWeek()
    {
      var currentDate=new Date();

      return currentDate;
    }
    addDays(day:number)
    {
        var newDate:Date;
        newDate=new Date(); 
        newDate.setDate((new Date()).getDate() + day );
      return newDate;
    }

}
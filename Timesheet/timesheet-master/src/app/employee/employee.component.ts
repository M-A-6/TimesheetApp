import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';


@Component({
    
    templateUrl: 'employee.component.html',
    styleUrls:['./employee.component.scss']
})

export class EmployeeListComponent implements OnInit {
    //EmployeeModel:Employee = new Employee();
    employees: any;
    constructor(private employeeService: EmployeeService) { }

    ngOnInit() {
        this.employeeService.getallemployeesWithEffort().subscribe(data => {
            this.employees = data;
        });
    }
}
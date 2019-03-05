import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core'; 
import {RouterModule} from '@angular/router';
import {MasterPageComponent} from './home/TimesheetApp.MasterPageComponent';
import {HomeComponent} from './home/TimesheetApp.HomeComponent';
import {TimeSheetComponent} from './timesheet/TimesheetApp.TimesheetComponent';
import {MainRoutes} from './routing/TimesheetApp.MainRouting';

import {FormsModule} from '@angular/forms';
import {  HttpClientModule } from '@angular/common/http';
import { EmployeeListComponent } from './employee/employee.component';
import { EmployeeService } from './services/employee.service';
import { TaskService } from './services/task.service';
import { TimesheetLogService } from './services/timesheetlog.service';

@NgModule({
  declarations: [
    MasterPageComponent ,HomeComponent ,
    EmployeeListComponent,TimeSheetComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(MainRoutes),
    FormsModule ,HttpClientModule
  ],
  providers: [EmployeeService,TaskService,TimesheetLogService],
  bootstrap: [MasterPageComponent]
})
export class MainModule { }
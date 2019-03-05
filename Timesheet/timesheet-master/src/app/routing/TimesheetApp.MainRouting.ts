import { HomeComponent } from '../home/TimesheetApp.HomeComponent';
import { EmployeeListComponent } from '../employee/employee.component';
import { TimeSheetComponent } from '../timesheet/TimesheetApp.TimesheetComponent';
//import { EmployeeTaskComponent } from '../task/TimesheetApp.EmployeeTaskComponent';

export const MainRoutes =[
{path: 'Home', component: HomeComponent},
{ path: 'Employee', component:EmployeeListComponent },
{ path: 'Timesheet', component:TimeSheetComponent },
//{ path: 'Tasks', component:EmployeeTaskComponent },

{path: '', component: HomeComponent}
];
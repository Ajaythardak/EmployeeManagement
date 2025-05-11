import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesListComponent } from './employees-list/employees-list.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { AppComponent } from './app.component';

const routes: Routes = [
  // { path: '/', component: AppComponent},
  { path: '', component: EmployeesListComponent },
  { path: 'employee-list', component: EmployeesListComponent },
  { path: 'add-employee', component: AddEmployeeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

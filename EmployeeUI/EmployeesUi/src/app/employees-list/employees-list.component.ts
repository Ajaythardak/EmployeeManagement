import { Component } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
import { MatDialog } from '@angular/material/dialog';
import { EditEmployeeComponent } from '../edit-employee/edit-employee.component';

@Component({
  selector: 'app-employees-list',
  standalone: false,
  templateUrl: './employees-list.component.html',
  styleUrl: './employees-list.component.css'
})
export class EmployeesListComponent {

  employees: any;
  employeesData: any;
  popup: boolean = false;
  constructor(private employeeService: EmployeeService, public dialog: MatDialog) { }

  ngOnInit() { }

  getEmployees() {

    if (this.employeesData == null) {

      console.log("employees fetched.");
      this.employeeService.getEmployees().subscribe(data => {
        console.log(data)
        this.employeesData = data;
        this.employees = this.employeesData;
      });
    }
    else if (this.employees == null) {
      console.log("employees assigned.");
      this.employees = this.employeesData;
    }
    else console.log("employees data already fetched.");

  }

  clearEmployees() {
    console.log("employees cleared.");
    this.employees = null;
  }

  editEmployees(id: any) {
    this.popup =true;
    const dialogRef = this.dialog.open(EditEmployeeComponent, {
      width: '450px',
      // data: {name: this.name, animal: this.animal}
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      // this.animal = result;
    });
}
}

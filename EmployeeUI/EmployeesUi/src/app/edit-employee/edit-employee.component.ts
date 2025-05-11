import { Component, input } from '@angular/core';
import { Employee } from '../Models/Employee';
import { EmployeeService } from '../services/employee.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-edit-employee',
  standalone: false,
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.css'
})


export class EditEmployeeComponent {
  
  employee: Employee = {
    name: '',
    emailId: '',
    address: '',
    phoneNumber: ''
  };

  constructor(private employeeService: EmployeeService, private router: Router) { }

  onSubmit(form: NgForm) {
    console.log(this.employee);
    
    if (form.valid) {
      this.employeeService.editEmployee(this.employee).subscribe({
        next: (response) => {
          console.log('Employee saved:', response);
          this.router.navigateByUrl('/employee-list');
        },
        error: (err) => {
          console.error('Error saving employee:', err);
        }
      });
    }
  }

}

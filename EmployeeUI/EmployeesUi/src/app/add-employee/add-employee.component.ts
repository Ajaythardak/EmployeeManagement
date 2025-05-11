import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Employee } from '../Models/Employee';
import { EmployeeService } from '../services/employee.service';
import { RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  standalone: false,
  templateUrl: './add-employee.component.html',
  styleUrl: './add-employee.component.css'
})
export class AddEmployeeComponent {
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
      this.employeeService.saveEmployee(this.employee).subscribe({
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

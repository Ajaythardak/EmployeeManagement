import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../Models/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private apiUrl = 'https://localhost:7149/Employee';

  constructor(private http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.apiUrl);
  }

  saveEmployee(employee: Employee): Observable<Employee> {
    // return this.http.post<Employee>(this.apiUrl, employee);
    
    const headers = { 'Content-Type': 'application/json' };
    return this.http.post<Employee>(this.apiUrl, employee, { headers });
  }

  editEmployee(employee: Employee): Observable<Employee> {
    // return this.http.post<Employee>(this.apiUrl, employee);
    
    const headers = { 'Content-Type': 'application/json' };
    return this.http.put<Employee>(this.apiUrl, employee, { headers });
  }
}

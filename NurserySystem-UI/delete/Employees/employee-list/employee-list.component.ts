import { Component } from '@angular/core';
import { Employee } from '../../models/employee.model'; 
import { EmployeeService } from '../../services/employee.service';
import { OnInit } from '@angular/core';
@Component({
  selector: 'app-employee-list',
  standalone: false,
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent implements OnInit {
  title = "Nursery Employees";
  constructor(private employeeService:EmployeeService){}
  employees: Employee[]=[];
  isLoading = true;
  errorMessage='';


  ngOnInit():void{
    this.employeeService.getEmployees().subscribe({
      next:(data)=>{
     // console.log("API Response:",data);
      this.employees=data;
      this.isLoading=false;
      },
      error:(error)=>{
        console.error(error);
        this.errorMessage='Faild to load employees.';
        this.isLoading=false;
      }
    });
  }
}

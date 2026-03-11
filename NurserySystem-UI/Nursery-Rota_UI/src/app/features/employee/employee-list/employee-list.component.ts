import { Component } from '@angular/core';
import { AfterViewInit,Component,ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { EmployeeService } from '../../../services/employee.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-employee-list',
  standalone: false,
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent implements AfterViewInit{
  displayedColumns:string[] = ['id','name','email','status'];
  dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator) paginator!:MatPaginator;
  @ViewChild(MatSort) sort!:MatSort;
  
  constructor(private employeeService:EmployeeService){}
 ngAfterViewInit(){
   this.employeeService.getEmployees().subscribe(data=>{
    this.dataSource.data=data;
    this.dataSource.paginator=this.paginator;
    this.dataSource.sort = this.sort;
   });
 }
 applyFilter(event:Event){
  const filerValue=(event.target as HTMLInputElement).value;
  this.dataSource.filter = filerValue.trim().toLowerCase();
 }

}

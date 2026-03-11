import { Component,OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import{MatFormFieldModule} from '@angular/material/form-field';
import{MatInputModule} from '@angular/material/input';
import{ MatSortModule, MatSort, MatSortHeader } from '@angular/material/sort';
import{MatPaginatorModule} from '@angular/material/paginator';
import { ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialog,MatDialogModule } from '@angular/material/dialog';
import { AddEmployeeComponent } from '../add-employee/add-employee.component';
@Component({
  selector: 'app-employee-list',
   standalone: true,
  imports: [
    CommonModule,
  MatTableModule,
  MatCardModule,
  MatProgressSpinnerModule,
  HttpClientModule,
  MatIconModule,
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatSortModule,
  MatPaginatorModule,
  MatTooltipModule,
  MatDialogModule//,
  //AddEmployeeComponent
],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.css'
})
export class EmployeeListComponent  implements OnInit, AfterViewInit {
/*employees:any[] = [];*/
dataSource = new MatTableDataSource<any>();
@ViewChild(MatSort) sort!: MatSort;
@ViewChild(MatPaginator) paginator!: MatPaginator;
displayedColumns:string[] = ['id','name','email','phone','status','actions'];
isLoading=true;
errorMessage='';

constructor(private http:HttpClient,private dialog: MatDialog){}
ngOnInit(): void {
  this.loadEmployees();
}

loadEmployees(){
  this.http.get<any[]>('https://localhost:7263/employee')
  .subscribe({
    next:(res)=>{
      this.dataSource.data=res;
      this.isLoading=false;
    },
    error:(err)=>{
      this.errorMessage='Failed to load employees';
      this.isLoading=false;
    }
  });
}
get totalEmployees(): number {
  return this.dataSource.data.length;
}
get activeEmployees(): number {
  return this.dataSource.data.filter(emp => emp.empStatus).length;
}

get inactiveEmployees(): number {
  return this.dataSource.data.filter(emp => !emp.empStatus).length;
}
applyFilter(event: Event) {
  const filterValue = (event.target as HTMLInputElement).value;
  this.dataSource.filter = filterValue.trim().toLowerCase();
}

ngAfterViewInit() {
  this.dataSource.sort = this.sort;
  this.dataSource.paginator = this.paginator;
}

editEmployee(employee: any) {
  const dialogRef = this.dialog.open(AddEmployeeComponent,{
    width:'500px',
    data:employee //send employee to dialog
  });

  dialogRef.afterClosed().subscribe(result=>{
    if(result){
      this.updateEmployee(employee.id,result);
    }
  });
}

openAddEmployee(){
  const dialogRef=this.dialog.open(AddEmployeeComponent,{
    width:'500px'
  });

  dialogRef.afterClosed().subscribe(result=>{
    if(result){
      this.saveEmployee(result);
    }
  });
}

saveEmployee(employee:any){

  if(employee.DOB){
    employee.DOB=new Date(employee.dob).toISOString();
  }
  
  this.http.post(`https://localhost:7263/employee`,employee)
  .subscribe({
    next:()=>{
      this.loadEmployees();
    },
    error:()=>{
      alert('Faild to save employee');
    }
  });
}

updateEmployee(id:number,employee:any){
  if(employee.dob){
    employee.dob = new Date(employee.dob).toISOString();
  }

  this.http.put(`https://localhost:7263/employee/${id}`,employee)
  .subscribe({
    next:()=>{
      this.loadEmployees();
    },
    error:()=>{
      alert('Failed to update employee');
    }
  });
}

}

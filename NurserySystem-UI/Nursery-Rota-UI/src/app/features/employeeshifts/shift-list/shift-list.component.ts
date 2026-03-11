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
import { AddShiftComponent } from '../add-shift/add-shift.component';
import { forkJoin } from 'rxjs';
import { WeekDay } from '../../weekday.enum';
@Component({
  selector: 'app-shift-list',
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
  MatDialogModule
  ],
  templateUrl: './shift-list.component.html',
  styleUrl: './shift-list.component.css'
})
export class ShiftListComponent implements OnInit, AfterViewInit {
dataSource = new MatTableDataSource<any>();
@ViewChild(MatSort) sort!: MatSort;
@ViewChild(MatPaginator) paginator!: MatPaginator;
displayedColumns:string[] = ['id','empId','employeeName','workingDay','workShift','shiftStatus','actions'];
isLoading=true;
errorMessage='';


constructor(private http:HttpClient,private dialog: MatDialog){}
ngOnInit(): void {
  this.loadShiftWithEmployees();
}

getDayName(dayNumber:number):string{
  return WeekDay[dayNumber];
}

loadShiftWithEmployees(){
 forkJoin({
  employees: this.http.get<any[]>('https://localhost:7263/employee'),
  shifts:this.http.get<any[]>('https://localhost:7263/EmpShiftDetails')
 }).subscribe(
  result=> {
    const employees = result.employees;
    const shifts = result.shifts;

    this.dataSource.data = shifts.map(shift=>{
      const employee = employees.find(e=>e.id===shift.empId);

      return{
        id:shift.id,
        empId:shift.empId,
        workingDay:WeekDay[shift.workingDay],
        workShift:shift.workShift,
        shiftStatus:shift.shiftStatus,
        employeeName:employee?employee.firstName+" "+employee.surname:'Unknown'
      };
    });
  });
}
/*loadEmployeesShifts(){
  this.http.get<any[]>('https://localhost:7263/EmpShiftDetails')
  .subscribe({
    next:(res)=>{
      this.dataSource.data=res;
      this.isLoading=false;
    },
    error:(err)=>{
      this.errorMessage='Failed to load employees shifts';
      this.isLoading=false;
    }
  });
}*/
/*get totalEmployees(): number {
  return this.dataSource.data.length;
}
get activeEmployees(): number {
  return this.dataSource.data.filter(emp => emp.empStatus).length;
}

get inactiveEmployees(): number {
  return this.dataSource.data.filter(emp => !emp.empStatus).length;
} */
applyFilter(event: Event) {
  const filterValue = (event.target as HTMLInputElement).value;
  this.dataSource.filter = filterValue.trim().toLowerCase();
}

ngAfterViewInit() {
  this.dataSource.sort = this.sort;
  this.dataSource.paginator = this.paginator;
}

editEmployeeShift(employeeshift: any) {
  const dialogRef = this.dialog.open(AddShiftComponent,{
    width:'500px',
    data:employeeshift //send employee to dialog
  });

  dialogRef.afterClosed().subscribe(result=>{
    if(result){
      this.updateEmployeeShift(employeeshift.id,result);
    }
  });
}

openAddEmployeeShift(){
  const dialogRef=this.dialog.open(AddShiftComponent,{
    width:'500px'
  });

  dialogRef.afterClosed().subscribe(result=>{
    if(result){
      this.saveEmployeeshift(result);
    }
  });
}

saveEmployeeshift(employeeshift:any){

   
  this.http.post(`https://localhost:7263/EmpShiftDetails`,employeeshift)
  .subscribe({
    next:()=>{
      this.loadShiftWithEmployees();
    },
    error:()=>{
      alert('Faild to save employee shift');
    }
  });
}

updateEmployeeShift(id:number,employeeshift:any){
 

  this.http.put(`https://localhost:7263/employee/${id}`,employeeshift)
  .subscribe({
    next:()=>{
      this.loadShiftWithEmployees();
    },
    error:()=>{
      alert('Failed to update employee shift');
    }
  });
}
}

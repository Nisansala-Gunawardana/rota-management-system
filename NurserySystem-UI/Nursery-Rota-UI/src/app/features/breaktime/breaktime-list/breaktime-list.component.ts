import { Component,OnInit,viewChild } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpClientModule,HttpClient } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule,MatSort,MatSortHeader } from '@angular/material/sort';
import { MatPaginatorModule,MatPaginator } from '@angular/material/paginator';
import { ViewChild,AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule,MatDialog } from '@angular/material/dialog';
import { CommonModule} from '@angular/common';
import { MatIconModule } from "@angular/material/icon";
import { AddBreaktimeComponent } from '../add-breaktime/add-breaktime.component';

@Component({
  selector: 'app-breaktime-list',
  imports: [
     CommonModule,
    MatCardModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSortModule,
    MatPaginatorModule,
    MatTooltipModule,
    MatDialogModule,
    HttpClientModule
  ],
  templateUrl: './breaktime-list.component.html',
  styleUrl: './breaktime-list.component.css'
})
export class BreaktimeListComponent implements OnInit,AfterViewInit {
  dataSource=new MatTableDataSource<any>();
  @ViewChild(MatSort) sort!:MatSort;
  @ViewChild(MatPaginator) paginator!:MatPaginator;
  displayedColumns:string[]=['id','durationMinutes','isActive','actions'];
  isLoading=true;
  errorMessage='';

  constructor(
    private http:HttpClient,
    private dialog:MatDialog
  ){}

  ngOnInit(): void {
    this.loadBreaks();
  }

  loadBreaks(){
    this.http.get<any[]>(`https://localhost:7263/breakTime`)
    .subscribe({
      next:(res)=>{
        this.dataSource.data=res;
        this.isLoading=false;
      },
      error:(err)=>{
        alert("Faild to load BreakTimes");
        this.isLoading=false;
      }
    });
  }

  applyFilter(event:Event){
    const filerValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter=filerValue.trim().toLocaleLowerCase();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort=this.sort;
    this.dataSource.paginator=this.paginator;
  }

  editBreak(breakTime:any){
    const dialogRef = this.dialog.open(AddBreaktimeComponent,{
      width:'500px',
      data:breakTime
    });

    dialogRef.afterClosed().subscribe((result)=>{
        if(result){
          this.updateBreak(breakTime.id,result);
        }
      });
  }

  openAddBreak(){
    const dialogRef=this.dialog.open(AddBreaktimeComponent,{
      width:'500px'
    });

    dialogRef.afterClosed().subscribe((result)=>{
      if(result){
        this.saveBreak(result);
      }
    });
  }
 
   saveBreak(breakTime:any){
    this.http.post(`https://localhost:7263/breakTime`,breakTime)
    .subscribe({
      next:()=>{
        this.loadBreaks();
      },
      error:()=>{
        alert('Faild to save BreakTime');
      }
    });
   }

   updateBreak(id:number,breakTime:any){
    this.http.put(`https://localhost:7263/breaktime/${id}`,breakTime)
    .subscribe({
      next:()=>{
        this.loadBreaks();
      },
      error:()=>{
        alert('Faild to update BreakTime');
      }
    });
   }


}

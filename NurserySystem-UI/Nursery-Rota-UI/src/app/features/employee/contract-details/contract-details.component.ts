import { Component,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatSortHeader } from "@angular/material/sort";
import { MatCellDef, MatTableDataSource } from "@angular/material/table";
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpClientModule,HttpClient } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule ,MatSort} from '@angular/material/sort';
import { MatPaginatorModule,MatPaginator } from '@angular/material/paginator';
import { ViewChild,AfterViewInit } from '@angular/core';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule,MatDialog } from '@angular/material/dialog';
import { AddContractComponent } from '../add-contract/add-contract.component';
@Component({
  selector: 'app-contract-details',
  imports: [
    CommonModule,
    MatIconModule,
    MatSortHeader,
    MatCellDef,
    MatTableModule,
    MatProgressSpinnerModule,
    HttpClientModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSortModule,
    MatPaginatorModule,
    MatPaginator,
    MatTooltipModule,
    MatDialogModule
    

],
  templateUrl: './contract-details.component.html',
  styleUrl: './contract-details.component.css'
})
export class ContractDetailsComponent implements OnInit,AfterViewInit {

  dataSource = new MatTableDataSource<any>();
  @ViewChild(MatSort) sort!:MatSort;
  @ViewChild(MatPaginator) paginator!:MatPaginator;
  displayedColumns:string[] = ['id','empId','employeName','contractType','contractHours','cStatus','actions'];
  isLoading=true;
  errorMessage='';

constructor(private http:HttpClient,private dialog:MatDialog){}

ngOnInit(): void {
  this.loadContracts();
}

loadContracts(){
  this.http.get<any[]>('https://localhost:7263/contract')
  .subscribe({
    next:(res)=>{
      this.dataSource.data=res;
      this.isLoading=false;
    },
    error:(err)=>{
      this.errorMessage='Failed to load Contracts';
      this.isLoading=false;
    }
  });
}

  applyFilter(event:Event){
    const filterValue=(event.target as HTMLInputElement).value;
    this.dataSource.filter=filterValue.trim().toLowerCase();

  }

  ngAfterViewInit() {
    this.dataSource.sort=this.sort;
    this.dataSource.paginator=this.paginator;
  }
  openAddContract(){
   const dialogRef=this.dialog.open(AddContractComponent,{
      width:'500px'
    });

    dialogRef.afterClosed().subscribe(result=>{
      if(result){
        this.saveContract(result);
      }
    });
  }

editContract(contract:any){
const dialogRef=this.dialog.open(AddContractComponent,{
  width:'500px',
  data:contract
});

dialogRef.afterClosed().subscribe(result=>{
  if(result){
    this.updateContract(contract.id,result);
  }
});
}

  saveContract(contract:any){
    if(contract.sdate){
      contract.sdate = new Date(contract.sdate).toISOString();
    }
    if(contract.edate){
      contract.edate = new Date(contract.edate).toISOString();
    }

    this.http.post(`https://localhost:7263/contract`,contract)
    .subscribe({
      next:()=>{
        this.loadContracts();
      },
      error:()=>{
        alert('Faild to save contract');
      }
    });
  }

  updateContract(id:number,contract:any){
    if(contract.sdate){
      contract.sdate = new Date(contract.sdate).toISOString();
    }

    if(contract.edate){
      contract.edate = new Date(contract.edate).toISOString();
    }

    this.http.put(`https://localhost:7263/contract/${id}`,contract)
    .subscribe({
      next:()=>{
        this.loadContracts();
      },
      error:()=>{
        alert('Faild to update contract')
      }
    });
  }
}

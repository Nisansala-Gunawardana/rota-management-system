import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
//import { DashboardComponent } from './layout/dashboard/dashboard.component';
//import { EmployeeListComponent } from './Employees/employee-list/employee-list.component';
//import { DashboardHomeComponent } from './dashboard/dashboard-home/dashboard-home.component';
const routes: Routes = [
  {
    path:'',
    component:DashboardComponent,
    children:[
       { path:'',component:DashboardHomeComponent},
      {path:'employees',component:EmployeeListComponent}
     
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

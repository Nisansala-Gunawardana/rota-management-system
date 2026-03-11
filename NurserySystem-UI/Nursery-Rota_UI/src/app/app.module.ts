import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import{MatSidenavModule} from '@angular/material/sidenav';
import{MatIconModule} from '@angular/material/icon';
import{MatTableModule} from '@angular/material/table';
import{MatListModule} from '@angular/material/list';
import{MatPaginatorModule}from '@angular/material/paginator';
import{MatSortModule} from '@angular/material/sort';
import{MatCardModule} from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import{MatInputModule} from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//import { EmployeeListComponent } from './Employees/employee-list/employee-list.component';
import { HttpClientModule } from '@angular/common/http';
//import { DashboardComponent } from './layout/dashboard/dashboard.component';
//import { DashboardHomeComponent } from './dashboard/dashboard-home/dashboard-home.component';
//import { DashboardLayoutComponent } from './core/layout/dashboard-layout/dashboard-layout.component';
//import { SidebarComponent } from './core/layout/sidebar/sidebar.component';
//import { HeaderComponent } from './core/layout/header/header.component';
@NgModule({
  declarations: [
    AppComponent,
   // EmployeeListComponent,
  //  DashboardComponent,
  //  DashboardHomeComponent,
 //   DashboardLayoutComponent,
 //   SidebarComponent,
 //   HeaderComponent
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    MatToolbarModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatCardModule,
    MatButtonModule,
    MatInputModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

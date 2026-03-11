import { Component,Input } from '@angular/core';
import{MatListModule} from '@angular/material/list';
import{MatIconModule} from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import{MatExpansionModule} from '@angular/material/expansion';
import { MatFormFieldModule } from "@angular/material/form-field";
import { Router } from '@angular/router';
@Component({
  selector: 'app-sidebar',
  standalone:true,
  imports: [MatListModule, MatIconModule, RouterModule, CommonModule, MatExpansionModule, MatFormFieldModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
 @Input() isExpanded:boolean = true;
 isEmployeeMenuOpen=false;
 isConfigMenuOpen=false;
  constructor(private router: Router) {}

 ngOnInit(){
  if(this.router.url.includes('/employees')){
    this.isEmployeeMenuOpen=true;
  }

  if(this.router.url.includes('/rooms'))
  {
    this.isConfigMenuOpen=true;
  }
 }

 toggleEmployeeMenu() {
  this.isEmployeeMenuOpen = !this.isEmployeeMenuOpen;
  
}
toggleConfigMenu(){
  this.isConfigMenuOpen=!this.isConfigMenuOpen;
}
}

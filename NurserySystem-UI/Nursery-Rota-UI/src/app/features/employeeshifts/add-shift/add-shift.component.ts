import { Component, inject, Inject,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
//import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule,FormBuilder,FormGroup,Validators } from '@angular/forms';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import{MatSlideToggleModule} from '@angular/material/slide-toggle';

@Component({
  selector: 'app-add-shift',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSlideToggleModule
  ],
  templateUrl: './add-shift.component.html',
  styleUrl: './add-shift.component.css'
})
export class AddShiftComponent implements OnInit{
shiftForm!:FormGroup;
isEditMode=false;

   constructor(
    private fb:FormBuilder,
    private dialogRef:MatDialogRef<AddShiftComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any
   ){}

   ngOnInit(): void {
     this.shiftForm = this.fb.group({
      id:[{value:'',disabled:true}], //disabled field read only
      firstName:['',Validators.required],
      surname:['',Validators.required],
      address:[''],
      dob:['',Validators.required],
      email:['',[Validators.required,Validators.email]],
      phone:['',[Validators.required,Validators.minLength(10)]],
      empStatus:[true]
     });

     //if edit mode (data exists)
     

     if(this.data){
      this.isEditMode=true;
      this.shiftForm.patchValue(this.data);
     }
   }

   save() {
  if(this.shiftForm.valid){
    const formData = this.shiftForm.getRawValue(); //include disable fields
    this.dialogRef.close(formData);
  }
    
  }

  cancel() {
    this.dialogRef.close();
  }

  //cleaner access in HTML
  get f(){
    return this.shiftForm.controls;
  }

}

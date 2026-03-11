import { Component,Inject,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from "@angular/material/dialog";
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule,FormBuilder,FormGroup,Validators } from '@angular/forms';
import { MatNativeDateModule, NativeDateModule } from '@angular/material/core';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';

@Component({
  selector: 'app-add-room',
  imports: [
    MatDialogModule,
    CommonModule,
    ReactiveFormsModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatNativeDateModule,
    MatSlideToggleModule
  ],
  templateUrl: './add-room.component.html',
  styleUrl: './add-room.component.css'
})
export class AddRoomComponent implements OnInit{
  roomForm!:FormGroup;
  isEditMode=false;

  constructor(
    private fb:FormBuilder,
    private dialogRef:MatDialogRef<AddRoomComponent>,
    @Inject(MAT_DIALOG_DATA) public data:any
  ){}

  ngOnInit(): void {
    this.roomForm = this.fb.group({
      id:[{value:'',disabled:true}],
      roomCode:['',Validators.required],
      isActive:[true]
    });

    if(this.data){
      this.isEditMode=true;
      this.roomForm.patchValue(this.data);
    }
  }

  save(){
    if(this.roomForm.valid){
      const formData = this.roomForm.getRawValue();
      this.dialogRef.close(formData);
    }
  }

  cancel(){
    this.dialogRef.close();
  }

  get f(){
    return this.roomForm.controls;
  }
}

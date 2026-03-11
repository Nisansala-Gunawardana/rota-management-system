import { Component, OnInit, viewChild } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpClient,HttpClientModule } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule, MatSort, MatSortHeader } from '@angular/material/sort';
import { MatPaginatorModule, MatPaginator } from '@angular/material/paginator';
import { ViewChild, AfterViewInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatDialogModule, MatDialog } from '@angular/material/dialog';
import { AddRoomComponent } from '../add-room/add-room.component';

@Component({
  selector: 'app-room-list',
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
  templateUrl: './room-list.component.html',
  styleUrl: './room-list.component.css',
})
export class RoomListComponent implements OnInit, AfterViewInit {
  dataSource = new MatTableDataSource<any>();
  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  displayedColumns: string[] = ['id', 'roomCode', 'isActive', 'actions'];
  isLoading = true;
  errorMessage = '';

  constructor(
    private http: HttpClient,
    private dialog: MatDialog,
  ) {}

  ngOnInit(): void {
    this.loadRooms();
  }

  loadRooms() {
    this.http.get<any[]>(`https://localhost:7263/Room`).subscribe({
      next: (res) => {
        this.dataSource.data = res;
        this.isLoading = false;
      },
      error: (err) => {
        this.errorMessage = 'Faild to load Rooms';
        this.isLoading = false;
      }
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLocaleLowerCase();
  }

  ngAfterViewInit(): void {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }

  editRoom(room: any) {
    const dialogRef = this.dialog.open(AddRoomComponent, {
      width: '500px',
      data: room,
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.updateRoom(room.id, result);
      }
    });
  }

  openAddRoom() {
    const dialogRef = this.dialog.open(AddRoomComponent, {
      width: '500px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.saveRoom(result);
      }
    });
  }

  saveRoom(room: any) {
    this.http.post(`https://localhost:7263/Room`, room).subscribe({
      next: () => {
        this.loadRooms();
      },
      error: () => {
        alert('Faild to save Rooms');
      },
    });
  }

  updateRoom(id: number, room: any) {
    this.http.put(`https://localhost:7263/Room/${id}`, room).subscribe({
      next: () => {
        this.loadRooms();
      },
      error: () => {
        alert('Faild to update room');
      },
    });
  }
}

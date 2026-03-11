import { Routes } from '@angular/router';
import { DashboardComponent } from './layout/dashboard/dashboard.component';
import { EmployeeListComponent } from './features/employee/employee-list/employee-list.component';
import { DashboardHomeComponent } from './features/dashboard-home/dashboard-home.component';
import { RoomListComponent } from './features/room/room-list/room-list.component';

export const routes: Routes = [
    {
        path: '',
        component: DashboardComponent,
        children:
        [
           { path: 'dashboard', component: DashboardHomeComponent },
          // { path: 'employees', loadComponent: () => import('./features/employee/employee-list/employee-list.component').then(m => m.EmployeeListComponent)},
            { path:'employees',
              children:[
                {
                    path:'details',
                    loadComponent:()=>
                        import('./features/employee/employee-list/employee-list.component')
                        .then(m=>m.EmployeeListComponent)
                },
                {
                    path:'contracts',
                    loadComponent:()=>
                        import('./features/employee/contract-details/contract-details.component')
                        .then(m=>m.ContractDetailsComponent)
                },
                {
                    path:'shifts',
                    loadComponent:()=>
                        import('./features/employeeshifts/shift-list/shift-list.component')
                        .then(m=>m.ShiftListComponent)
                },
                {
                    path:'',
                    redirectTo:'details',
                    pathMatch:'full'
                }
              ]  
            },
            {
                path:'configuration',
                children:[
                    {
                        path:'rooms',
                        loadComponent:()=>
                            import('./features/room/room-list/room-list.component')
                                .then(m=>m.RoomListComponent)
                            
                    },
                    {
                    path:'breaktime',
                    loadComponent:()=>
                        import('./features/breaktime/breaktime-list/breaktime-list.component')
                        .then(m=>m.BreaktimeListComponent)
                    },
                   {
                    path:'',
                    redirectTo:'details',
                    pathMatch:'full'
                   }
                ]
            },
           { path: '',
              redirectTo: 'dashboard', 
              pathMatch: 'full' 
           }
        ]
    }
];

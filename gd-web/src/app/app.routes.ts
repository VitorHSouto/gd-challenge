import { Route } from '@angular/router';

export const routes: Route[] = [
    {
        path: '',
        loadChildren:  () => import('../main/login/login.module').then(m => m.LoginModule)
    },
    // { 
    //     path: '**', 
    //     redirectTo: 'notes', 
    //     pathMatch: 'full' 
    // },
]  
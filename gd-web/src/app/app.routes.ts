import { Route } from '@angular/router';

export const routes: Route[] = [
    {
        path: 'login',
        loadChildren:  () => import('../main/login/login.module').then(m => m.LoginModule)
    },
    {
        path: 'user',
        loadChildren:  () => import('../main/user/user.module').then(m => m.UserModule)
    },
    { 
        path: '**', 
        redirectTo: 'login', 
        pathMatch: 'full' 
    },
]  
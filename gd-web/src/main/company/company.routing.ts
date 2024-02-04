import { Routes } from '@angular/router';
import { CompanyComponent } from './company.component';
import { CompanyResolver } from './company.resolver';

export const signInRoutes: Routes = [
  {
    path: '',
    component: CompanyComponent,
    resolve: {
      notes: CompanyResolver
    }
  }
];
import { Routes } from '@angular/router';
import { CompanyComponent } from './company.component';
import { CompaniesResolver, CompanyProductsResolver, CompanyResolver } from './company.resolver';
import { CompanyDetailsComponent } from './details/details.component';
import { CompanyListComponent } from './list/list.component';

export const signInRoutes: Routes = [
  {
    path: '',
    component: CompanyComponent,
    children: [
      {
        path: '',
        component: CompanyListComponent,
        resolve: {
          companies: CompaniesResolver
        }
      },
      {
        path: ':id',
        component: CompanyDetailsComponent,
        resolve: {
          company: CompanyResolver,
          products: CompanyProductsResolver
        }
      }
    ]
  }
];
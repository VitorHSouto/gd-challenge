import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import { SharedModule } from '../shared/shared.module';
import { CompanyComponent } from './company.component';
import { signInRoutes } from './company.routing';
import { CompanyDetailsComponent } from './details/details.component';
import { CompanyListComponent } from './list/list.component';

@NgModule({
  declarations: [
    CompanyComponent,
    CompanyListComponent,
    CompanyDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSidenavModule,
    LazyLoadImageModule,
    ReactiveFormsModule,
    RouterModule.forChild(signInRoutes)
  ]
})
export class CompanyModule { }

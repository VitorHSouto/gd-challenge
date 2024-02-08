import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSidenavModule } from '@angular/material/sidenav';
import { RouterModule } from '@angular/router';
import { LazyLoadImageModule } from 'ng-lazyload-image';
import { SharedModule } from '../shared/shared.module';
import { CompanyComponent } from './company.component';
import { signInRoutes } from './company.routing';
import { ProductDetailsPopupComponent } from './details-popup/details-popup.component';
import { CompanyDetailsComponent } from './details/details.component';
import { CompanyListComponent } from './list/list.component';

@NgModule({
  declarations: [
    CompanyComponent,
    CompanyListComponent,
    CompanyDetailsComponent,
    ProductDetailsPopupComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatFormFieldModule,
    MatDialogModule,
    MatIconModule,
    MatInputModule,
    MatSidenavModule,
    LazyLoadImageModule,
    ReactiveFormsModule,
    RouterModule.forChild(signInRoutes)
  ]
})
export class CompanyModule { }

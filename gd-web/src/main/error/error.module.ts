import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { ErrorComponent } from './error.component';
import { errorRoutes } from './error.routing';

@NgModule({
  declarations: [
    ErrorComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    RouterModule.forChild(errorRoutes)
  ]
})
export class ErrorModule { }

import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { DialogComponent } from './dialog/dialog.component';
import { HButtonComponent } from './h-button/h-button.component';

@NgModule({
  declarations: [
    DialogComponent,
    HButtonComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule,
    MatButtonModule
  ],
  exports: [
    DialogComponent,
    HButtonComponent,
  ]
})
export class SharedModule { }

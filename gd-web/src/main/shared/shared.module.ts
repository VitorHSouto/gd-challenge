import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { DialogComponent } from './dialog/dialog.component';
import { HButtonComponent } from './h-button/h-button.component';
import { RequestIndicatorComponent } from './request-indicator/request-indicator.component';

@NgModule({
  declarations: [
    DialogComponent,
    HButtonComponent,
    RequestIndicatorComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule,
    MatProgressBarModule,
    MatButtonModule
  ],
  exports: [
    DialogComponent,
    RequestIndicatorComponent,
    HButtonComponent,
  ]
})
export class SharedModule { }

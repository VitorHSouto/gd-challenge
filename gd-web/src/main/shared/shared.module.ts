import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { HButtonComponent } from './h-button/h-button.component';

@NgModule({
  declarations: [
    HButtonComponent
  ],
  imports: [
    CommonModule,
    MatButtonModule
  ],
  exports: [
    HButtonComponent,
  ]
})
export class SharedModule { }

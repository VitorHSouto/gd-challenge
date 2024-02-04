import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-popup',
  templateUrl: './dialog.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DialogComponent {
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: { 
      title: string; 
      message: string;
      cancelText: string;
    },
    private dialogRef: MatDialogRef<DialogComponent>
  ) {}

  close(): void {
    this.dialogRef.close();
  }
}
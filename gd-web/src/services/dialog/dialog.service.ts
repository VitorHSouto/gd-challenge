// popup.service.ts
import { Injectable } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { DialogComponent } from 'src/main/shared/dialog/dialog.component';

@Injectable({
  providedIn: 'root',
})
export class DialogService {
  constructor(private dialog: MatDialog) {}

  openPopup(title: string, message: string, cancelText: string = 'Cancelar'): Observable<any> {
    return this.dialog.open(DialogComponent, {
      data: { title, message, cancelText },
    }).afterClosed();
  }
}

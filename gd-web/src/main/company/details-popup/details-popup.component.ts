import { ChangeDetectionStrategy, Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Product } from 'src/services/product/product.types';

@Component({
  selector: 'app-details-popup',
  templateUrl: './details-popup.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ProductDetailsPopupComponent {
  constructor(
    private readonly _dialogRef: MatDialogRef<ProductDetailsPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Product
  ) {}

  close(): void {
    this._dialogRef.close();
  }
}

import { ChangeDetectionStrategy, ChangeDetectorRef, Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { Company } from 'src/services/company/company.types';
import { Product } from 'src/services/product/product.types';
import { ProductDetailsPopupComponent } from '../details-popup/details-popup.component';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CompanyDetailsComponent {

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _changeDetectorRef: ChangeDetectorRef,
    private readonly _dialog: MatDialog
  ) {}

  company: Company;
  allProducts: Product[] = [];
  drawerIsOpen: boolean = false;

  private readonly _destroySubject = new Subject<boolean>();

  ngOnInit(): void {
    this.subscribeToRouteChanges();
  }

  ngOnDestroy(): void {
    this._destroySubject.next(true);
    this._destroySubject.unsubscribe();
  }

  toggleDrawer(){
    this.drawerIsOpen = !this.drawerIsOpen;
    this._changeDetectorRef.markForCheck();
  }

  openProductDetails(product: any): void {
    this._dialog.open(ProductDetailsPopupComponent, {
      autoFocus: false,
      data: product
    });
  }

  private subscribeToRouteChanges(): void{
    this._activatedRoute.data
      .subscribe(data => {
        this.company = data['company'];
        this.allProducts = data['products'];
        this._changeDetectorRef.markForCheck();
    });
  }

}

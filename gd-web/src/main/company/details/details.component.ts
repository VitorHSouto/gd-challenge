import { ChangeDetectorRef, Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject } from 'rxjs';
import { Company } from 'src/services/company/company.types';
import { Product } from 'src/services/product/product.types';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
})
export class CompanyDetailsComponent {

  constructor(
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _changeDetectorRef: ChangeDetectorRef
  ) {}

  company: Company;
  allProducts: Product[] = [];
  private readonly _destroySubject = new Subject<boolean>();

  ngOnInit(): void {
    this.subscribeToRouteChanges();
  }

  ngOnDestroy(): void {
    this._destroySubject.next(true);
    this._destroySubject.unsubscribe();
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
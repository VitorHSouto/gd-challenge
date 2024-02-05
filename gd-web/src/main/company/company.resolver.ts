import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from "rxjs";
import { CompanyService } from "src/services/company/company.service";
import { Company } from "src/services/company/company.types";
import { Product } from "src/services/product/product.types";

@Injectable({ providedIn: 'root' })
export class CompaniesResolver {
  constructor(
    private _service: CompanyService
  ) {}

  resolve( route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Company[]> {
    return this._service.list();
  }
}

@Injectable({ providedIn: 'root' })
export class CompanyResolver {
  constructor(private _service: CompanyService) {}

  resolve( route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Company> {
    const id = route.paramMap.get('id');
    if(!id)
      return of();

    return this._service.getById(id);
  }
}

@Injectable({ providedIn: 'root' })
export class CompanyProductsResolver {
  constructor(private _service: CompanyService) {}

  resolve( route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Product[]> {
    const id = route.paramMap.get('id');
    if(!id)
      return of();

    return this._service.getProducts(id);
  }
}
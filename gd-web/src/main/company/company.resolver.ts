import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { CompanyService } from "src/services/company/company.service";
import { Company } from "src/services/company/company.types";

@Injectable({ providedIn: 'root' })
export class CompanyResolver {
  constructor(
    private _service: CompanyService
  ) {}

  resolve( route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Company[]> {
    return this._service.list();
  }
}
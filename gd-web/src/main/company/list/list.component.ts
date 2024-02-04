import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { CompanyService } from 'src/services/company/company.service';
import { Company } from 'src/services/company/company.types';

@Component({
  selector: 'company-list',
  templateUrl: './list.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CompanyListComponent implements OnInit {

  constructor(
    private readonly _companyService: CompanyService,
    private readonly _router: Router,
    private readonly _changeDetectorRef: ChangeDetectorRef
  ) {
  }

  allCompanies: Company[] = [];
  private readonly _destroySubject = new Subject<boolean>();

  ngOnInit(): void {
    this.subscribeToNotes();
  }

  ngOnDestroy(): void {
    this._destroySubject.next(true);
    this._destroySubject.unsubscribe();
  }

  private subscribeToNotes(): void{
    this._companyService.notes$
    .pipe(takeUntil(this._destroySubject))
      .subscribe(companies => {
        this.allCompanies = companies;
        this._changeDetectorRef.markForCheck();
      });
  }

}

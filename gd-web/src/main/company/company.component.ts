import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, debounceTime, distinctUntilChanged, switchMap, takeUntil } from 'rxjs';
import { CompanyService } from 'src/services/company/company.service';
import { ContextService } from 'src/services/context/context';

@Component({
  templateUrl: './company.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CompanyComponent implements OnInit, OnDestroy {

  form: FormGroup;
  isBusy: boolean = false;

  constructor(
    private readonly _changeDetectorRef: ChangeDetectorRef,
    private readonly _router: Router,
    private readonly _contextService: ContextService,
    private readonly _companyService: CompanyService
  ) {}

  private readonly _searchText = new Subject<string>();
  private readonly _destroySubject = new Subject<boolean>();

  ngOnInit() {
    this.subscribeToTextChange();
  }

  ngOnDestroy(): void {
    this._destroySubject.next(true);
    this._destroySubject.unsubscribe();
  }

  goToDefaultRoute(): void{
    this._router.navigateByUrl('company');
  }

  logout(): void{
    this._contextService.logout();
  }

  onInputChange(event: any): void {
    const searchText = event.target.value;
    this._searchText.next(searchText);
  }

  private subscribeToTextChange(): void{
    this._searchText
      .pipe(
        takeUntil(this._destroySubject),
        debounceTime(1000),
        distinctUntilChanged(),
        switchMap(searchText => this._companyService.list(searchText))
      )
      .subscribe();
  }
}

import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { Subject, debounceTime, distinctUntilChanged, filter, switchMap, takeUntil } from 'rxjs';
import { CompanyService } from 'src/services/company/company.service';
import { ContextService } from 'src/services/context/context';

@Component({
  templateUrl: './company.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class CompanyComponent implements OnInit, OnDestroy {

  form: FormGroup;
  isToShowFilter: boolean = false;

  constructor(
    private readonly _changeDetectorRef: ChangeDetectorRef,
    private readonly _activatedRoute: ActivatedRoute,
    private readonly _router: Router,
    private readonly _contextService: ContextService,
    private readonly _companyService: CompanyService,
  ) {}

  private readonly _searchText = new Subject<string>();
  private readonly _destroySubject = new Subject<boolean>();

  ngOnInit() {
    this.subscribeToTextChange();
    this.subscribeToRouteChanges();
    this.refreshFilterVisibility();
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

  clearFilter(inputElement: any): void {
    inputElement.value = '';
    this._searchText.next(inputElement.value);
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

  private subscribeToRouteChanges(): void{
    this._router.events
      .pipe(
        takeUntil(this._destroySubject),
        filter(event => event instanceof NavigationEnd)
      )
      .subscribe((_) => this.refreshFilterVisibility()
    );
  }

  private refreshFilterVisibility(): void{
    const companyId = this._activatedRoute.firstChild?.snapshot.paramMap.get('id');
    this.isToShowFilter = companyId == null;
    this._changeDetectorRef.markForCheck();
  }
}

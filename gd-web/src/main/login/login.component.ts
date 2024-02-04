import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { ContextService } from 'src/services/context/context';
import { DialogService } from 'src/services/dialog/dialog.service';
import { LoginService } from 'src/services/login/login.service';
import { LoginRequest } from 'src/services/login/login.types';
import { AuthenticatedUser } from 'src/services/user/user.types';

@Component({
  templateUrl: './login.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;
  isBusy: boolean = false;

  constructor(
    private readonly _changeDetectorRef: ChangeDetectorRef,
    private readonly _loginService: LoginService,
    private readonly _contextService: ContextService,
    private readonly _dialogService: DialogService,
    private readonly _formBuilder: FormBuilder,
    private readonly _router: Router
  ) {}

  private readonly _destroySubject = new Subject<boolean>();

  ngOnInit() {
    this.initForm();
  }

  ngOnDestroy(): void {
    this._destroySubject.next(true);
    this._destroySubject.unsubscribe();
  }

  onSubmit() {
    if (this.loginForm.invalid)
      return this.showFormErrorMessage();

    const req: LoginRequest = {...this.loginForm.value};

    this.isBusy = true;
    this._loginService.login(req)
      .pipe(takeUntil(this._destroySubject))
      .subscribe({
        error: (error) => {
          this.isBusy = false;
          this._changeDetectorRef.markForCheck();
        },
        next: (user) => {
          this.isBusy = false;
          this._changeDetectorRef.markForCheck();

          this.authenticate(user);
        }
      });
  }

  private showFormErrorMessage(){
    this._dialogService.openPopup(
      'Atenção', 
      'Insira um e-mail válido.'
    )
  }

  private authenticate(user: AuthenticatedUser): void{
    this._contextService.setContext(user);
    this._router.navigateByUrl('company');
  }

  private initForm(): void{
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.email]],
      password: ['', Validators.required]
    });
  }
}

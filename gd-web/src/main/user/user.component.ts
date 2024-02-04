import { ChangeDetectionStrategy, ChangeDetectorRef, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { DialogService } from 'src/services/dialog/dialog.service';
import { UserService } from 'src/services/user/user.service';
import { UserSaveRequest } from 'src/services/user/user.types';

@Component({
  templateUrl: './user.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserComponent implements OnInit, OnDestroy {
  form: FormGroup;
  isBusy: boolean;

  constructor(
    private readonly _changeDetectorRef: ChangeDetectorRef,
    private readonly _userService: UserService,
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
    if (this.form.invalid)
      return;

    const req: UserSaveRequest = {...this.form.value};
    this.isBusy = true;

    this._userService.save(req)
      .pipe(takeUntil(this._destroySubject))
      .subscribe({
        error: (error) => {
          this.isBusy = false;
          this._changeDetectorRef.markForCheck();
        },
        next: (user) => {
          this.isBusy = false;
          this._changeDetectorRef.markForCheck();
          this.redirectToLoginPage();
        }
      });
  }

  private initForm(): void{
    this.form = this._formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.email]],
      password: ['', Validators.required]
    });
  }

  private redirectToLoginPage(): void{
    this._dialogService.openPopup(
      'Usuário cadastrado', 
      'Prossiga para a tela de login para entrar na plataforma.', 
      'Continuar'
    ).pipe(takeUntil(this._destroySubject))
    .subscribe((_) => this._router.navigateByUrl('login'));
  }
}

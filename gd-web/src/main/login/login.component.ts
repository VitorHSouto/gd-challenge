import { ChangeDetectionStrategy, Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Validators } from 'ngx-editor';
import { Subject, takeUntil } from 'rxjs';
import { ContextService } from 'src/services/context/context';
import { LoginService } from 'src/services/login/login.service';
import { LoginRequest } from 'src/services/login/login.types';
import { User } from 'src/services/user/user.types';

@Component({
  templateUrl: './login.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent implements OnInit, OnDestroy {
  loginForm: FormGroup;

  constructor(
    private readonly _loginService: LoginService,
    private readonly _contextService: ContextService,
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
      return;

    const req: LoginRequest = {...this.loginForm.value};

    this._loginService.login(req)
      .pipe(takeUntil(this._destroySubject))
      .subscribe(user => this.authenticate(user));
  }

  private authenticate(user: User): void{
    this._contextService.setContext(user);
    this._router.navigateByUrl(`notes`);
  }

  private initForm(): void{
    this.loginForm = this._formBuilder.group({
      email: ['', [Validators.required]],
      password: ['', Validators.required]
    });
  }
}

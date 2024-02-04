import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticatedUser } from '../user/user.types';
import { ContextSettings } from './context.types';

@Injectable({
  providedIn: 'root'
})
export class ContextService {

  constructor(
    private readonly _router: Router
  ) {
    this.initializeContext();
  }

  private readonly acessContextKey = 'localStorageKey';
  context: ContextSettings;

  public setContext(user: AuthenticatedUser): void{
    this.context = {
      isAuthenticated: true,
      token: user.token,
      user: user
    }

    localStorage.setItem(this.acessContextKey, JSON.stringify(this.context));
  }

  private initializeContext(): void {
    const storedContext = localStorage.getItem(this.acessContextKey);
  
    if (storedContext) {
      this.context = JSON.parse(storedContext);
    }
  }

  logout(): void{
    this.context = {isAuthenticated: false};
    localStorage.removeItem(this.acessContextKey);
    this._router.navigateByUrl('login');
  }

}

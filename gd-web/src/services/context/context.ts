import { Injectable } from '@angular/core';
import { User } from '../user/user.types';
import { ContextSettings } from './context.types';

@Injectable({
  providedIn: 'root'
})
export class ContextService {

  constructor() { }

  context: ContextSettings;

  public setContext(user: User): void{
    this.context = {
        isAuthenticated: true,
        user: user
    }
  }

}

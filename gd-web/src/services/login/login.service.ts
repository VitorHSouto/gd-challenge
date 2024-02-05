import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { User } from '../user/user.types';
import { LoginRequest } from './login.types';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(
    private readonly _httpClient:  HttpClient
  ) { }

  readonly baseUrl: string = `${environment.apiUrl}/login`;

  login(req: LoginRequest): Observable<User>{
    return this._httpClient.post<User>(`${this.baseUrl}/authenticate`, req)
      .pipe()
  }
}

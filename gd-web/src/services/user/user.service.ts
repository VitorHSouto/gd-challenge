import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { User, UserSaveRequest } from './user.types';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private readonly _httpClient:  HttpClient
  ) { }
  readonly baseUrl: string = `${environment.apiUrl}/user`;

  save(req: User): Observable<UserSaveRequest>{
    return this._httpClient.post<User>(this.baseUrl, req)
      .pipe()
  }
}

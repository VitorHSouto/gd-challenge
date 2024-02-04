import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, tap } from 'rxjs';
import { environment } from 'src/environment/environment';
import { Company, CompanyIncludeDetails } from './company.types';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(
    private readonly _httpClient:  HttpClient
  ) { }

  readonly baseUrl: string = `${environment.apiUrl}/company`;


  get notes$() : Observable<Company[]> {
    return this._notes.asObservable();
  }

  private readonly _notes: BehaviorSubject<Company[]> = new BehaviorSubject<Company[]>([]);

  private alreadyLoaded: boolean = false;

  list(searchText?: string, details?: CompanyIncludeDetails[]): Observable<Company[]>{
    const params = new HttpParams({
      fromObject: {
        includeDetails: details?.join(', ') ?? `${CompanyIncludeDetails.all}`,
        searchText: searchText ?? ''
      }
    });

    return this._httpClient.get<Company[]>(this.baseUrl, {params})
      .pipe(tap(notes => {  
        this._notes.next(notes)
    }))
  }
}

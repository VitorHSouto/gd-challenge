import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RequestIndicatorService {

  constructor() { }

    get inRequest$() : Observable<boolean> {
        return this._inRequest.asObservable();
    }

    private readonly _inRequest: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    setState(inRequest: boolean): void{
      this._inRequest.next(inRequest);
    }

}

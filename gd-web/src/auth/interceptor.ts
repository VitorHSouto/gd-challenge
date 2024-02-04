import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { DialogService } from 'src/services/dialog/dialog.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

    constructor(
        private readonly _dialogService: DialogService,
    ){}

    private readonly genericErrorMessage: String = 'Ocorreu um erro inesperado';

    intercept( request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError((error: HttpErrorResponse) => {
                const message = error.error?.ErrorMessage ?? this.genericErrorMessage;
                this._dialogService.openPopup('Atenção!', message);

                return throwError(error);
            })
        );
    }
  
}

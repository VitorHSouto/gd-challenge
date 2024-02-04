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
import { ContextService } from 'src/services/context/context';
import { DialogService } from 'src/services/dialog/dialog.service';

@Injectable()
export class HttpErrorInterceptor implements HttpInterceptor {

    constructor(

        private readonly _context: ContextService,
        private readonly _dialogService: DialogService,
    ){}

    private readonly genericErrorMessage: String = 'Ocorreu um erro inesperado';

    intercept(request: HttpRequest<any>, handler: HttpHandler): Observable<HttpEvent<any>> {
        const req = this.buildRequest(request, handler);

        return req.pipe(
            catchError((error: HttpErrorResponse) => {
                const message = error.error?.ErrorMessage ?? this.genericErrorMessage;
                this._dialogService.openPopup('Atenção!', message);

                return throwError(error);
            })
        );
    }

    buildRequest(request: HttpRequest<any>, next: HttpHandler) : Observable<HttpEvent<any>>{
        if(!this._context.context?.isAuthenticated)
            return next.handle(request);

        const authToken = this._context.context?.token;
        const newRequest = request.clone({
            setHeaders: {
                Authorization: `Bearer ${authToken}`
            }
        });

        return next.handle(newRequest);
    }
  
}

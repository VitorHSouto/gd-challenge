import {
    HttpErrorResponse,
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';
import { ContextService } from 'src/services/context/context';
import { DialogService } from 'src/services/dialog/dialog.service';
import { RequestIndicatorService } from 'src/services/request-interceptor/request-interceptor.service';

@Injectable()
export class Interceptor implements HttpInterceptor {

    constructor(
        private readonly _context: ContextService,
        private readonly _dialogService: DialogService,
        private readonly _requestIndicatorService: RequestIndicatorService,
    ){}

    
    private readonly genericErrorMessage: String = 'Ocorreu um erro inesperado';

    intercept(request: HttpRequest<any>, handler: HttpHandler): Observable<HttpEvent<any>> {
        this._requestIndicatorService.setState(true);
        const req = this.buildRequest(request, handler);

        return req.pipe(
            finalize(() => this._requestIndicatorService.setState(false)),
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

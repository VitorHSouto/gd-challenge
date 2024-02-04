import { ChangeDetectorRef, Component } from '@angular/core';
import { RequestIndicatorService } from 'src/services/request-interceptor/request-interceptor.service';

@Component({
  selector: 'request-indicator',
  templateUrl: './request-indicator.component.html'
})
export class RequestIndicatorComponent {

  constructor(
    private readonly _requestService: RequestIndicatorService,
    private readonly _changeDetectorRef: ChangeDetectorRef
  ){
    this.subscribeToRequestStatus();
  }

  isToShow: boolean = false;

  private subscribeToRequestStatus(): void{
    this._requestService.inRequest$
      .pipe()
      .subscribe(inRequest => {
        this.isToShow = inRequest;
        this._changeDetectorRef.markForCheck();
      });
  }

}

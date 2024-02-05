import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  templateUrl: './error.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ErrorComponent implements OnInit {


  constructor(
    private readonly _router: Router
  ) {}

  ngOnInit() {
  }

  goToDefaultRoute(): void{
    this._router.navigateByUrl('login');
  }
}

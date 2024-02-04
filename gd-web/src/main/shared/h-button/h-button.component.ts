import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'h-button',
  templateUrl: './h-button.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HButtonComponent implements OnInit {

  constructor() {}

  @Input() text: string;
  @Input() buttonClass: string;
  @Input() isBusy: boolean = false;
  @Input() isPrimary: boolean = true;

  @Output() onClick = new EventEmitter<boolean>();

  ngOnInit(): void {

  }

  onClickEvent(): void{
    this.onClick.emit();
  }

}

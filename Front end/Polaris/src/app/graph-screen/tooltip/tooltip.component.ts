import { Component, Input , OnInit} from '@angular/core';

@Component({
  selector: 'app-tooltip',
  templateUrl: './tooltip.component.html',
  styleUrls: ['./tooltip.component.scss']
})
export class TooltipComponent implements OnInit {
  @Input()
  content: { id: string, accountId: string, name: string, familyName: string };
  @Input()
  position: { x: number, y: number };

  ngOnInit(): void{
  }
}

import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ConstValuesService } from 'src/services/const-values.service';
import { DataOnScreenService } from 'src/services/data-on-screen.service';
import { OgmaHandlerService } from 'src/services/ogma-handler.service';

@Component({
  selector: 'app-path-card',
  templateUrl: './path-card.component.html',
  styleUrls: ['./path-card.component.scss']
})
export class PathCardComponent implements OnInit {

  @Input()
  public pathId : number ;

  @Output()
  public id = new EventEmitter<number>();

  @Input()
  public pathLength : number =  0 ;


  public show : boolean = true;
  constructor(
    public dataOnScreen : DataOnScreenService) {
    }

  ngOnInit(): void {
    // this.findAmount();
  }

  public checkChange(){

     this.show = !this.show ;
     this.id.emit(this.show ? this.pathId : -1 ) ;
     console.log(this.pathLength);

  }

}


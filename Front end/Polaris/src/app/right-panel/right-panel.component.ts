import { Component, OnInit } from '@angular/core';
import { ComponentsCommunicationService } from 'src/services/components-communication.service';

@Component({
  selector: 'app-right-panel',
  templateUrl: './right-panel.component.html',
  styleUrls: ['./right-panel.component.scss']
})
export class RightPanelComponent implements OnInit {



  constructor(public componentCommunication: ComponentsCommunicationService) { }

  ngOnInit(): void {
  }
  // $(document).ready(function()
  // {
  // 	slideRight($(".item-set").eq(0));

  //   $(".icons .icon").click(function()
  //   {
  //   	var idx = $(this).index();
  //     slideLeft($(".item-set"));
  //     slideRight($(".item-set").eq(idx));
  //   });
  // });

  // function slideRight(elem) {
  // 	elem.show();
  // 	elem.animate({ 'marginLeft': '0px' }, 100);
  // }

	// function slideLeft(elem) {
  // 	elem.hide();
  // 	elem.css({ 'marginLeft': '-300px' });
  // }


}

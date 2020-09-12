import { Component, Input, OnInit } from '@angular/core';
import { NodeBox } from './../../../node';

@Component({
  selector: 'app-node-info-box',
  templateUrl: './node-info-box.component.html',
  styleUrls: ['./node-info-box.component.scss']
})

export class NodeInfoBoxComponent implements OnInit {
  @Input()
  public node: NodeBox ={"accountID":"873562875" ,"cardID":"8932648172"
,"sheba":"8293612897","accountType":"gharzolhasane","branchName":"here" ,"branchTelephone":"09124627234"
,"branchAdress":"hereeeee","ownerName":"mahla","ownerFamilyName":"sharifi" ,"ownerID":"6735725"}

  constructor() { }

  ngOnInit(): void {
  }

}

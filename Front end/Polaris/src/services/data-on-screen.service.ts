import { EventEmitter, Injectable } from '@angular/core';

@Injectable()
export class DataOnScreenService {
  public resultArr;
  public branchFirstInit: boolean = true;
  public nodeViewFirstInit: boolean = true;
  public edgeViewFirstInit: boolean = true;
  public showMaxFlow: boolean = false;
  public branchList: string[] = ["آزادی - یادگار", "چهارراه وليعصر", "نازی آباد", "خیابان ایت اله طالقانی", "پاستور",
   "گاندی", "میدان حسین آباد", "امیر آباد شمالی", "احمدیه", "استاد حسن بنا", "جمالزاده جنوبی",
   "شهید صابونیان", "استاد نجات الهی شمالی", "چهارراه نیاکان", "سید خندان", "بیست متری نبرد"];

}

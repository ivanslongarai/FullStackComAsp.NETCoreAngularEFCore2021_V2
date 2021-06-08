import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-title',
  templateUrl: './title.component.html',
  styleUrls: ['./title.component.scss']
})
export class TitleComponent implements OnInit {
  @Input() title: string = "";
  @Input() route : string = "";
  @Input() subTitle: string = "";
  @Input() iconClass: string = "";
  @Input() buttonList: boolean = false;

  constructor(private router : Router) { }

  ngOnInit() {
  }

  public list():  void {
      this.router.navigate([`/${this.route.toLowerCase()}/list`]);
  }

}

import { Component, OnInit, Injectable } from '@angular/core';


@Component({
  selector: 'app-occon-case',
  templateUrl: './occon-case.component.html',
  styleUrls: ['./occon-case.component.css','./bootstrap.css','./my.css']
})
export class OcconCaseComponent {
  name = 'OcconTimer';
  timeLeft: number = 59;
  time2left: number = 60;
  interval;
 
  NowDate = Date.now();
  startTimer() {
    this.time2left = 60;
    this.timeLeft = 59;
    this.interval = setInterval(() => {
      if(this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.timeLeft = 59;
      }
    },60000)

    this.interval = setInterval(() => {
      if(this.time2left > 0) {        
        this.time2left--;
      } else {
        this.time2left = 60;
      }
    },1000)    

  }

  constructor() { }
  
}

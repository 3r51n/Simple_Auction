import { Component, OnInit } from '@angular/core';
import { OcconModel } from "../model/Occon.model";
import { HttpClient } from '@angular/common/http';
import { SignalR } from '../service/signalR';




@Component({
  selector: 'app-root', styleUrls: ['./occon-case.component.css'], templateUrl: './app.component.html'})
export class AppComponent implements OnInit {
  model: OcconModel; 
  constructor( private  http: HttpClient,public signalR: SignalR) { }

  //https://angular.io/guide/http  
  private Request = () => {this.http.get('https://localhost:5001/Occapi/occon').subscribe(res => {this.signalR.OcconData = res as OcconModel;})  }

  ngOnInit()
   {  
      this.signalR.Connection();
      this.signalR.ClientToData();  
      this.signalR.DataToClient();             
      this.Request();
   }
}

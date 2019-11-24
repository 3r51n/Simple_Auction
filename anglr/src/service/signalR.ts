import { Injectable } from '@angular/core';
import { OcconModel } from "../model/occon.model";
import * as signalR from "@aspnet/signalr";


@Injectable({providedIn: 'root'})

export class SignalR
 {  
    private hubConnect: signalR.HubConnection;
    public OcconData: OcconModel;    
    public Connection = () =>
     {
        this.hubConnect = new signalR.HubConnectionBuilder() .withUrl("https://localhost:5001/Occapi/occon") .build();        
        this.hubConnect .start() .then(() => console.log("Connected")) .catch(err => console.log('Error while establishing connection :(')) ;
    }


    public ClientToData = (PlaceBid,id) => 
    {   var bid = PlaceBid.value;
        var id = id;
        var userName = PlaceBid.getAttribute('data-username');        
        this.hubConnect.invoke("SendBid", userName, bid,id).catch(err => console.error("NotSended",err));
    }

    public DataToClient = () => 
    {this.hubConnect.on("ClientToData", (data) => 
         { 
            if(JSON.stringify(this.OcconData.bidders ) == JSON.stringify(data.bidders ))
            {this.OcconData.balanceTime = data.balanceTime;
            }
            else{
                this.OcconData = data;
            }
         }
         );
    }

    public restore = () => {
        this.hubConnect.invoke("Restore")
        .catch(err => console.error(err));
    }

}
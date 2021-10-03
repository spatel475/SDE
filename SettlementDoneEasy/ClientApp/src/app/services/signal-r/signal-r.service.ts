import { Injectable } from "@angular/core";
import * as signalR from "@microsoft/signalr";
// import { AppConfiguration } from "read-appsettings-json";

@Injectable({
  providedIn: "root",
})
export class SignalRService {
  private hubConnection: signalR.HubConnection;

  constructor() {
    this.startConnection();
    this.setupListeners();
  }

  startConnection() {
    //   HARDCODED
    var serverHubUrl = "https://" + "localhost" + ":" + "4001";
    console.log();
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl(serverHubUrl + "/hub")
      .build();
    this.hubConnection
      .start()
      .then(() => console.log("Connection started"))
      .catch((err) => console.warn("Error while starting connection: ", err));
  }

  setupListeners() {
    this.hubConnection.on("TestSuccessful", (data) => console.log(data));
  }
}

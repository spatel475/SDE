import { Injectable } from "@angular/core";
import * as signalR from "@microsoft/signalr";

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
    this.hubConnection = new signalR.HubConnectionBuilder()
      .withUrl("https://localhost:5001/serverhub")
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

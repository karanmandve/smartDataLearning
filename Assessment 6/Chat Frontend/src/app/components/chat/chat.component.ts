import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import * as signalR from '@microsoft/signalr';
import { UserServiceService } from '../../services/user/user-service.service';
import { ToastrService } from 'ngx-toastr';
import { NavbarComponent } from "../navbar/navbar.component";

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [FormsModule, CommonModule, NavbarComponent],
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.scss'
})
export class ChatComponent {

  message: string = "";
  messages: string[] = [];
  userName: string = "";
  email: string = localStorage.getItem('email') || '';
  

  userService: any = inject(UserServiceService);
  toaster: any = inject(ToastrService);

  private _chatHubConnection: signalR.HubConnection | null | undefined;

  ngOnInit(): void {

    this.userService.getUser(this.email).subscribe({
      next: (res: any) => {
        this.userName = `${res.firstName} ${res.lastName}`;
      },
      error: (err: any) => {
        this.toaster.error(
          'An error occurred while fetching user details. Please try again later.',
          'Error'
        );
      },
    });

    this._chatHubConnection = new signalR.HubConnectionBuilder()
      .withUrl(`https://localhost:7194/chathub`, {
        timeout: 600000
      })
      .configureLogging(signalR.LogLevel.Error)
      .build();

    this.startHubConnection(this._chatHubConnection);

    this._chatHubConnection.on("messageRecieved", (message: string, user: string) => {
      this.messages.push(`${user } : ${message}`);
      this.message = "";
    });
  }

  onMessageSent() {
    this._chatHubConnection?.invoke("messageSent", this.message, this.userName);
  }

  private startHubConnection(hubConnection: signalR.HubConnection): Promise<signalR.HubConnection> {
    return hubConnection
      .start()
      .then(() => {
        console.log('Connection started. Connection ID:', hubConnection.connectionId);
        return hubConnection;
      })
      .catch(err => {
        console.error('Error while starting connection: ', err);
        return hubConnection;
      });
  }
}

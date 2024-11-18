import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import * as OT from '@opentok/client';

@Injectable({
  providedIn: 'root'
})
export class OpenTokService {

  session: OT.Session = null as any;
  publisher: OT.Publisher = null as any;

  constructor(private http: HttpClient) {}

  getSessionId(): Observable<{ sessionId: string }> {
    return this.http.get<{ sessionId: string }>('/api/opentok/session');
  }

  getToken(sessionId: string): Observable<{ token: string }> {
    return this.http.get<{ token: string }>(`/api/opentok/token/${sessionId}`);
  }

  initSession(apiKey: string, sessionId: string, token: string): void {
    this.session = OT.initSession(apiKey, sessionId);
    this.session.connect(token, (err: any) => {
      if (err) {
        console.error('Error connecting to session:', err.message);
      } else {
        console.log('Connected to session');
      }
    });
  }

  publishStream(divId: string): void {
    this.publisher = OT.initPublisher(divId);
    this.session.publish(this.publisher, (err:any) => {
      if (err) console.error('Error publishing:', err.message);
    });
  }

  subscribeToStreams(divId: string): void {
    this.session.on('streamCreated', (event:any) => {
      this.session.subscribe(event.stream, divId, {}, (err:any) => {
        if (err) console.error('Error subscribing to stream:', err.message);
      });
    });
  }

  shareScreen(divId: string): void {
    OT.checkScreenSharingCapability((response:any) => {
      if (response.supported) {
        const screenPublisher = OT.initPublisher(divId, { videoSource: 'screen' });
        this.session.publish(screenPublisher, (err:any) => {
          if (err) console.error('Error sharing screen:', err.message);
        });
      } else {
        console.error('Screen sharing not supported');
      }
    });
  }
}

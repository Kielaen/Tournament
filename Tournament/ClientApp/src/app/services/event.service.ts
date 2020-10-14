import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventService {
  readonly APIUrl = "https://localhost:44349/api";
  constructor(private http: HttpClient) { }

  getEvents(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Events');
  }

  addEvent(val: any) {
    return this.http.post(this.APIUrl + '/Events', val);
  }

  updateEvent(id: any, val: any) {
    return this.http.put(this.APIUrl + '/Events/' + id, val);
  }

  deleteEvent(val: any) {
    return this.http.delete(this.APIUrl + '/Events/'+ val);
  }
  
}

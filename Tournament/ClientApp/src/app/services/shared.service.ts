import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  readonly APIUrl = "https://localhost:44349/api";
  constructor(private http: HttpClient) { }

  //Tournaments
  getTournaments(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/Tournaments');
  }

  addTournament(val: any) {
    return this.http.post(this.APIUrl + '/Tournaments', val);
  }

  updateTournament(id:any,val: any) {
    return this.http.put(this.APIUrl + '/Tournaments/'+id, val);
  }

  deleteTournament(val: any) {
    return this.http.delete(this.APIUrl + '/Tournaments/' + val);
  }

  //EventDetails
  getEventDetails(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/EventDetails');
  }

  addEventDetail(val: any) {
    return this.http.post(this.APIUrl + '/EventDetails', val);
  }

  updateEventDetail(id:any, val: any) {
    return this.http.put(this.APIUrl + '/EventDetails/'+id, val);
  }

  deleteEventDetail(val: any) {
    return this.http.delete(this.APIUrl + '/EventDetails/' + val);
  }

  //EventDetailStatuses
  getEventDetailStatuses(): Observable<any[]> {
    return this.http.get<any>(this.APIUrl + '/EventDetailStatus');
  }
}

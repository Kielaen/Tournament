import { Component, OnInit } from '@angular/core';
import { EventService } from 'src/app/services/event.service';
import { Event} from 'src/app/classes/Event';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-show-event',
  templateUrl: './show-event.component.html',
  styleUrls: ['./show-event.component.css']
})
export class ShowEventComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;

  constructor(private service: EventService, private authorizeService: AuthorizeService) { }

  EventList: any = [];

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.refreshEventList();
  }
  ModalTitle: string;
  ActivateAddEditEvent: boolean;
  eve: Event;

  addEvent() {

    this.eve = {
      EventID: 0,
        FK_TournamentID: "0",
      EventName: "",
        EventNumber: "0",
        EventDateTime: "",
        EventEndDateTime: "",
      AutoClose: "false"
    }
    this.ModalTitle = "Add Event";
    this.ActivateAddEditEvent = true;
    console.log(this.eve);
  }

  editEvent(eve) {
      
    this.eve = eve;
    this.ModalTitle = "Edit Event";
      this.ActivateAddEditEvent = true;
      console.log(this.eve);
  }
  closeClick() {
    this.ActivateAddEditEvent = false;
    this.refreshEventList();
  }

  deleteEvent(eve) {
    if (confirm("Are you sure?")) {
      this.service.deleteEvent(eve.eventID).subscribe(res => {
        alert("Delete Successfull");
        this.refreshEventList();
      });
    }
  }

  refreshEventList() {
    this.service.getEvents().subscribe(data => {
      this.EventList = data;
    });
  }
}

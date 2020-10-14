import { Component, OnInit, Input } from '@angular/core';
import { EventService } from 'src/app/services/event.service';
import { SharedService } from 'src/app/services/shared.service';
import { Event } from 'src/app/classes/Event';

@Component({
  selector: 'app-add-edit-event',
  templateUrl: './add-edit-event.component.html',
  styleUrls: ['./add-edit-event.component.css']
})
export class AddEditEventComponent implements OnInit {

  constructor(private service: EventService, private serviceShared: SharedService) { }

  @Input() eve: any;
  EventID: number;
  FK_TournamentID: string;
  EventName: string;
  EventNumber: string;
  EventDateTime: string;
  EventEndDateTime: string;
  AutoClose: string;
    model= new Event(0,'','','','','','');

  TournamentsList: any[];
  loadTournamentList() {
    this.serviceShared.getTournaments().subscribe(data => {
        this.TournamentsList = data;
       
        this.model.EventID = this.eve.eventID;
        this.model.FK_TournamentID = this.eve.fK_TournamentID;
        this.model.EventName = this.eve.eventName;
        this.model.EventNumber = this.eve.eventNumber;
        this.model.EventDateTime = this.eve.eventDateTime;
        this.model.EventEndDateTime = this.eve.eventEndDateTime;
        this.model.AutoClose = this.eve.autoClose;

    });
  }

  ngOnInit(): void {
      console.log("hello: " + this.eve.fK_TournamentID);
    this.loadTournamentList();
  }
  addEvent() {
    console.log("Add " + this.EventID);

    let val = {
        EventID: this.model.EventID,
        FK_TournamentID: parseInt(this.model.FK_TournamentID),
        EventName: this.model.EventName,
        EventNumber: parseInt(this.model.EventNumber),
        EventDateTime: this.model.EventDateTime,
        EventEndDateTime: this.model.EventEndDateTime,
        AutoClose: this.model.AutoClose === "true",
    };
    console.log(val);
    this.service.addEvent(val).subscribe(res => {
     // alert(res.toString());
      //document.querySelector('.close');
      let element: HTMLElement = document.querySelector('.close') as HTMLElement;
      element.click();
    });
  }

  updateEvent(id) {
    let val = {
      EventID: id,
        FK_TournamentID: parseInt(this.model.FK_TournamentID),
        EventName: this.model.EventName,
        EventNumber: parseInt(this.model.EventNumber),
        EventDateTime: this.model.EventDateTime,
        EventEndDateTime: this.model.EventEndDateTime,
        AutoClose: this.model.AutoClose === "true",
    };
    console.log(val);
    this.service.updateEvent(id, val).subscribe(res => {
      //alert(res.toString());
      //alert("Update Successful");
      //document.querySelector('.close');
      let element: HTMLElement = document.querySelector('.close') as HTMLElement;
      element.click();
    });
  }

    submitted = false;

    onSubmit() { this.submitted = true; }
}

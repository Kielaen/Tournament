import { Component, OnInit, Input } from '@angular/core';
import { EventService } from 'src/app/services/event.service';
import { SharedService } from 'src/app/services/shared.service';
import { EventDetail } from 'src/app/classes/EventDetail';
declare var jquery: any;

@Component({
  selector: 'app-add-edit-event-details',
  templateUrl: './add-edit-event-details.component.html',
  styleUrls: ['./add-edit-event-details.component.css']
})
export class AddEditEventDetailsComponent implements OnInit {

  constructor(private service: SharedService,private serviceEvent: EventService) { }

  @Input() eventdetail: any;
  
  EventDetailID: number;
    Event: string;
  EventDetailStatus: string;
  EventDetailName: string;
  EventDetailNumber: string;
  EventDetailOdd: string;
  FinishingPosition: string;
  FirstTimer: string;

    model = new EventDetail(0, '', '', '', '', '', '', 'true');

  StatusList: any[];
  loadStatusList() {
    this.service.getEventDetailStatuses().subscribe(data => {
      this.StatusList = data;
    });
  }
  EventList: any[];
  loadEventList() {
    this.serviceEvent.getEvents().subscribe(data => {
        this.EventList = data;
       
        this.model.EventDetailID = this.eventdetail.eventDetailID;
        this.model.FK_EventID = this.eventdetail.fK_EventID;
        this.model.FK_EventDetailStatusID = this.eventdetail.fK_EventDetailStatusID;
        this.model.EventDetailName = this.eventdetail.eventDetailName;
        this.model.EventDetailNumber = this.eventdetail.eventDetailNumber;
        this.model.EventDetailOdd = this.eventdetail.eventDetailOdd;
        this.model.FinishingPosition = this.eventdetail.finishingPosition;
        this.model.FirstTimer = this.eventdetail.firstTimer;
        this.loadStatusList();
    });
  }

 

  ngOnInit(): void {
    //console.log(this.eve.EventID);
   
    this.loadEventList();
   
    //console.log("jjj " + this.EventList);
  }
  addEventDetail() {
    //console.log("Add " + this.EventID);

    let val = {
        EventDetailID: this.model.EventDetailID,
        FK_EventID: parseInt(this.model.FK_EventID),
        FK_EventDetailStatusID: parseInt(this.model.FK_EventDetailStatusID),
        EventDetailName: this.model.EventDetailName,
        EventDetailNumber: this.model.EventDetailNumber,
        EventDetailOdd: this.model.EventDetailOdd,
        FinishingPosition: this.model.FinishingPosition,
        FirstTimer: this.model.FirstTimer === "true"
    };
    console.log(val);
    this.service.addEventDetail(val).subscribe(res => {
      //alert(res.toString());
      //document.querySelector('.close');
      let element: HTMLElement = document.querySelector('.close') as HTMLElement;
      element.click();
    });
  }

  updateEventDetail(id) {
    let val = {
        EventDetailID: this.model.EventDetailID,
        FK_EventID: parseInt(this.model.FK_EventID),
        FK_EventDetailStatusID: parseInt(this.model.FK_EventDetailStatusID),
        EventDetailName: this.model.EventDetailName,
        EventDetailNumber: this.model.EventDetailNumber,
        EventDetailOdd: this.model.EventDetailOdd,
        FinishingPosition: this.model.FinishingPosition,
        FirstTimer: this.model.FirstTimer === "true"
    };
    console.log(val);
    this.service.updateEventDetail(id, val).subscribe(res => {
      //alert(res.toString());
      //alert("Update Successful");
      //document.querySelector('.close');
      //jquery('.close').trigger('click');
      let element: HTMLElement = document.querySelector('.close') as HTMLElement;
      element.click();
    });
  }

  submitted = false;

  onSubmit() { this.submitted = true; }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.model); }
}

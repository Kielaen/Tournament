import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { EventDetail } from 'src/app/classes/EventDetail';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { interval  } from 'rxjs';
import { map, tap } from 'rxjs/operators';


@Component({
  selector: 'app-show-event-details',
  templateUrl: './show-event-details.component.html',
  styleUrls: ['./show-event-details.component.css']
})
export class ShowEventDetailsComponent implements OnInit {
  @Input() details$: Observable<any>;
    public isAuthenticated: Observable<boolean>;
    public userName: Observable<string>;

    constructor(private service: SharedService, private authorizeService: AuthorizeService) { }

  EventDetailList: any[];
  StatusList: any[];

    ngOnInit(): void {
        this.isAuthenticated = this.authorizeService.isAuthenticated();
      this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
      
        //console.log(this.isAuthenticated);
    this.refreshEventDetailList();
  }
  ModalTitle: string;
  ActivateAddEditEventDetail: boolean;
    eventdetail: EventDetail;

  TournamentIdFilter: string = "";
  TournamentNameFilter: string = "";
  TournamentListWithoutFilter: any = [];

  addEventDetail() {

    this.eventdetail = {
      EventDetailID: 0,
      FK_EventID: "",
      FK_EventDetailStatusID: "",
      EventDetailName: "",
      EventDetailNumber: "0",
      EventDetailOdd: "0.00",
      FinishingPosition: "0",
      FirstTimer: "false"
    };
    this.ModalTitle = "Add Tournament";
    this.ActivateAddEditEventDetail = true;
    //console.log(this.ActivateAddEditTournament);
  }
  editEventDetail(eventdetail) {
      console.log(eventdetail);
    this.eventdetail = eventdetail;
    this.ModalTitle = "Edit Event Detail";
    this.ActivateAddEditEventDetail = true;
  }
  closeClick() {
    this.ActivateAddEditEventDetail = false;
    this.refreshEventDetailList();
  }

  deleteEventDetail(eventdetail) {
    if (confirm("Are you sure?")) {
      this.service.deleteEventDetail(eventdetail.eventDetailID).subscribe(res => {
        alert("Delete Successfull");
        this.refreshEventDetailList();
      });
    }
  }

  refreshEventDetailList() {

    //this.details$ = Observable
    //  .startWith(0).switchMap(() => this.service.getEventDetails().subscribe(data => {
    //    this.EventDetailList = data;
    //    this.TournamentListWithoutFilter = data;
    //  }));
    interval(1000).subscribe(() => this.service.getEventDetails().subscribe(data => {
      this.EventDetailList = data;
      this.TournamentListWithoutFilter = data;
    }));
    //this.service.getEventDetails().subscribe(data => {
    //  this.EventDetailList = data;
    //  this.TournamentListWithoutFilter = data;
    //});
  }

  FilterFn() {
    var TournamentIdFilter = this.TournamentIdFilter;
    var TournamentNameFilter = this.TournamentNameFilter;

    this.EventDetailList = this.TournamentListWithoutFilter.filter(function (el) {
      return el.tournamentID.toString().toLowerCase().includes(
        TournamentIdFilter.toString().trim().toLowerCase()
      ) &&
        el.tournamentName.toString().toLowerCase().includes(
          TournamentNameFilter.toString().trim().toLowerCase()
        )
    });
  }

}

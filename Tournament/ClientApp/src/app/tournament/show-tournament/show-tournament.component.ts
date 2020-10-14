import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
import { AuthorizeService } from 'src/api-authorization/authorize.service';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-show-tournament',
  templateUrl: './show-tournament.component.html',
  styleUrls: ['./show-tournament.component.css']
})
export class ShowTournamentComponent implements OnInit {
  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;

  constructor(private service: SharedService, private authorizeService: AuthorizeService) { }

  TournamentList: any[];

  ngOnInit(): void {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.refreshTournamentList();
  }
  ModalTitle: string;
  ActivateAddEditTournament: boolean;
  tournament: any;

  TournamentIdFilter: string= "";
  TournamentNameFilter: string = "";
  TournamentListWithoutFilter: any = [];
  addTournament() {
   
    this.tournament = {
      TournamentID: 0,
      TournamentName:""
    }
    this.ModalTitle = "Add Tournament";
    this.ActivateAddEditTournament = true;
    //console.log(this.ActivateAddEditTournament);
  }
  editTournament(tournament) {
    //console.log(tournament);
    this.tournament = tournament;
    this.ModalTitle = "Edit Tournament";
    this.ActivateAddEditTournament = true;
  }
  closeClick() {
    this.ActivateAddEditTournament = false;
    this.refreshTournamentList();
  }

  deleteTournament(tournament) {
    if (confirm("Are you sure?")) {
      this.service.deleteTournament(tournament.tournamentID).subscribe(res => {
        alert("Success");
        this.refreshTournamentList();
      });
    }
  }

  refreshTournamentList() {
    this.service.getTournaments().subscribe(data => {
      this.TournamentList = data;
      this.TournamentListWithoutFilter = data;
    });
  }

  FilterFn() {
    var TournamentIdFilter = this.TournamentIdFilter;
    var TournamentNameFilter = this.TournamentNameFilter;

    this.TournamentList = this.TournamentListWithoutFilter.filter(function (el) {
      return el.tournamentID.toString().toLowerCase().includes(
        TournamentIdFilter.toString().trim().toLowerCase()
      ) &&
        el.tournamentName.toString().toLowerCase().includes(
          TournamentNameFilter.toString().trim().toLowerCase()
          )
    });
  }
}

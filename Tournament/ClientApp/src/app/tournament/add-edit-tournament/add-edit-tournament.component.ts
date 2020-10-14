import { Component, OnInit, Input } from '@angular/core';
import { SharedService } from 'src/app/services/shared.service';
//import * as jQuery from 'jquery';

@Component({
  selector: 'app-add-edit-tournament',
  templateUrl: './add-edit-tournament.component.html',
  styleUrls: ['./add-edit-tournament.component.css']
})
export class AddEditTournamentComponent implements OnInit {
 
  constructor(private service: SharedService) { }
  @Input() tournament: any;
  TournamentID: number;
  TournamentName: string;
  ngOnInit(): void {
   
    this.TournamentID = this.tournament.tournamentID;
    this.TournamentName = this.tournament.tournamentName;
    console.log(this.TournamentName);
  }
  addTournament() {
    let val = {
      TournamentID: this.TournamentID,
      TournamentName: this.TournamentName
    };
    this.service.addTournament(val).subscribe(res => {
      //alert(res.toString());
      //document.querySelector('.close');
      let element: HTMLElement = document.querySelector('.close') as HTMLElement;
      element.click();
    });
  }
  updateTournament(id) {
    let val = {
      TournamentID: id,
      TournamentName: this.TournamentName
    };
    console.log(id);
    this.service.updateTournament(val.TournamentID, val).subscribe(res => {
      //$('#exampleModal').modal('hide');
     // alert(res.toString())
     // alert("Update Successful");
     // document.querySelector('.close');
      let element: HTMLElement = document.querySelector('.close') as HTMLElement;
      element.click();
    });
    
      }

}

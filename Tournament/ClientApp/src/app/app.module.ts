import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { EventFormComponent } from './event-form/event-form.component';
import { EventService } from './services/event.service';
import { ShowEventComponent } from './event-form/show-event/show-event.component';
import { AddEditEventComponent } from './event-form/add-edit-event/add-edit-event.component';
import { TournamentComponent } from './tournament/tournament.component';
import { ShowTournamentComponent } from './tournament/show-tournament/show-tournament.component';
import { AddEditTournamentComponent } from './tournament/add-edit-tournament/add-edit-tournament.component';
import { EventDetailsComponent } from './event-details/event-details.component';
import { ShowEventDetailsComponent } from './eventDetails/show-event-details/show-event-details.component';
import { AddEditEventDetailsComponent } from './eventDetails/add-edit-event-details/add-edit-event-details.component';
import { EventDetailStatusComponent } from './event-detail-status/event-detail-status.component';
import { SharedService } from './services/shared.service';
import { AuthorizeService } from 'src/api-authorization/authorize.service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    EventFormComponent,
    ShowEventComponent,
    AddEditEventComponent,
    TournamentComponent,
    ShowTournamentComponent,
    AddEditTournamentComponent,
    EventDetailsComponent,
    ShowEventDetailsComponent,
    AddEditEventDetailsComponent,
    EventDetailStatusComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      //{ path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'event', component: EventFormComponent },
      { path: 'event-detail', component: EventDetailsComponent },
      { path: '', component: TournamentComponent },
      { path: 'event-detail-status', component: EventDetailStatusComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
      { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }, EventService, SharedService, AuthorizeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

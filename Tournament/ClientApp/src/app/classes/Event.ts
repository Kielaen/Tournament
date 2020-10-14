export class Event {
    constructor(
        public EventID: number,
        public FK_TournamentID: string,
        public EventName: string,
        public EventNumber: string,
        public EventDateTime: string,
        public EventEndDateTime: string,
        public AutoClose: string
    ) { }

}

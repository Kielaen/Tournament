export class EventDetail {  
    constructor(
        public EventDetailID: number,
        public FK_EventID: string,
        public FK_EventDetailStatusID: string,
        public EventDetailName: string,
        public EventDetailNumber: string,
        public EventDetailOdd: string,
        public FinishingPosition: string,
        public FirstTimer: string,
    ) { }

}

"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Event = void 0;
var Event = /** @class */ (function () {
    function Event(EventID, FK_TournamentID, EventName, EventNumber, EventDateTime, EventEndDateTime, AutoClose) {
        this.EventID = EventID;
        this.FK_TournamentID = FK_TournamentID;
        this.EventName = EventName;
        this.EventNumber = EventNumber;
        this.EventDateTime = EventDateTime;
        this.EventEndDateTime = EventEndDateTime;
        this.AutoClose = AutoClose;
    }
    return Event;
}());
exports.Event = Event;
//# sourceMappingURL=Event.js.map
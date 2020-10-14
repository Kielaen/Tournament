"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EventDetail = void 0;
var EventDetail = /** @class */ (function () {
    function EventDetail(EventDetailID, FK_EventID, FK_EventDetailStatusID, EventDetailName, EventDetailNumber, EventDetailOdd, FinishingPosition, FirstTimer) {
        this.EventDetailID = EventDetailID;
        this.FK_EventID = FK_EventID;
        this.FK_EventDetailStatusID = FK_EventDetailStatusID;
        this.EventDetailName = EventDetailName;
        this.EventDetailNumber = EventDetailNumber;
        this.EventDetailOdd = EventDetailOdd;
        this.FinishingPosition = FinishingPosition;
        this.FirstTimer = FirstTimer;
    }
    return EventDetail;
}());
exports.EventDetail = EventDetail;
//# sourceMappingURL=EventDetail.js.map
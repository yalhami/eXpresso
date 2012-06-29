function ShowCalendarEvents(yselect, mselect, dselect, CategoryID, dvEventloadingClientID, pnlEventDataClientID, lbtnEventClientID, pnlEventClientID) {
    var dvEventloading = document.getElementById(dvEventloadingClientID);
    dvEventloading.style.display = "block";

    var callWebService = new TGExpressCMSServices.EventWebService();
    callWebService.GetHtmlEventItems(yselect, mselect, dselect, CategoryID, updateEventData, updateEventError, dvEventloadingClientID + "|" + pnlEventDataClientID);

    var dvEvent = document.getElementById(pnlEventDataClientID);
    dvEvent.innerHTML = "";

    var pnlEvent = document.getElementById(pnlEventClientID);
    pnlEvent.style.display = '';

    var mpInviteClientID = document.getElementById(lbtnEventClientID);
    mpInviteClientID.click();

    return false;
}
function updateEventError(result) {
}
function updateEventData(result, ControlClientsID) {
    var dvEventloadingClientID = ControlClientsID.split('|')[0];
    var pnlEventDataClientID = ControlClientsID.split('|')[1];

    var dvEventloading = document.getElementById(dvEventloadingClientID);
    dvEventloading.style.display = "none";

    var dvEvent = document.getElementById(pnlEventDataClientID);
    dvEvent.innerHTML = result;
}
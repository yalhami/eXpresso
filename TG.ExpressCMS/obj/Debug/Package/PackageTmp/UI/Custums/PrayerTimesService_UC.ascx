<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrayerTimesService_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.Custums.PrayerTimesService_UC" %>
<script type="text/javascript">

    function LoadEvents() {
        var loader = document.getElementById('<%=dvLoader.ClientID %>');

        loader.style.display = "block";
        var xObj = new TGExpressCMSServices.PrayerTimesWebService();

        xObj.ExecutePrayerTimes("12", result);

        return false;
    }
    function result(htmlres) {

        var loader = document.getElementById('<%=dvLoader.ClientID %>');
        var dvdata = document.getElementById("<%=dvData.ClientID %>");
        dvdata.innerHTML = htmlres; loader.style.display = "none";
    }
    Sys.Application.add_init(function () {
        LoadEvents();
    });
</script>
<div id="dvLoader" runat="server" style="display: none;">
    <img src="../../App_Themes/AdminSide/images/ajax-loader(2).gif" alt="" />
</div>
<div runat="server" id="dvData">
</div>

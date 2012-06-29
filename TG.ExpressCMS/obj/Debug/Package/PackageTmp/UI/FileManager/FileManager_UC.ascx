<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileManager_UC.ascx.cs"
    Inherits="TG.ExpressCMS.UI.FileManager.FileManager_UC" %>
<telerik:RadCodeBlock ID="codeBlock1" runat="server">
    <script type="text/javascript">
            //<![CDATA[
        function OnClientItemSelected(sender, args) {
            var pvwImage = $get("<%= pvwImage.ClientID %>");
            var imageSrc = args.get_path();

            if (imageSrc.match(/\.(gif|jpg)$/gi)) {
                pvwImage.src = imageSrc;
                pvwImage.style.display = "";
                pvwImage.alt = imageSrc.substring(imageSrc.lastIndexOf('/') + 1);
            }
            else {
                pvwImage.src = imageSrc;
                pvwImage.style.display = "none";
                pvwImage.alt = imageSrc.substring(imageSrc.lastIndexOf('/') + 1);
            }
        }
            //]]>
    </script>
</telerik:RadCodeBlock>
<table>
    <tr>
        <td style="width: 80%">
            <telerik:RadFileExplorer runat="server" ID="fmanager" Width="620" DisplayUpFolderItem="true"
                EnableCreateNewFolder="false" PageSize="25" Height="420px" OnClientItemSelected="OnClientItemSelected">
                <configuration viewpaths="~/Upload/UserUploads" uploadpaths="~/Upload/UserUploads"
                    deletepaths="~/Upload/UserUploads" maxuploadfilesize="20000000" />
            </telerik:RadFileExplorer>
        </td>
        <td>
            <fieldset style="width: 230px; height: 220px">
                <legend>Preview</legend>
                <img id="pvwImage" src="~/App_Themes/AdminSide2/Images/qsfConfigPixel.gif" runat="server"
                    alt="~/App_Themes/AdminSide2/Images/qsfConfigPixel.gif" style="display: none;
                    margin: 10px; width: 200px; height: 180px; vertical-align: middle;" />
            </fieldset>
        </td>
    </tr>
</table>

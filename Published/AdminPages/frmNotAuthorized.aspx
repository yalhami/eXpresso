<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/AdminMasterPage.master" AutoEventWireup="true" CodeBehind="frmNotAuthorized.aspx.cs" Inherits="TG.ExpressCMS.AdminPages.frmNotAuthorized" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-weight: bold;
            font-size: x-large;
            color: #CC3300;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p class="style1">
        NOT AUTHORIZED TO ACCESS THIS PAGE</p>
</asp:Content>

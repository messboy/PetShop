<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="MVCweb.Items" %>
<%@ Register Src="Controls/ItemsControl.ascx" TagName="ItemsControl" TagPrefix="PetShopControl" %>

<asp:Content ID="cntPage" runat="Server" ContentPlaceHolderID="cphPage" EnableViewState="false">
    <PetShopControl:ItemsControl ID="ItemsControl1" runat="server" />
</asp:Content>


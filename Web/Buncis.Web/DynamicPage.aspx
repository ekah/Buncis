<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Content.Master" AutoEventWireup="true"
    CodeBehind="DynamicPage.aspx.cs" Inherits="Buncis.Web.DynamicLogicPage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:PlaceHolder runat="server" ID="plcBodyContent"></asp:PlaceHolder>
</asp:Content>

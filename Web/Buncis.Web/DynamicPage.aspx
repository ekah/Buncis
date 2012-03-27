<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true"
    CodeBehind="DynamicPage.aspx.cs" Inherits="Buncis.Web.DynamicPage" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="bodyContent" ContentPlaceHolderID="MainPlaceHolder" runat="server">
    <asp:Literal runat="server" ID="ltrBodyContent"></asp:Literal>
</asp:Content>

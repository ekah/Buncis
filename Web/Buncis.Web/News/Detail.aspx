<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomTwoColumns.Master" AutoEventWireup="true"
	CodeBehind="Detail.aspx.cs" Inherits="Buncis.Web.News.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
	<h1 class="newsdetail-title"><asp:Literal runat="server" ID="ltrNewsTitle"></asp:Literal></h1>
	<div class="newsdetail-info"><asp:Literal runat="server" ID="ltrNewsInfo"></asp:Literal></div>
	<br/>
	<div class="newsdetail-content"><asp:Literal runat="server" ID="ltrContent"></asp:Literal></div>
</asp:Content>

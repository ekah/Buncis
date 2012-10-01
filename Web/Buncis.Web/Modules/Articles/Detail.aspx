<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomTwoColumns8s.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Buncis.Web.Modules.Articles.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
	<div class="box-content">
		<h1 class="articledetail-title"><asp:Literal runat="server" ID="ltrArticleTitle"></asp:Literal></h1>
		<div class="articledetail-info"><asp:Literal runat="server" ID="ltrArticleInfo"></asp:Literal></div>
		<br/>
		<asp:Literal runat="server" ID="ltrSocial"></asp:Literal>
		<div class="clearfix"></div>
		<br/>
		<div class="articledetail-content"><asp:Literal runat="server" ID="ltrContent"></asp:Literal></div>
	</div>
</asp:Content>

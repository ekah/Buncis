<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomTwoColumns.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Buncis.Web.DailyBread.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
	<h1 class="dailybreaddetail-title"><asp:Literal runat="server" ID="ltrTitle"></asp:Literal></h1>
	<div class="dailybreaddetail-info"><asp:Literal runat="server" ID="ltrInfo"></asp:Literal></div>
	<br/>
	<div class="dailybreaddetail-bible">
		<blockquote>
			<span><strong><asp:Literal runat="server" ID="ltrBible"></asp:Literal></strong></span>
			<div><asp:Literal runat="server" ID="ltrBibleContent"></asp:Literal></div>
		</blockquote>
	</div>
	<br/>
	<div class="dailybreaddetail-content"><asp:Literal runat="server" ID="ltrContent"></asp:Literal></div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomTwoColumns8s.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="Buncis.Web.Modules.DailyBread.Detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
	<div class="box-content">
		<h1 class="dailybreaddetail-title"><asp:Literal runat="server" ID="ltrTitle"></asp:Literal></h1>
		<div class="dailybreaddetail-info"><asp:Literal runat="server" ID="ltrInfo"></asp:Literal></div>
		<br/>
		<asp:Literal runat="server" ID="ltrSocial"></asp:Literal>
		<div class="clearfix"></div>
		<br/>
		<div class="dailybreaddetail-bible">
			<blockquote>
				<asp:Literal runat="server" ID="ltrBible"></asp:Literal>
				<br/>
				<asp:Literal runat="server" ID="ltrBibleContent"></asp:Literal>
			</blockquote>
		</div>
		<br/>
		<div class="dailybreaddetail-content"><asp:Literal runat="server" ID="ltrContent"></asp:Literal></div>
	</div>
</asp:Content>

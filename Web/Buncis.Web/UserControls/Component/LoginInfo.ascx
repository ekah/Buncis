<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginInfo.ascx.cs" Inherits="Buncis.Web.UserControls.Component.LoginInfo" %>

<div class="btn-group">
	<button class="btn"><span id="loginInfoUsername" runat="server" clientidmode="Static"></span></button>
	<button class="btn dropdown-toggle" data-toggle="dropdown">
		<span class="caret"></span>
	</button>
	<ul class="dropdown-menu">
		<li><a href="/bPanel/Account/Logout.aspx">Logout</a></li>
	</ul>
</div>
<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Custom.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Buncis.Web.Home" %>

<%@ Register tagPrefix="bun" tagName="RecentNews" src="/UserControls/News/RecentNews.ascx" %>
<%@ Register tagPrefix="bun" tagName="RecentArticles" src="/UserControls/Articles/RecentArticles.ascx" %>
<%@ Register tagPrefix="bun" tagName="RecentDailyBread" src="/UserControls/DailyBread/RecentDailyBread.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RowOne" runat="server">
	<bun:RecentDailyBread runat="server" ID="recentDailyBread" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RowTwoLeftSection" runat="server">
	<bun:RecentNews runat="server" ID="recentNews" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="RowTwoRightSection" runat="server">
	<bun:RecentArticles runat="server" ID="recentArticles" />	
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/BMCustom.Master" AutoEventWireup="true" CodeBehind="HomeBM.aspx.cs" Inherits="Buncis.Web.HomeBM" %>

<%@ Register tagPrefix="bun" tagName="RecentNews" src="/UserControls/News/RecentNews.ascx" %>
<%@ Register tagPrefix="bun" tagName="RecentArticles" src="/UserControls/Articles/RecentArticles.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="RowOneLeftBox" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="RowOneRightBox" runat="server">
	<bun:RecentArticles runat="server" ID="recentArticles" />	
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="RowTwoLeftSection" runat="server">
	<bun:RecentNews runat="server" ID="recentNews" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="RowTwoRightSection" runat="server">
</asp:Content>

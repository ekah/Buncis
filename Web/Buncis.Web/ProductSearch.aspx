<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProductSearch.aspx.cs" Inherits="Buncis.Web.ProductSearch" %>

<%@ Register TagName="ProductSearch" TagPrefix="buncis" Src="~/UserControls/ProductSearch.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <buncis:ProductSearch runat="server" ID="productSearch1"></buncis:ProductSearch>
</asp:Content>
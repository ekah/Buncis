<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.Buncis.Pages.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="buncisContentHeader">
        <h3>Dynamic Pages</h3>
    </div>
    <div class="buncisContentBody">
        <asp:Repeater runat="server" ID="rptPages">
            <ItemTemplate>
                <span><%# Eval("PageName") %></span>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

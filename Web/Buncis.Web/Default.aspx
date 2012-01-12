<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Buncis.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <div>
        <asp:Literal runat="server" ID="ltrTest"></asp:Literal>
        <br />
        <asp:Button ID="randomize1" Text="Randomize 1" runat="server" />
        <asp:Button ID="randomize2" Text="Randomize 2" runat="server" />
        <asp:Button ID="randomize3" Text="Randomize 3" runat="server" />
        <asp:Button ID="randomize4" Text="Randomize 4" runat="server" />
        <br />
        <asp:Button ID="btnComplete" Text="Complete" runat="server" />
        <asp:Button ID="btnCancel" Text="Cancel" runat="server" />
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.News.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script type="text/javascript">
   	
        (function (pages) {
            pages._elems = {
                clientId: <%= CurrentProfile.ClientId %>,
                
            };
        }(window._news = window._news || {}));

    </script>
	<script src="/Scripts/bunx/ember/ember-0.9.8.1.js" type="text/javascript"></script>
    <script src="/Scripts/bunx/_act_news.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	 <div class="buncisContentHeader">
        <h3>News</h3>
    </div>
    <div class="buncisContentBody">
        <div class="actionContent">
            
        </div>
        <div class="innerContent">
            
        </div>
    </div>

   
</asp:Content>

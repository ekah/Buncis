<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.News.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script type="text/javascript">
   	
        (function (pages) {
            pages._elems = {
                clientId: <%= CurrentProfile.ClientId %>,
                
            };
        }(window._news = window._news || {}));

    </script>

    <script src="/Scripts/bunx/ember/handlebars-1.0.0.beta.6.js" type="text/javascript"></script>
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
            <script type="text/x-handlebars" data-template-name="news-list">
		      <h2>My News</h2>
		      <ul>
		        {{#each News.newsListController}}
		          {{#view News.NewsListView contentBinding="this"}}
		            {{#with content}}
		              <li><span>{{ newsTitle }}</span></li>              
		            {{/with}}
		          {{/view}}
		        {{/each}}
		      </ul>    
		    </script>
        </div>
    </div>

   
</asp:Content>

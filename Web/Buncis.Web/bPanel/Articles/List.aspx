<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Articles.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_articles.js" type="text/javascript"></script>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div class="buncisContentHeader">
        <h3>Articles</h3>
    </div>
    <div class="buncisContentBody">
        <div class="actionContent">
            <a href="javascript:void(0);" id="aAddArticle" class="button-action addArticle">
                <span class="icon-plus">Add Article</span>
            </a>
        </div>
        <div class="innerContent">
			<ul class="article-list" id="article-list-container">
								
			</ul>
        </div>
    </div>
	
	<div style="display:none">
        <script type="text/template" id="article-item-template">
            <li class="article-item-wrapper" rel="{{cid}}">
				<div class="article-item list-item">
					<div class="left leftSection">
						<div class="article-title">{{attributes.articleTitle}}</div>
						<div class="article-teaser">[TEASER HERE]</div>
						<div class="article-info">
							<div>[INFO HERE]</div>
							<div>[INFO HERE 2]</div>
						</div>
					</div>
					<div class="left rightSection">
						<div class="list-action">
							<a href="javascript:;" class="action action-delete delete">Delete</a>
							<a href="javascript:;" class="action action-edit edit">Edit</a>
							<div class="clearFloats"></div>
						</div>
					</div>
					<div class="clearFloats"></div>
				</div>				
			</li>
        </script>
		<script type="text/template" id="article-edit-template">
			<div>
				<a href="#" class="close-view-area">Cancel</a>
				<a href="#">Save</a>
			</div>
			<div>
				<label>Article Title:</label>					
				<input type="text" id="txtArticleTitle" name="txtArticleTitle"></input>
			</div>
			<div>
				<label>Article Teaser:</label>
				<input type="text" id="txtArticleTeaser" name="txtArticleTeaser"></input>
			</div>				
			<div>
				<label>Friendly Url:</label>
				<input type="text" id="txtArticleUrl" name="txtArticleUrl"></input>
			</div>
			<div>
				<label>Article Content:</label>
				<textarea id="txtArticleContent" name="txtArticleContent"></textarea>
			</div>		
		</script>		
		<div id="article-edit-section">
			
		</div>
	</div>
</asp:Content>

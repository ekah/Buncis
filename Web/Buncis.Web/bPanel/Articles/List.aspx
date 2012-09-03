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
            <div class="add-item-container"></div>
			<ul class="article-list" id="article-list-container">
								
			</ul>
        </div>
    </div>
	
	<div style="display:none">
        <script type="text/template" id="article-item-template">
            <li class="article-item-wrapper" rel="{{id}}">
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
                <div class="edit-item-container">
                </div>             
			</li>            
        </script>
		<script type="text/template" id="article-edit-template">
            <hr/>
            <div class="article-edit-form standard-form">
			    <div class="">
			        <div class="form-item">
				        <label>Article Title:</label>					
				        <input type="text" id="txtArticleTitle-{{id}}" name="txtArticleTitle-{{id}}" 
                            class="x-long" required="required"
                            value="{{attributes.articleTitle}}"
                            data-message="Article Title is required"></input>
			        </div>
			        <div class="form-item">
				        <label>Article Teaser:</label>
				        <textarea id="txtArticleTeaser-{{id}}" name="txtArticleTeaser-{{id}}" 
                            style="width:700px; height: 100px;"
                            required="required"
                            data-message="Article Teaser is required">{{attributes.articleTeaser}}</textarea>
			        </div>				
			        <div class="form-item">
				        <label>Friendly Url:</label>
				        <input type="text" id="txtArticleUrl-{{id}}" name="txtArticleUrl-{{id}}" 
                            class="long" required="required"
                            value="{{attributes.articleUrl}}"
                            data-message="Article Url is required"></input>
			        </div>
			        <div class="form-item hasHtmlArea">
				        <label>Article Content:</label>
				        <textarea id="txtArticleContent-{{id}}" name="txtArticleContent-{{id}}" 
                            style="width:800px;"
                            class="htmlarea" required="required"
                            data-message="Article Content is required">{{attributes.articleContent}}</textarea>
			        </div>		
                </div>
                <div class="buttonContainer">
				    <a href="javascript:;" class="close-view-area button-whiteOnRed">Cancel</a>
				    <a href="javascript:;" class="btnSave button-whiteOnGreen">Save</a>
			    </div>
                <div class="clearFloats"></div>
            </div>
		</script>		
		<div id="article-edit-section">
			
		</div>
        <div id="article-delete-popup" class="popup-wrapper"></div>
        <script type="text/template" id="article-confirmDelete-popup-template">
			<p>Are you sure you want to delete article <strong>{{attributes.articleTitle}}</strong>?</p>
			<div class="popup-button-wrapper buttonContainer">
        	    <a href="javascript:;" id="deleteArticle-cancel" class="button-whiteOnBlack popup-button-close">No</a>
                <a href="javascript:;" id="deleteArticle-confirm" class="button-whiteOnRed">Yes</a>			    
            </div>
		</script>
	</div>
</asp:Content>

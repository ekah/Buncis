<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Articles.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_articles.js" type="text/javascript"></script>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div id="homeSection" class="row">
		<div class="span12">
			<div class="buncisContentHeader well well-small">
				<h3>Articles</h3>	
			</div>
		</div>	
		<div class="span12">
			<div class="buncisContentBody well well-small">
				<div class="actionContent">
					<a href="javascript:void(0);" id="aAddArticle" class="btn btn-warning addArticle">
						<span class="icon-plus">Add Article</span>
					</a>
				</div>
				<div class="innerContent">
					<ul class="list-item-container" id="article-list-container">
								
					</ul>
				</div>
			</div>
		</div>
	</div>
	
	<div id="article-edit-section" class="row"></div>
	<div id="article-delete-popup" class="popup-wrapper modal hide fade"></div>

	<div style="display:none">
		<script type="text/template" id="article-item-template">
			<li class="list-item" rel="{{id}}">
				<div class="">
					<div class="pull-left leftSection">
						<div class=""><strong>{{attributes.articleTitle}}</strong></div>
						<div class="">{{attributes.articleTeaser}}</div>
						<div class="">
							
						</div>
					</div>
					<div class="pull-right rightSection">
						<div class="list-action">
							<a href="javascript:;" class="action edit btn btn-info">Edit</a>
							<a href="javascript:;" class="action delete btn btn-danger">Delete</a>
						</div>
					</div>
					<div class="clearfix"></div>
				</div>
			</li>
		</script>

		<script type="text/template" id="article-edit-template">
			<div class="span12">
				<div class="buncisContentHeader well well-small">
					<h3>Modal header</h3>
				</div>
			</div>
			<div class="span12">
				<div class="buncisContentBody well well-small">
					<div class="form-item">
						<label>Article Title:</label>					
						<input type="text" id="txtArticleTitle-{{id}}" name="txtArticleTitle-{{id}}" 
							class="input-xxlarge" value="{{attributes.articleTitle}}"
							required="required" data-message="Article Title is required"></input>
					</div>
					<div class="form-item">
						<label>Article Teaser:</label>
						<textarea id="txtArticleTeaser-{{id}}" name="txtArticleTeaser-{{id}}" 
							cols="120" rows="6"
							required="required"
							data-message="Article Teaser is required">{{attributes.articleTeaser}}</textarea>
					</div>				
					<div class="form-item">
						<label>Friendly Url:</label>
						<input type="text" id="txtArticleUrl-{{id}}" name="txtArticleUrl-{{id}}" 
							class="input-xlarge" value="{{attributes.articleUrl}}"
							required="required" data-message="Article Url is required"></input>
					</div>
					<div class="form-item hasHtmlArea">
						<label>Article Content:</label>
						<textarea id="txtArticleContent-{{id}}" name="txtArticleContent-{{id}}" 
							cols"45" row="150"
							class="htmlarea" required="required"
							data-message="Article Content is required">{{attributes.articleContent}}</textarea>
					</div>		
				</div>
			</div>	
			<div class="span12">
				<div class="well well-small buncisButtonContainer">
					<div class="pull-right">
						<a href="javascript:;" class="btnSave btn btn-primary">Save</a>
						<a href="javascript:;" class="close-view-area btn btn-error">Close</a>
					</div>
				</div>
			</div>
		</script>
		
		<script type="text/template" id="article-confirmDelete-popup-template">
			<div class="modal-header">
				<h3>Modal header</h3>
			</div>
			<div class="modal-body popup-content-small">
				<p>Are you sure you want to delete article <strong>{{attributes.articleTitle}}</strong>?</p>
			</div>
			<div class="buttonContainer modal-footer">				
				<a href="javascript:;" id="deleteArticle-confirm" class="btn btn-primary">Yes</a>			    
				<a href="javascript:;" id="deleteArticle-cancel" class="popup-button-close btn btn-inverse">No</a>
			</div>
		</script>
	</div>
</asp:Content>

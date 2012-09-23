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
				<div class="actionContent pull-right">
					<a href="#" id="aAddArticle" class="btn btn-warning">
						<i class="icon-plus"></i>&nbsp;<span>Add Article</span>
					</a>
				</div>
				<div class="clearfix"></div>
				<ul class="list-item-container" id="article-list-container">
								
				</ul>
			</div>
		</div>
	</div>
	
	<div id="article-edit-section" class="row"></div>
	<div id="article-delete-popup" class="popup-wrapper modal hide fade"></div>

	<div style="display:none">
		<script type="text/template" id="article-item-template">
			<li class="list-item" rel="{{id}}">
				<div class="row-fluid">
					<div class="span10 leftSection">
						<div class=""><strong>{{attributes.articleTitle}}</strong></div>
						<div class="">{{attributes.articleTeaser}}</div>
						<div class=""></div>
					</div>
					<div class="span1 rightSection">
						<div class="btn-toolbar">
							<div class="btn-group">
								<button class="btn btn-info">Action</button>
								<button class="btn btn-info dropdown-toggle" data-toggle="dropdown">
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu">
									<li><a href="#" class="action edit">Edit</a></li>
									<li><a href="#" class="action delete">Delete</a></li>
								</ul>
							</div>
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
					<div class="row">
						<div class="form-item span11">
							<label>Article Title:</label>					
							<textarea type="text" id="txtArticleTitle-{{id}}" name="txtArticleTitle-{{id}}" 
								class="span10" cols="120" rows="3"
								required="required" data-message="Article Title is required">{{attributes.articleTitle}}</textarea>
						</div>
						<div class="form-item span11">
							<label>Article Teaser:</label>
							<textarea id="txtArticleTeaser-{{id}}" name="txtArticleTeaser-{{id}}" 
								cols="120" rows="6" class="span10"
								required="required"
								data-message="Article Teaser is required">{{attributes.articleTeaser}}</textarea>
						</div>
						<div class="form-item span11">
							<label>Article Category:</label>
							<div id="article-category-container"></div>
						</div>
						<div class="form-item span11">
							<label>Friendly Url:</label>
							<input type="text" id="txtArticleUrl-{{id}}" name="txtArticleUrl-{{id}}" 
								class="input-xxlarge" value="{{attributes.articleUrl}}"
								required="required" data-message="Article Url is required"></input>
						</div>
						<div class="form-item hasHtmlArea span11">
							<label>Article Content:</label>
							<textarea id="txtArticleContent-{{id}}" name="txtArticleContent-{{id}}" 
								cols"45" row="150" class="htmlarea span10"
								required="required"
								data-message="Article Content is required">{{attributes.articleContent}}</textarea>
						</div>		
					</div>
				</div>
			</div>	
			<div class="span12">
				<div class="well well-small buncisButtonContainer">
					<div class="pull-right">
						<a href="#" class="btnSave btn btn-primary">Save</a>
						<a href="#" class="close-view-area btn btn-inverse">Close</a>
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
				<a href="#" id="deleteArticle-confirm" class="btn btn-primary">Yes</a>			    
				<a href="#" id="deleteArticle-cancel" class="popup-button-close btn btn-inverse">No</a>
			</div>
		</script>
		
		<script type="text/template" id="category-template">
			<div id="category-innerWrapper">
				<div id="radioNewsCategory" class="btn-group" data-toggle="buttons-radio">
				{% for (var i = 0; i < attributes.articleCategories.length; i++) { %}
					<button type="button" class="btn pull-left" 
						value="{{attributes.articleCategories[i].attributes.articleCategoryName}}"
						data-categoryid="{{attributes.articleCategories[i].attributes.articleCategoryId}}">
						{{attributes.articleCategories[i].attributes.articleCategoryName}}
					</button>
				{% } %}
					<div class="clearfix"></div>
				</div>
				<p></p>
				<div class="form-inline">
					<a href="#" id="aAddArticleCategory" class="btn btn-warning">
						<i class="icon-plus"></i>&nbsp;<span>Add Article Category</span>
					</a>
					<span class="add-category-section" style="display:none">
						<input type="text" id="txtArticleCategoryName" name="txtArticleCategoryName"
							class=""></input>
						<a href="#" id="aSaveArticleCategory" class="btn btn-success">
							<i class="icon-plus"></i>&nbsp;<span>Save</span>
						</a>
					</span>
				</div>
			</div>
		</script>
	</div>
</asp:Content>

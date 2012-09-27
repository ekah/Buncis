<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Articles.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_articles.js" type="text/javascript"></script>
	<script src="/Scripts/bunx/_act_articles_category.js" type="text/javascript"></script>
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
					<a href="#" id="aManageCategories" class="btn btn-warning">
						<i class="icon-th-list"></i>&nbsp;<span>Manage Article Categories</span>
					</a>
				</div>
				<div class="clearfix"></div>
				<ul id="article-list-container" class="list-item-container">
				</ul>
				<ul id="category-management-container" class="row list-item-container" style="display: none;">
				</ul>
			</div>
		</div>
	</div>
	
	<div id="article-edit-section" class="row"></div>
	<div id="article-delete-popup" class="popup-wrapper modal hide fade"></div>
	<div id="article-category-edit-popup" class="popup-wrapper modal hide fade"></div>

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
							<label>Friendly Url:</label>
							<span id="txtArticleUrl-{{id}}" name="txtArticleUrl-{{id}}" class="span10 uneditable-input">{{attributes.articleUrl}}</span>
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
				<div id="radioArticleCategory" class="btn-group" data-toggle="buttons-radio">
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
		
		<script type="text/template" id="category-management-template">
			<li class="span3 list-item" rel="{{id}}">
				<span>
					{{attributes.articleCategoryName}}
				</span>
				<a href="#" class="pull-right action delete-category">
					<i class="icon-remove"></i>&nbsp;<span></span>
				</a>
				<a href="#" class="pull-right action edit-category">
					<i class="icon-pencil"></i>&nbsp;<span></span>
				</a>
			</li>
		</script>
		
		<script type="text/template" id="edit-category-template">
			<div class="modal-header">
				<h3>Modal header</h3>
			</div>
			<div class="modal-body popup-content-small">
				<div class="form-item">
					<label>Category Name:</label>
					<input type="text" id="txtCategoryName" name="txtCategoryName" 
						required="required" data-message="Category Name is required"
						value="{{attributes.articleCategoryName}}" class="input-xlarge" />
				</div>
				<div class="form-item">
					<label>Category Description:</label>
					<input type="text" id="txtCategoryDescription" name="txtCategoryDescription" 
						required="required" data-message="Category Description is required"
						value="{{attributes.articleCategoryDescription}}" class="input-xlarge" />
				</div>
			</div>
			<div class="buttonContainer modal-footer">
				<a href="#" id="editcategory-save" class="btn btn-primary">Save</a>			    
				<a href="#" id="editcategory-cancel" class="popup-button-close btn btn-inverse">Cancel</a>
			</div>
		</script>
	</div>
</asp:Content>

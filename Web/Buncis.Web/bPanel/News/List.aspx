<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.News.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_news.js" type="text/javascript"></script>
	<script src="/Scripts/bunx/_act_news_category.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div id="homeSection" class="row" style="display: none">
		<div class="span12">
			<div class="buncisContentHeader well well-small">
				<h2>News</h2>
			</div>
		</div>
		<div class="span12">
			<div class="buncisContentBody well well-small">
				<div class="actionContent pull-right">
					<a href="#" id="aAddNews" class="btn btn-warning">
						<i class="icon-plus"></i>&nbsp;<span>Add News</span>
					</a>
					<a href="#" id="aManageCategories" class="btn btn-warning">
						<i class="icon-th-list"></i>&nbsp;<span>Manage News Categories</span>
					</a>
				</div>
				<div class="clearfix"></div>
				<div class="news-list-wrapper">				
					<ul class="news-item-container list-item-container">
					</ul>
				</div>
				<div class="news-category-management">
					<p></p>
					<div class="buncisButtonContainer">
						<div class="pull-right">
							<a href="#" id="mAddNewsCategory" class="btn btn-warning">
								<i class="icon-plus"></i>&nbsp;<span>Add News Category</span>
							</a>
						</div>
					</div>
					<ul id="category-management-container" class="row list-item-container">
					</ul>
					<div class="well well-small buncisButtonContainer">
						<div class="pull-right">
							<a href="#" class="btnBack btn btn-primary">Back</a>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	
	<div style="display:none">
		<script type="text/template" id="news-item-template">
			<li rel="{{id}}" class="list-item">
				<div class="row-fluid">
					<div class="leftSection span10">
						<div><strong>{{attributes.newsTitle}}</strong></div>
						<p></p>
						<div>{{attributes.newsTeaser}}</div>
						<p></p>
						<div>Published:&nbsp;{{attributes.datePublished}}</div>
						<div>Expired:&nbsp;{{attributes.dateExpired}}</div>
						<div class="pull-right">
						{% if(attributes.recentlyAdded) { %} 
							<span class="label label-inverse">Recently Added</span>
						{% } %} 
						{% if(attributes.recentlyEdited) { %} 
							<span class="label">Recently Edited</span>
						{% } %}   
						</div>
						<div class="clearfix"></div>
					</div>
					<div class="rightSection span1">
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

		<!-- template add/edit news -->
		<script type="text/template" id="news-edit-popup-template">		
			<div class="span12">
				<div class="buncisContentHeader well well-small">
					<h3>Modal header</h3>
				</div>
			</div>
			<div class="span12">			
				<div class="buncisContentBody well well-small">
					<div class="row">
						<div class="span12">
							<ul id="news-tabs" class="nav nav-tabs">
								<li class="tab-btn"><a href="#news-tab1" class="tabStart hasEditor">News Information</a></li>
							</ul>
						</div>
						<div class="tab-content span12">
							<div id="news-tab1" class="news-tab1 tab-pane">
								<div class="row">
									<div class="form-item span11">
										<label>News Title</label>
										<textarea id="txtNewsTitle" name="txtNewsTitle"
											data-message="News Title is required" required="required" 
											class="span10" rows="3" cols=120">{{attributes.newsTitle}}</textarea>
									</div>
									<div class="form-item span11">
										<label>Friendly URL</label>
										<span id="txtNewsUrl" name="txtNewsUrl" class="span10 uneditable-input">{{attributes.newsUrl}}</span>
									</div>
									<div class="form-item span11">
										<label>News Teaser</label>
										<textarea id="txtNewsTeaser" name="txtNewsTeaser" 
											required="required" data-message="News Teaser is required" 
											class="span10" cols="120" rows="6">{{attributes.newsTeaser}}</textarea>
									</div>
									<div class="form-item span11">
										<label>News Category:</label>
										<div id="news-category-container"></div>
									</div>
									<div class="form-item span5">
										<label>Date Published</label>
										<input type="text" id="txtDatePublished" name="txtDatePublished" 
											required="required" data-message="Date Published is required"
											value="{{attributes.formattedDatePublished}}" 
											rel="{{attributes.actualDatePublished}}" class="input-medium" />
										<span class="input-medium uneditable-input help-inline">{{attributes.datePublished}}</span>
									</div>							
									<div class="form-item span5">
										<label>Date Expired</label>
										<input type="text" id="txtDateExpired" name="txtDateExpired" 
											required="required" data-message="Date Expired  is required" 
											value="{{attributes.formattedDateExpired}}" 
											rel="{{attributes.actualDateExpired}}" class="input-medium" />
										<span class="input-medium uneditable-input help-inline">{{attributes.dateExpired}}</span>
									</div>
									<div class="form-item hasHtmlArea span11">
										<label>News Content</label>
										<textarea id="txtNewsContent" name="txtNewsContent" 
											class="htmlarea span10" rows="45" cols="150"
											required="required" data-message="News Content is required">{{attributes.newsContent}}</textarea>
									</div>
								</div>
							</div>						
						</div>
					</div>
				</div>
			</div>
			<div class="span12">
				<div class="well well-small buncisButtonContainer">
					<div class="pull-right">
						<a href="#" id="btnSaveNews" class="btn btn-primary">Save</a>                
						<a href="#" id="btnClose" class="popup-button-close btn btn-inverse">Close</a>
					</div>
				</div>
			</div>
		</script>
		
		<!-- template delete news -->
		<script type="text/template" id="news-confirmDelete-popup-template">
			<div class="modal-header">
				<h3>Modal header</h3>
			</div>
			<div class="modal-body popup-content-small">
				<p>Are you sure you want to delete news <strong>{{attributes.newsTitle}}</strong>?</p>
			</div>			
			<div class="buttonContainer modal-footer">
				<a href="#" id="deleteNews-confirm" class="btn btn-primary">Yes</a>
				<a href="#" id="deleteNews-cancel" class="popup-button-close btn btn-inverse">No</a>
			</div>
		</script>
		
		<script type="text/template" id="category-template">
			<div id="newsCategory-innerWrapper">
				<div id="radioNewsCategory" class="btn-group" data-toggle="buttons-radio">
				{% for (var i = 0; i < attributes.categories.length; i++) { %}
					<button type="button" class="btn pull-left" 
						value="{{attributes.categories[i].attributes.newsCategoryName}}"
						data-categoryid="{{attributes.categories[i].attributes.newsCategoryId}}">
						{{attributes.categories[i].attributes.newsCategoryName}}
					</button>
				{% } %}
					<div class="clearfix"></div>
				</div>
				<p></p>
				<div class="form-inline">
					<a href="#" id="aAddNewsCategory" class="btn btn-warning">
						<i class="icon-plus"></i>&nbsp;<span>Add News Category</span>
					</a>
					<span class="add-category-section" style="display:none">
						<input type="text" id="txtNewsCategoryName" name="txtNewsCategoryName"
							class=""></input>
						<a href="#" id="aSaveNewsCategory" class="btn btn-success">
							<i class="icon-plus"></i>&nbsp;<span>Save</span>
						</a>
					</span>
				</div>
			</div>
		</script>
		
		<script type="text/template" id="category-management-template">
			<li class="span3 list-item" rel="{{id}}">
				<span>
					{{attributes.newsCategoryName}}
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
						value="{{attributes.newsCategoryName}}" class="input-xlarge" />
				</div>
				<div class="form-item">
					<label>Category Description:</label>
					<input type="text" id="txtCategoryDescription" name="txtCategoryDescription" 
						required="required" data-message="Category Description is required"
						value="{{attributes.newsCategoryDescription}}" class="input-xlarge" />
				</div>
			</div>
			<div class="buttonContainer modal-footer">
				<a href="#" id="editcategory-save" class="btn btn-primary">Save</a>			    
				<a href="#" id="editcategory-cancel" class="popup-button-close btn btn-inverse">Cancel</a>
			</div>
		</script>

		<script type="text/template" id="category-delete-template">
			<div class="modal-header">
				<h3>Modal header</h3>
			</div>
			<div class="modal-body popup-content-small">
				<p>Are you sure you want to delete news category <strong>{{attributes.newsCategoryName}}</strong>?</p>
			</div>
			<div class="buttonContainer modal-footer">				
				<a href="#" id="deleteCategory-confirm" class="btn btn-primary">Yes</a>			    
				<a href="#" id="deleteCategory-cancel" class="popup-button-close btn btn-inverse">No</a>
			</div>
		</script>
	</div>    

	<div id="news-edit-popup" class="row"></div>
	<div id="news-delete-popup" class="popup-wrapper modal hide fade"></div>
	<div id="news-category-edit-popup" class="popup-wrapper modal hide fade"></div>
	<div id="news-category-delete-popup" class="popup-wrapper modal hide fade"></div>

</asp:Content>

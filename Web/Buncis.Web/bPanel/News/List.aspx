﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.News.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_news.js" type="text/javascript"></script>
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
				</div>
				<div class="clearfix"></div>
				<div class="news-list-wrapper">				
					<ul class="news-item-container list-item-container">
						<script type="text/template" id="news-item-template">
							<li rel="{{id}}" class="list-item">
								<div class="row-fluid">
									<div class="leftSection span10">
										<div><strong>{{attributes.newsTitle}}</strong></div>
										<p></p>
										<div>{{attributes.newsTeaser}}</div>
										<p></p>
										<div><strong>Published:</strong>&nbsp;{{attributes.datePublished}}</div>
										<div><strong>Expired:</strong>&nbsp;{{attributes.dateExpired}}</div>
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
					</ul>
				</div>
			</div>
		</div>
	</div>
	
	<div style="display:none">
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
									<div class="form-item span11">
										<label>Friendly URL</label>
										<input type="text" id="txtNewsUrl" name="txtNewsUrl"
											class="input-xxlarge" 
											required="required" data-message="News Url is required" value="{{attributes.newsUrl}}" />
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
				{% for (var i = 0; i < attributes.newsCategories.length; i++) { %}
					<button type="button" class="btn pull-left" 
						value="{{attributes.newsCategories[i].attributes.newsCategoryName}}"
						data-categoryid="{{attributes.newsCategories[i].attributes.newsCategoryId}}">
						{{attributes.newsCategories[i].attributes.newsCategoryName}}
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
	</div>    

	<div id="news-edit-popup" class="row"></div>
	<div id="news-delete-popup" class="popup-wrapper modal hide fade"></div>
</asp:Content>

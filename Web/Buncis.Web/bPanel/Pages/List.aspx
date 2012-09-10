﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Pages.List" %>
<%@ Import Namespace="Buncis.Framework.Core.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_pages.js" type="text/javascript"></script>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div id="homeSection" class="row">
		<div class="span12">
			<div class="well well-small buncisContentHeader">
				<h2>Pages</h2>
			</div>
		</div>
		<div class="span12">
			<div class="buncisContentBody well well-small">                
				<div class="actionContent pull-right">
					<a href="javascript:;" id="aAddPage" class="addPage btn btn-warning">
						<i class="icon-plus"></i>&nbsp;<span>Add Page</span>
					</a>
				</div>
				<div class="clearfix"></div>   
				<div class="innerContent">
					<table class="table table-striped table-hover table-condensed" id="table-pages"> 
						<colgroup>
							<col width="1%"</col>
							<col width="40%"</col>
							<col width="20%"</col>
							<col width="20%"</col>
							<col width="16%"</col>
						</colgroup>
						<thead>
							<tr>
								<th>&nbsp;</th>
								<th>Page</th>
								<th>Last Updated</th>
								<th>Created</th>
								<th>&nbsp;</th>
							</tr>
						</thead>
						<tbody>
						</tbody>
					</table>
				</div>
			</div>
		</div>
	</div>

	<!-- popup to edit/update page -->
	<%--<div id="form-page-popup" class="popup-wrapper modal hide fade">--%>
	<div id="form-page-popup" class="row">
		<div class="span12">
			<div class="buncisContentHeader well well-small">
				<h3>Modal header</h3>
			</div>
		</div>
		<div class="span12">
			<div class="form-page buncisContentBody well well-small">
				<ul class="nav nav-tabs" id="page-tabs">
					<li class="tab-btn"><a href="#page-tab1" class="tabStart hasEditor">Page Information</a></li>
				</ul>
				<div class="tab-content">
					<div id="page-tab1" class="page-tab1 tab-pane">
						<div class="pull-left">
							<div class="form-item">
								<label>Page Name</label>
								<input type="text" id="txtPageName" name="txtPageName" 
									class="input-xxlarge"
									required="required" data-message="Page Name is required" />
							</div>
							<div class="form-item">
								<label>Page Description</label>
								<textarea id="txtPageDescription" name="txtPageDescription" 
									rows="6" cols="120" class="autoTextarea"
									required="required" data-message="Page Description is required">
								</textarea>
							</div>
							<div class="form-item">
								<label>Name displayed in Menu</label>
								<input type="text" id="txtPageMenuName" name="txtPageMenuName" 
									class="medium"
									required="required" `data-message="Page Menu Name is required" />
							</div>
							<div class="form-item">
								<label>Do you want to make this page as your Home page?</label>
								<label class="form-item-reset" for="chkIsHomePage">Home Page</label>
								<input type="checkbox" id="chkIsHomePage" class="btn" />
							</div>
							<div class="form-item">
								<label>Friendly URL</label>
								<input type="text" id="txtPageUrl" name="txtPageUrl" 
									class="input-xlarge" 
									required="required" data-message="Page Url is required" />
							</div>
						</div>
						<div class="pull-left">
							<div class="form-item">
								<label>Page Meta Title</label>
								<input type="text" 
									id="txtPageMetaTitle" name="txtPageMetaTitle" class="input-xxlarge" 
									required="required" data-message="Page Meta Title is required" />
							</div>
							<div class="form-item">
								<label>Page Meta Description</label>
								<textarea id="txtPageMetaDescription" name="txtPageMetaDescription"
									class="autoTextarea" rows="6" cols="120" 
									required="required" data-message="Page Meta Description is required">
								</textarea>
							</div>		
						</div>
						<div class="clearfix"></div>
						<div class="form-item hasHtmlArea">
							<label>Content</label>
							<div>
								<textarea id="txtPageContent" name="txtPageContent"
									class="htmlarea" rows="45" cols="150"
									required="required" data-message="Page Content is required">
								</textarea>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="span12">
			<div class="well well-small buncisButtonContainer">
				<div class="pull-right">
					<a href="javascript:;" id="btnSavePage" class="btn btn-primary" rel="0">Save</a>
					<a href="javascript:;" id="btnClose" class="popup-button-close btn btn-inverse">Close</a>
				</div>
			</div>
		</div>
	</div>

	<!-- popup delete page -->
	<div id="delete-page-popup" class="popup-wrapper modal hide fade">
		<div class="modal-header">
			<h3>Modal header</h3>
		</div>
		<div class="modal-body popup-content-small">
			<p>Are you sure you want to delete page <strong><span id="d-pageName"></span></strong>?</p>
		</div>
		<div class="popup-button-wrapper buttonContainer modal-footer">
			<a href="javascript:;" id="deletePage-confirm" class="btn btn-primary">Yes</a>
			<a href="javascript:;" id="deletePage-cancel" class="popup-button-close btn btn-inverse">No</a>
		</div>
	</div>
</asp:Content>

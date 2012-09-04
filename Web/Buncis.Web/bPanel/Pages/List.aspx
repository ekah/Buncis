<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Pages.List" %>
<%@ Import Namespace="Buncis.Framework.Core.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_pages.js" type="text/javascript"></script>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div class="row">
		<div class="span12">
			<div class="well well-small buncisContentHeader">
				<h2>Pages</h2>
			</div>
		</div>
		<div class="span12">
			<div class="buncisContentBody well well-small">
				<div class="actionContent">
					<a href="javascript:;" id="aAddPage" class="button-action addPage">
						<span class="icon-plus">Add Page</span>
					</a>
				</div>		
				<div class="innerContent">
					<table class="data-table table-pages" id="table-pages"> 
						<colgroup>
							<col width="1%"</col>
							<col width="40%"</col>
							<col width="20%"</col>
							<col width="20%"</col>
							<col width="15%"</col>
						</colgroup>
						<thead>
							<tr>
								<th class="icon-col">&nbsp;</th>
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
	<div id="form-page-popup" class="popup-wrapper modal hide fade">
		<div class="modal-header">
			<h3>Modal header</h3>
		</div>
		<div class="form-page popup-content modal-body">
			<!--<div id="page-wizard" class="swMain"></div>-->
			<ul class="nav nav-tabs" id="page-tabs">
				<li class="tab-btn"><a href="#page-tab1" class="tabStart">Section 1: Page Information</a></li>
				<li class="tab-btn"><a href="#page-tab2" class="hasEditor">Section 2: Page Content</a></li>
			</ul>
			<!-- tabs -->
			<div class="tab-content">
				<div id="page-tab1" class="page-tab1 tab-pane">
					<div class="left pull-left">
						<div class="form-item">
							<label>Name</label>
							<input type="text" required="required" id="txtPageName" class="medium" 
								name="txtPageName" data-message="Page Name is required" />
						</div>
						<div class="form-item">
							<label>Page Description</label>
							<textarea required="required" 
								id="txtPageDescription" name="txtPageDescription" 
								class="meta-desc" style="width: 400px" rows="6" cols="60" 
								data-message="Page Description is required">
							</textarea>
						</div>
						<div class="form-item">
							<label>Name displayed on Menu</label>
							<input type="text" required="required" id="txtPageMenuName" class="medium" 
								name="txtPageMenuName" data-message="Page Menu Name is required" />
						</div>            				
						<div class="form-item">
							<label>Do you want to make this page as your Home page?</label>
							<label class="form-item-reset" for="chkIsHomePage">Home Page</label>
							<input type="checkbox" id="chkIsHomePage" class="btn" />
						</div>		
						<div class="form-item">
							<label>Friendly URL</label>
							<input type="text" required="required" id="txtPageUrl" class="medium" 
								name="txtPageUrl" data-message="Page Url is required" />
						</div>								
					</div>
					<div class="right pull-left">
						<div class="form-item">
							<label>Page Meta Title</label>
							<input type="text" required="required" id="txtPageMetaTitle" class="long" 
								name="txtPageMetaTitle" data-message="Page Meta Title is required" />
						</div>
						<div class="form-item">
							<label>Page Meta Description</label>
							<textarea required="required" 
								id="txtPageMetaDescription" name="txtPageMetaDescription"
								style="width: 400px;" class="meta-desc" rows="6" cols="60" 
								data-message="Page Meta Description is required">
							</textarea>
						</div>		
					</div>
					<div class="clearFloats"></div>            
				</div>
				<div id="page-tab2" class="page-tab2 tab-pane">
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
		<div class="popup-button-wrapper buttonContainer modal-footer">
			<a href="javascript:;" id="btnSavePage" class="btn btn-success" rel="0">Save</a>
			<a href="javascript:;" id="btnClose" class="popup-button-close btn btn-danger">Close</a>
		</div>
	</div>

	<!-- popup delete page -->
	<div id="delete-page-popup" class="popup-wrapper modal hide fade">
		<div class="modal-header">
			<h3>Modal header</h3>
		</div>
		<div class="modal-body">
			<p>Are you sure you want to delete page <strong><span id="d-pageName"></span></strong>?</p>
		</div>
		<div class="popup-button-wrapper buttonContainer modal-footer">
			<a href="javascript:;" id="deletePage-cancel" class="button-whiteOnBlack popup-button-close">No</a>
			<a href="javascript:;" id="deletePage-confirm" class="button-whiteOnRed">Yes</a>			    
		</div>
	</div>
</asp:Content>

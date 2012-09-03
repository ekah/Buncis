<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Pages.List" %>
<%@ Import Namespace="Buncis.Framework.Core.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_pages.js" type="text/javascript"></script>	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div class="buncisContentHeader">
		<h3>Pages</h3>
	</div>
	<div class="buncisContentBody">
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
			<div class="clearFloats"></div>
		</div>
	</div>

	<!-- popup to edit/update page -->
	<div style="display: none">
		<div id="form-page-popup" class="popup-wrapper">
			<div class="form-page popup-content">
				<div id="page-wizard" class="swMain">
					<ul class="page-tabs">
						<li><a href="#page-tab1" class="tabStart">Section 1: Page Information</a></li>
						<li><a href="#page-tab2">Section 2: Page Content</a></li>
					</ul>
					<div id="page-tab1" class="page-tab1">
						<div class="left">
							<div class="form-item">
								<label>Name</label>
								<input type="text" required="required" id="txtPageName" class="medium" 
									name="txtPageName" data-message="Page Name is required" />
							</div>
							<div class="form-item">
								<label>Page Description</label>
								<textarea required="required" id="txtPageDescription" name="txtPageDescription"
									style="width: 400px; height: 100px" class="meta-desc"
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
								<input type="checkbox" id="chkIsHomePage" />
							</div>		
							<div class="form-item">
								<label>Friendly URL</label>
								<input type="text" required="required" id="txtPageUrl" class="medium" 
									name="txtPageUrl" data-message="Page Url is required" />
							</div>								
						</div>
						<div class="right">
							<div class="form-item">
								<label>Page Meta Title</label>
								<input type="text" required="required" id="txtPageMetaTitle" class="long" 
									name="txtPageMetaTitle" data-message="Page Meta Title is required" />
							</div>
							<div class="form-item">
								<label>Page Meta Description</label>
								<textarea required="required" 
									id="txtPageMetaDescription" name="txtPageMetaDescription"
									style="width: 400px; height: 100px" class="meta-desc"
									data-message="Page Meta Description is required">
								</textarea>
							</div>		
						</div>
						<div class="clearFloats"></div>            
					</div>
					<div id="page-tab2" class="page-tab2"> 
						<div class="form-item hasHtmlArea">
							<label>Content</label>
							<div>
								<textarea id="txtPageContent" class="htmlarea" name="txtPageContent"
									required="required" data-message="Page Content is required">
								</textarea>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="clearFloats"></div>
			<div class="popup-button-wrapper buttonContainer">
				<a href="javascript:;" id="btnClose" class="button-whiteOnRed popup-button-close">Close</a>
				<a href="javascript:;" id="btnSavePage" class="button-whiteOnGreen" rel="0">Save</a>
			</div>
		</div>
	</div>

	<!-- popup delete page -->
	<div style="display:none">
		<div id="delete-page-popup" class="popup-wrapper">
			<p>Are you sure you want to delete page <strong><span id="d-pageName"></span></strong>?</p>
			<div class="popup-button-wrapper buttonContainer">
				<a href="javascript:;" id="deletePage-cancel" class="button-whiteOnBlack popup-button-close">No</a>
				<a href="javascript:;" id="deletePage-confirm" class="button-whiteOnRed">Yes</a>			    
			</div>
		</div>
	</div>
</asp:Content>

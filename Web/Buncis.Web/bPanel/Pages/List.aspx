<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Pages.List" %>
<%@ Import Namespace="Buncis.Framework.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
    <script type="text/javascript">
   	
        (function (pages) {
            pages._elems = {
                clientId: <%= CurrentProfile.ClientId %>,
                pageWizards: '#page-wizard',
                tablePages: '#table-pages',
                btnAddPage: '#aAddPage',
                pageFormPopup: '#form-page-popup',
                pageFormElements: '.form-page .form-item :input',
                pageTabs: '.page-tabs',
                deletePagePopup: '#delete-page-popup',
                deletedPageName: '#d-pageName',
                confirmDeletePage: '#deletePage-confirm',
                cancelDeletePage: '#deletePage-cancel',
                validated: '.form-page :input, .form-page :textarea',
                txtPageName: '#txtPageName',
                txtPageDescription: '#txtPageDescription',
                txtPageUrl: '#txtPageUrl',
                txtPageMenuName: '#txtPageMenuName',
                txtPageMetaTitle: '#txtPageMetaTitle',
                txtPageMetaDescription: '#txtPageMetaDescription',
                txtPageContent: '#txtPageContent',
                chkIsHomePage: '#chkIsHomePage',
                btnSavePage: '#btnSavePage',
                btnEditPage: '#table-pages td a.edit',
                btnDeletePage: '#table-pages td a.delete',
                colorboxArea: '#cboxLoadedContent'
            };
        }(window._pages = window._pages || {}));

    </script>
    <script src="/Scripts/bunx/_act_pages.js" type="text/javascript"></script>
    <style type="text/css">    

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
    <div class="buncisContentHeader">
        <h3>Pages</h3>
    </div>
    <div class="buncisContentBody">
        <div class="actionContent">
            <a href="javascript:void(0);" id="aAddPage" class="button-action addPage"><span class="icon-plus">Add Page</span></a>
        </div>
        <div class="innerContent">
            <table class="data-table table-pages" id="table-pages"> 
                <thead>
                    <th>&nbsp;</th>
                    <th>Page</th>
					<th>Last Updated</th>
					<th>Created</th>
                    <th>&nbsp;</th>
                </thead>               
                <tbody>                                             
                </tbody>
            </table>
			<div class="clearFloats"></div>
        </div>
    </div>

    <!-- popup to edit/update page -->
    <div style="display: none">
		<div id="form-page-popup">
			<div class="form-page">
				<div class="popup-button-wrapper buttonContainer">
					<a href="javascript:void(0);" id="btnClose" class="button-whiteOnRed popup-button-close">Close</a>
					<a href="javascript:void(0);" id="btnSavePage" class="button-whiteOnGreen" rel="0">Save</a>
				</div>
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
								<input type="checkbox" id="chkIsHomePage" />
							</div>		
							<div class="form-item">
								<label>Friendly Url</label>
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
						<div class="form-item section-page-content">
							<label>Content</label>
							<div>
								<textarea id="txtPageContent" class="htmlarea" name="txtPageContent"
									style="width: 870px; height: 350px" required="required"
									data-message="Page Content is required">
								</textarea>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
    </div>

    <!-- popup delete page -->
    <div style="display:none">
        <div id="delete-page-popup">
            <p>Are you sure you want to delete page <strong><span id="d-pageName"></span></strong> ?</p>
            <div class="popup-button-wrapper buttonContainer">
        	    <a href="javascript:void(0);" id="deletePage-cancel" class="button-whiteOnBlack popup-button-close">No</a>
                <a href="javascript:void(0);" id="deletePage-confirm" class="button-whiteOnRed">Yes</a>			    
            </div>
        </div>
    </div>
</asp:Content>

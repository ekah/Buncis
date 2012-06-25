<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Pages.List" %>
<%@ Import Namespace="Buncis.Framework.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
    <script type="text/javascript">

        (function (pages) {
            pages._elems = {
                clientId: <%= CurrentProfile.ClientId %>,
                tabsMenu: '.page-tabs',
                tabs: '.form-page > div.tabContent',
                tablePages: '#table-pages',
                btnAddPage: '.addPage',
                pageFormPopup: '#form-page-popup',
                pageForm: '.form-page',
                deletePagePopup: '#delete-page-popup',
                deletedPageName: '#d-pageName',
                confirmDeletePage: '#deletePage-confirm',
                cancelDeletePage: '#deletePage-cancel',
                validated: '.form-page :input, .form-page :textarea',
                txtPageName: '#txtPageName',
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
					<a href="javascript:void(0);" id="btnSavePage" class="button-whiteOnGreen">Save</a>
				</div>
        		<ul class="page-tabs css-tabs skin2">
    				<li><a href="javascript:void(0)">Page Information</a></li>
					<li><a href="javascript:void(0)">Page Content</a></li>
    			</ul>
        		<div class="page-tab1 tabContent">
					<div class="left">
            			<div class="form-item">
            				<label>Name</label>
    						<input type="text" required="required" id="txtPageName" class="medium"/>
            			</div>
    					<div class="form-item">
            				<label>Name displayed on Menu</label>
    						<input type="text" required="required" id="txtPageMenuName" class="medium"/>
            			</div>
						<div class="form-item">
							<label>Friendly Url</label>
							<input type="text" required="required" id="txtPageUrl" class="medium"/>
						</div>    
                        <div class="form-item">
							<label>Do you want to make this page as your Home page?</label>
							<input type="checkbox" required="required" id="chkIsHomePage" />
						</div>
                        <div class="form-item">
							<label>Meta Title</label>
							<input type="text" required="required" id="txtPageMetaTitle" class="long"/>
						</div>
						<div class="form-item">
							<label>Meta Description</label>
							<textarea required="required" id="txtPageMetaDescription" rows="5" cols="70" class="meta-desc"></textarea>
						</div>						
					</div>
					<div class="right">						
					</div>
					<div class="clearFloats"></div>            
				</div>
				<div class="page-tab2 tabContent"> 
					<div class="form-item">
						<label>Content</label>
						<div><textarea id="txtPageContent" class="htmlarea" rows="23" cols="130"></textarea></div>
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

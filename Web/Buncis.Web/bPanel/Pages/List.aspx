<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Pages.List" %>
<%@ Import Namespace="Buncis.Framework.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
    <script type="text/javascript">

        (function (pages) {
            pages._elems = {
                clientId: <%= CurrentProfile.ClientId %>,
                txtPageContent: '#txtPageContent',
                tablePages: '#table-pages',
                btnAddPage: '.addPage',
                pageForm: '.form-page'
            };
        }(window._pages = window._pages || {}));

    </script>
    <script src="/Scripts/bunx/_act_pages.js" type="text/javascript"></script>
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
        <div class="form-page">
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
			</div>
            <div class="right">
                <div class="form-item">
                    <label>Meta Title</label>
                    <input type="text" required="required" id="txtPageMetaTitle" class="medium"/>
                </div>
                <div class="form-item">
                    <label>Meta Description</label>
                    <input type="text" required="required" id="txtPageMetaDescription" class="medium"/>
                </div>
                <div class="form-item">
                    <label>Do you want to make this page as your Home page?</label>
                    <input type="checkbox" required="required" id="chkIsHomePage" class="medium"/>
                </div>
            </div>
            <div class="clearFloats"></div>
            <div class="form-item">
                <label>Content</label>
                <div><textarea id="txtPageContent" class="htmlarea" rows="45" cols="130"></textarea></div>
            </div>
        </div>
    </div>
</asp:Content>

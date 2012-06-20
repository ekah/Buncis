<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.Pages.List" %>
<%@ Import Namespace="Buncis.Framework.Infrastructure.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
    <script type="text/javascript">

        (function (pages) {
            pages._elems = {
                clientId: <%= CurrentProfile.ClientId %>,
                txtPageContent: '#txtPageContent',
                tablePages: '#table-pages'
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
            <a href="javascript:void(0);" id="aAddPage" class="button-action"><span class="icon-plus">Add Page</span></a>
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
    <div>
        <div>
            <div class="form-item">
                <label>Content</label>
                <div>
                    <textarea id="txtPageContent" class="htmlarea" rows="5" cols="150"></textarea>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

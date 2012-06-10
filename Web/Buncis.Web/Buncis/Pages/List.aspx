<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.Buncis.Pages.List" %>
<%@ Import Namespace="Buncis.Core.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
    <script type="text/javascript">

        (function (obj) {
            if(obj != null) {
                return;
            }

            window._pages = {
                _elems:  {
                    txtPageContent: '#txtPageContent',
                },
            };
            
        }(window._pages = window._pages || null));

    </script>
    <script src="/Scripts/bunx/_act_pages.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
    <div class="buncisContentHeader">
        <h3>Pages</h3>
    </div>
    <div class="buncisContentBody">
        <div class="actionContent">
            <a href="#" id="" class="button-action"><span class="icon-plus">Add Page</span></a>
        </div>
        <div class="innerContent">
            <asp:Repeater runat="server" ID="rptPages">
                <HeaderTemplate>
                    <table class="data-table"> 
                        <thead>
                            <th>&nbsp;</th>
                            <th>Page</th>
							<th>Activities</th>
                        </thead>               
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td class="icon-col">
                                <asp:HyperLink ID="lnkEditPage" runat="server" ClientIDMode="Static" NavigateUrl="#">
                                    <span runat="server" id="spanIcon">&nbsp;</span>
                                </asp:HyperLink>
                            </td>
                            <td>
                            	<div>
                            		<span><strong><%# Eval("PageName") %></strong></span><br/>
									<span class="info"><%# Eval("PageDescription") %></span>
								</div>
							</td>                
                            <td>
                            	<div>
                            		<span>Created Date: <%# ((DateTime)Eval("DateCreated")).ToLongFormatString() %></span><br/>
									<span>Last Updated Date: <%# ((DateTime)Eval("DateLastUpdated")).ToLongFormatString() %></span>
								</div>
							</td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
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

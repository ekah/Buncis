<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSearch.ascx.cs"
    Inherits="Buncis.Web.UserControls.ProductSearch" %>
<div class="product-search">
    <div class="search-filter">
        <label>Categories:</label>
        <asp:DropDownList ID="ddlCategories" runat="server" AppendDataBoundItems="false">
            
        </asp:DropDownList>
        <span>&nbsp;&nbsp;&nbsp;</span>
        <label>Suppliers:</label>
        <asp:DropDownList ID="ddlSuppliers" runat="server" AppendDataBoundItems="false">
            
        </asp:DropDownList>
        <asp:Button ID="btnSearch" runat="server" Text="Search" />
    </div>
    <div class="search-results">
        <asp:Repeater ID="rptProducts" runat="server">
            <ItemTemplate>
                <div class="search-results-item">
                    <div class="item-image">
                        <img src='<%# Eval("ProductImage") %>' />
                    </div>
                    <div class="item-details">
                        <h3 class="item-name"><%# Eval("ProductName")%></h3>
                    </div>                    
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentNews.ascx.cs" Inherits="Buncis.Web.UserControls.News.RecentNews" %>

<div class="recentnews">
	<asp:Repeater runat="server" ID="rptRecentNews">
		<ItemTemplate>
			<div class="recentnews-item">
				<div class="recentnews-newstitle">
					<a href='<%# Eval("NewsUrl") %>'><%# Eval("NewsTitle") %></a>
				</div>
				<div class="recentnews-newsinfo"><%# Eval("DisplayDatePublished")%></div>
				<div class="recentnews-newssummary"><%# Eval("NewsTeaser") %></div>
				<div class="recentnews-footer">
					<a href='<%# Eval("NewsUrl") %>'>Read More</a>
				</div>
				<div class="clearfix"></div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
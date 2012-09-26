<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentArticles.ascx.cs" Inherits="Buncis.Web.UserControls.Articles.RecentArticles" %>

<div class="recentarticles">
	<asp:Repeater runat="server" ID="rptRecentArticles">
		<ItemTemplate>
			<div class="recentarticles-item">
				<div class="recentarticles-articletitle">
					<a href='<%# Eval("ArticleUrl") %>'><%# Eval("ArticleTitle") %></a>
				</div>
				<div class="recentarticles-articleinfo"><%# Eval("DisplayDateCreated")%></div>
				<div class="recentarticles-articlesummary"><%# Eval("ArticleTeaser")%></div>
				<div class="recentarticles-footer">
					<a href='<%# Eval("ArticleUrl") %>'>Read More</a>
				</div>
				<div class="clearfix"></div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
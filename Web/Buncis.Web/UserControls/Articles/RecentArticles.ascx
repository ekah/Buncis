<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentArticles.ascx.cs" Inherits="Buncis.Web.UserControls.Articles.RecentArticles" %>
<%@ Import namespace="Buncis.Framework.Core.Infrastructure.Extensions" %>
<div class="recentarticles">
	<asp:Repeater runat="server" ID="rptRecentArticles">
		<ItemTemplate>
			<div class="recentarticles-item">
				<div class="recentarticles-articletitle">
					<a href='<%# Eval("ArticleUrl") %>'><%# Eval("ArticleTitle") %></a>
				</div>
				<div class="recentarticles-articleinfo"><%# ((DateTime)Eval("DateCreated")).ToBuncisShortFormatString() %></div>
				<div class="recentarticles-articlesummary"><%# Eval("ArticleTeaser")%></div>
				<%--<div class="listitem-social">
					<fb:share-button type="button_count" href='<%# Buncis.Web.Common.Utility.WebUtil.GetFullUrlToShare(Eval("ArticleUrl").ToString()) %>'></fb:share-button>
					<div class="fb-like" data-href='<%# Buncis.Web.Common.Utility.WebUtil.GetFullUrlToShare(Eval("ArticleUrl").ToString()) %>' data-send="false" data-layout="button_count" data-width="450" data-show-faces="false"></div>
				</div>--%>
				<div class="recentarticles-footer">
					<a href='<%# Eval("ArticleUrl") %>'>Read More</a>
				</div>
				<div class="clearfix"></div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
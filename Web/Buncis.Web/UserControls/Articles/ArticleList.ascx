﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleList.ascx.cs" Inherits="Buncis.Web.UserControls.Articles.ArticleList" %>

<div class="box-content articlelist-wrapper">
	<div id="articlelist-container">
		<asp:Repeater runat="server" ID="rptArticleList">
			<ItemTemplate>
				<div class="articlelist-item">
					<div class="title">
						<a href='<%# Eval("ArticleUrl") %>' title='<%# Eval("ArticleTitle") %>'><%# Eval("ArticleTitle") %></a>
					</div>
					<div class="info">
						<%# Eval("DisplayDateCreated")%>
					</div>
					<div class="teaser">
						<%# Eval("ArticleTeaser") %>
					</div>
					<%--<div class="listitem-social">
						<fb:share-button type="button_count" href='<%# Buncis.Web.Common.Utility.WebUtil.GetFullUrlToShare(Eval("ArticleUrl").ToString()) %>'></fb:share-button>
					</div>--%>
					<div class="item-footer">
						<a href='<%# Eval("ArticleUrl") %>' title="Read More">Read More</a>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>

<%--<script src="/Scripts/modules/jquery.masonry.min.js" type="text/javascript"></script>--%>
<script src="/Scripts/modules/jquery.isotope.min.js" type="text/javascript"></script>
<script type="text/javascript">
	$(document).ready(function () {
		var $container = $('#articlelist-container');
		$container.isotope({
			itemSelector: '.articlelist-item',
			animationEngine: 'best-available',
			animationOptions: {
				duration: 800,
				easing: 'linear',
				queue: false
			}
		});
		$(window).trigger('resize');
	});
</script>
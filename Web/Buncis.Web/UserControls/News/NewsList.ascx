<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList.ascx.cs" Inherits="Buncis.Web.UserControls.News.NewsList" %>

<div class="newslist-wrapper box-content">
	<div id="newslist-container">
		<asp:Repeater runat="server" ID="rptNewsList">
			<ItemTemplate>
				<div class="newslist-item">
					<div class="title">
						<a href='<%# Eval("NewsUrl") %>' title='<%# Eval("NewsTitle") %>'><%# Eval("NewsTitle") %></a>
					</div>
					<div class="info">
						<%# Eval("DisplayDatePublished")%>
					</div>
					<div class="teaser">
						<%# Eval("NewsTeaser") %>
					</div>
					<div class="item-footer">
						<a href='<%# Eval("NewsUrl") %>' title="Read More">Read More</a>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>

<script type="text/javascript" src="/Scripts/jquery.masonry.min.js"></script>

<script type="text/javascript">
	(function ($) {
		var $container = $('#newslist-container');
		$container.masonry({
			itemSelector: '.newslist-item',
			isAnimated: true
		});
		$(window).trigger("resize");
	} (window.jQuery));
</script>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsList.ascx.cs" Inherits="Buncis.Web.UserControls.News.NewsList" %>

<script src="/Scripts/jquery.masonry.min.js" type="text/javascript"></script>
<script type="text/javascript">
	$(document).ready(function () {
		$('#newslist-container').masonry({
			// options
			itemSelector: '.newslist-item'
		});
	});

</script>
<div class="row">
<div id="newslist-container">
	<asp:Repeater runat="server" ID="rptNewsList">
		<ItemTemplate>
			<div class="newslist-item threecol">
				<div class="title">
					<a href='<%# Eval("NewsUrl") %>' title='<%# Eval("NewsTitle") %>'><%# Eval("NewsTitle") %></a>
				</div>
				<div class="info">
					<%# Eval("DisplayDatePublished")%>
				</div>
				<div class="teaser">
					<%# Eval("NewsTeaser") %>
				</div>
				<div class="newsitem-footer">
					<a href='<%# Eval("NewsUrl") %>' title="Read More">Read More</a>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
</div>
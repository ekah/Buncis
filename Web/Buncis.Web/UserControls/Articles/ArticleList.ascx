<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArticleList.ascx.cs" Inherits="Buncis.Web.UserControls.Articles.ArticleList" %>

<script src="/Scripts/jquery.masonry.min.js" type="text/javascript"></script>
<script type="text/javascript">
	$(document).ready(function () {
		$('#articlelist-container').masonry({
			// options
			itemSelector: '.articlelist-item'
		});
	});

</script>
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
				<div class="newsitem-footer">
					<a href='<%# Eval("ArticleUrl") %>' title="Read More">Read More</a>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
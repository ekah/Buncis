<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DailyBreadList.ascx.cs" Inherits="Buncis.Web.UserControls.DailyBread.DailyBreadList" %>

<div class="dailybreadlist-wrapper box-content">
	<div id="dailybreadlist-container">
		<asp:Repeater runat="server" ID="rptDailyBreadlist">
			<ItemTemplate>
				<div class="dailybreadlist-item">
					<div class="title">
						<a href='<%# Eval("DailyBreadUrl") %>' title='<%# Eval("DailyBreadTitle") %>'><%# Eval("DailyBreadTitle") %></a>
					</div>
					<div class="info">
						<%# Eval("DisplayDatePublished")%>
					</div>
					<div class="book">
						<%# Eval("DailyBreadBookInfo")%>
					</div>
					<div class="teaser">
						<%# Eval("DailyBreadSummary") %>
					</div>
					<div class="item-footer">
						<a href='<%# Eval("DailyBreadUrl") %>' title="Read More">Read More</a>
					</div>
				</div>
			</ItemTemplate>
		</asp:Repeater>
	</div>
</div>

<script src="/Scripts/jquery.masonry.min.js" type="text/javascript"></script>
<script type="text/javascript">
	$(document).ready(function () {
		$('#dailybreadlist-container').masonry({
			itemSelector: '.dailybreadlist-item',
			isAnimated: true
		});
		$(window).trigger("resize");
	});

</script>
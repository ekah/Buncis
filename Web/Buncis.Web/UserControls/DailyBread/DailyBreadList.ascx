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

<%--<script src="/Scripts/modules/jquery.masonry.min.js" type="text/javascript"></script>--%>
<script src="/Scripts/modules/jquery.isotope.min.js" type="text/javascript"></script>
<script type="text/javascript">
	$(document).ready(function () {
		var $container = $('#dailybreadlist-container');
		$container.isotope({
			itemSelector: '.dailybreadlist-item',
			animationEngine: 'best-available',
			animationOptions: {
				duration: 800,
				easing: 'linear',
				queue: false
			}
		});
		$(window).trigger("resize");
	});

</script>
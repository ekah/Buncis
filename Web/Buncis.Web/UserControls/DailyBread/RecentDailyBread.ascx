<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentDailyBread.ascx.cs" Inherits="Buncis.Web.UserControls.DailyBread.RecentDailyBread" %>
<asp:Repeater runat="server" ID="rptRecentDailyBread">
	<ItemTemplate>
		<div class="recentdailybread-item">
			<div class="recentdailybread-dailybreadtitle">
				<a href='<%# Eval("DailyBreadUrl") %>'><%# Eval("DailyBreadTitle")%></a>
			</div>
			<div class="recentdailybread-dailybreadinfo"><%# Eval("DisplayDateCreated")%></div>
			<div class="recentdailybread-dailybreadummary"><%# Eval("DailyBreadSummary")%></div>
			<div class="recentdailybread-footer">
				<a href='<%# Eval("DailyBreadUrl") %>'>Read More</a>
			</div>
			<div class="clearfix"></div>
		</div>
	</ItemTemplate>
</asp:Repeater>
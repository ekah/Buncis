<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentDailyBread.ascx.cs" Inherits="Buncis.Web.UserControls.DailyBread.RecentDailyBread" %>

<div class="recentdailybread">
	<asp:Repeater runat="server" ID="rptRecentDailyBread">
		<ItemTemplate>
			<div class="recentdailybread-item">
				<div class="row">
					<div class="recentdailybread-dailybreadbible threecol last">
						<div class="book"><%# Eval("DailyBreadBook")%></div>
						<div class="chapterverse">
							<%# string.Format("{0}:{1}-{2}", Eval("DailyBreadBookChapter"), Eval("DailyBreadBookVerse1"), Eval("DailyBreadBookVerse2"))%>
						</div>
					</div>
					<div class="recentdailybread-content fivecol last">
						<div class="recentdailybread-dailybreadtitle">
							<a href='<%# Eval("DailyBreadUrl") %>'><%# Eval("DailyBreadTitle")%></a>
						</div>
						<div class="recentdailybread-dailybreadinfo"><%# Eval("DisplayDateCreated")%></div>
						<div class="recentdailybread-dailybreadsummary"><%# Eval("DailyBreadSummary")%></div>
						<div class="recentdailybread-footer">
							<a href='<%# Eval("DailyBreadUrl") %>'>Read More</a>
						</div>
					</div>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
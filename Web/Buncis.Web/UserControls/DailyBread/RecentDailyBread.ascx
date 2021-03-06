﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecentDailyBread.ascx.cs" Inherits="Buncis.Web.UserControls.DailyBread.RecentDailyBread" %>

<div class="recentdailybread">
	<asp:Repeater runat="server" ID="rptRecentDailyBread">
		<ItemTemplate>
			<div class="recentdailybread-item">
				<div class="">
					<%--<div class="recentdailybread-dailybreadbible fourcol last">
						<div class="book"><%# Eval("DailyBreadBook")%></div>
						<div class="chapterverse">
							<%# string.Format("{0}:{1}-{2}", Eval("DailyBreadBookChapter"), Eval("DailyBreadBookVerse1"), Eval("DailyBreadBookVerse2"))%>
						</div>
					</div>--%>
					<div class="recentdailybread-content">
						<div class="recentdailybread-dailybreadtitle">
							<a href='<%# Eval("DailyBreadUrl") %>'><%# Eval("DailyBreadTitle")%></a>
						</div>
						<div class="recentdailybread-dailybreadinfo"><%# Eval("DisplayDatePublished")%></div>
						<div class="recentdailybread-dailybreadbible2">
							<%# Eval("DailyBreadBookInfo")%>
							<%--<%# Eval("DailyBreadBook")%>&nbsp<%# string.Format("{0}:{1}-{2}", Eval("DailyBreadBookChapter"), Eval("DailyBreadBookVerse1"), Eval("DailyBreadBookVerse2"))%>--%>
						</div>
						<div class="recentdailybread-dailybreadsummary"><%# Eval("DailyBreadSummary")%></div>
						<div class="recentdailybread-footer">
							<a href='<%# Eval("DailyBreadUrl") %>'>Read More</a>
						</div>
					</div>
					<div class="clearfix"></div>
				</div>
			</div>
		</ItemTemplate>
	</asp:Repeater>
</div>
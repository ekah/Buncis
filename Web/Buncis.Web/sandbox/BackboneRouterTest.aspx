<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="BackboneRouterTest.aspx.cs" Inherits="Buncis.Web.sandbox.BackboneRouterTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script type="text/javascript">
		var MyRouter = Backbone.Router.extend({
			routes: {
				"help": "help",
				"search/:query": "search", 
			},
			help: function () {
				console.log("help");
			},
			search: function (query) {
				console.log('search: ' + query);
			}
		});

		$(document).ready(function () {
			var appRouter = new MyRouter();
			Backbone.history.start();
		});		

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<a href="#help">Help</a><br/>
	<a href="#search/andy">Where's Andy?</a>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Sandbox.Master" AutoEventWireup="true" CodeBehind="NewsSandbox.aspx.cs" Inherits="Buncis.Web.sandbox.NewsSandbox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			var clientId = 1;
			var listWebServiceUrl = '/webservices/news.svc/bPanelGetNewsList?clientid=' + clientId;
			$.ajax({
				type: "GET",
				url: listWebServiceUrl,
				success: function (result) {
					var data = result.d;
					if (data.IsSuccess) {
						console.log(data.ResponseObject);
					}
				},
				error: function () {
				}
			});
		});

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
	<label for="textCheckbox">Test</label>
	<input type="checkbox" id="testCheckBox" />
	</div>
</asp:Content>

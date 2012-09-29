<%@ Page Title="" Language="C#" MasterPageFile="~/Master/CustomPage8s.Master" AutoEventWireup="true" CodeBehind="TestProvider.aspx.cs" Inherits="Buncis.Web.sandbox.TestProvider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		$(document).ready(function () {
			$.ajax({
				type: "GET",
				url: '/open/ServiceProvider.svc/GetCategories',
				dataType: 'json',
				contentType: 'text/json',
				success: function (result) {
					console.log(result);
					$.ajax({
						type: "GET",
						url: '/open/ServiceProvider.svc/GetProvider?langitude=89.234&latitude=-435.54',
						dataType: 'json',
						contentType: 'text/json',
						success: function (result2) {
							console.log(result2);

						},
						error: function () {

						}
					});
				},
				error: function () {

				}
			});
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPlaceHolder" runat="server">
</asp:Content>

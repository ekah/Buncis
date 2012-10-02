<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Buncis.Web.bPanel.Dashboard" %>

<%@ Register tagPrefix="bun" tagName="AsyncUpload" src="/UserControls/Component/AsyncUpload.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/modules/fileupload/canvas-to-blob.js" type="text/javascript"></script>
	<script src="/Scripts/modules/fileupload/load-image.js" type="text/javascript"></script>
	<script src="/Scripts/modules/fileupload/tmpl.js" type="text/javascript"></script>
	<script src="/Scripts/modules/fileupload/jquery.ui.widget.js" type="text/javascript"></script>
	<script src="/Scripts/modules/fileupload/jquery.iframe-transport.js" type="text/javascript"></script>
	<script src="/Scripts/modules/fileupload/jquery.fileupload.js" type="text/javascript"></script>
	<script src="/Scripts/modules/fileupload/jquery.fileupload-ui.js" type="text/javascript"></script>
	<script src="/Scripts/modules/fileupload/jquery.fileupload-fp.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div class="row">
		<div class="span12">
			<div class="well well-small" style="height:300px !important">
				<bun:AsyncUpload runat="server" ID="asyncUpload1" />
			</div>
		</div>
	</div>
</asp:Content>

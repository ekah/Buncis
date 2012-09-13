<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.DailyBread.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div id="homeSection" class="row">
		<div class="span12">
			<div class="buncisContentHeader well well-small">
				<h3>DailyBread</h3>
			</div>
		</div>
	</div>
	<div class="span12">
		<div class="buncisContentBody well well-small">
			<div class="actionContent pull-right">
				<a href="#" id="aAddDailyBread" class="btn btn-warning addDailyBread">
					<i class="icon-plus"></i>&nbsp;<span>Add Daily Bread</span>
				</a>
			</div>
			<div class="clearfix"></div>
			<ul class="list-item-container" id="dailyBread-list-container"></ul>
		</div>
	</div>
	
	<div id="edit-section" class="row"></div>
	<div id="delete-popup" class="popup-wrapper modal hide fade"></div>

	<div style="display:none">
		<script type="text/template" id="popup-template">
			<div class="popup-button-wrapper buttonContainer">
				<a href="#" id="btnClose" class="button-whiteOnRed popup-button-close">Close</a>
				<a href="#" id="btnSaveDailyBread" class="button-whiteOnGreen">Save</a>                
			</div>
			<div id="news-wizard" class="swMain">					
				<ul class="news-tabs">
					<li><a href="#dailyBread-tab1" class="tabStart">Section 1: Tab 1</a></li>
					<li><a href="#dailyBread-tab2">Section 2: Tab 2</a></li>
				</ul>
				<div id="dailyBread-tab1" class="dailyBread-tab1">
					<div class="form-item">
						<label></label>
						<input type="text" id="" name=""
							data-message="" required="required" class="x-long" 
							value="" />
					</div>					
					<div class="clearFloats"></div>						
				</div>
				<div id="dailyBread-tab2" class="dailyBread-tab2">
					<div class="form-item hasHtmlArea">
						<label></label>
						<textarea class=""></textarea>
					</div>
				</div>
			</div>
		</script>
		
		<script type="text/template" id="confirm-delete-popup-template">
			<p>Are you sure you want to delete news <strong></strong>?</p>
			<div class="popup-button-wrapper buttonContainer">
				<a href="#" id="delete-cancel" class="button-whiteOnBlack popup-button-close">No</a>
				<a href="#" id="delete-confirm" class="button-whiteOnRed">Yes</a>			    
			</div>
		</script>
	</div>
</asp:Content>

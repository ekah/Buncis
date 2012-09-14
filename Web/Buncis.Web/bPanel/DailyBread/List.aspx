<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.DailyBread.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_dailybread.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	<div id="homeSection" class="row">
		<div class="span12">
			<div class="buncisContentHeader well well-small">
				<h3>DailyBread</h3>
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
	</div>	
	
	<div id="edit-section" class="row"></div>
	<div id="delete-popup" class="popup-wrapper modal hide fade"></div>
	
	<div style="display:none">
		<script type="text/template" id="item-template">
			<li class="list-item" rel="{{id}}">
				<div class="row-fluid">
					<div class="span2">
						<div class=""><strong>{{attributes.dailyBreadBook}}</strong></div>
						<div class=""><strong>{{attributes.dailyBreadBookChapter}} : {{attributes.dailyBreadBookVerse1}} - {{attributes.dailyBreadBookVerse2}}</strong></div>
					</div>
					<div class="span8 leftSection">
						<div class=""><strong>{{attributes.dailyBreadTitle}}</strong></div>
						<p></p>
						<div class="">{{attributes.dailyBreadSummary}}</div>
						<p></p>
						<!--<div class="">{{attributes.dailyBreadContent}}</div>
						<p></p>-->
						<div><strong>Created Date:</strong>&nbsp;{{attributes.displayDateCreated}}</div>
						<div><strong>Published Date:</strong>&nbsp;{{attributes.displayDatePublished}}</div>
					</div>
					<div class="span1 rightSection">
						<div class="btn-toolbar">
							<div class="btn-group">
								<button class="btn btn-info">Action</button>
								<button class="btn btn-info dropdown-toggle" data-toggle="dropdown">
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu">
									<li><a href="#" class="action edit">Edit</a></li>
									<li><a href="#" class="action delete">Delete</a></li>
								</ul>
							</div>
						</div>
					</div>
					<div class="clearfix"></div>
				</div>
			</li>
		</script>

		<script type="text/template" id="edit-template">
			<div class="span12">
				<div class="buncisContentHeader well well-small">
					<h3>Modal header</h3>
				</div>
			</div>
			<div class="span12">
				<div class="buncisContentBody well well-small">
					<div class="row">
						<div class="form-item span11">
							<label>Daily Bread Title:</label>					
							<textarea type="text" id="txtDailyBreadTitle" name="txtDailyBreadTitle" 
								class="span10" cols="120" rows="3"
								required="required" data-message="Daily Bread Title is required">{{attributes.dailyBreadTitle}}</textarea>
						</div>
						<div class="form-item span11">
							<label>Daily Bread Summary:</label>					
							<textarea type="text" id="txtDailyBreadSummary" name="txtDailyBreadSummary" 
								class="span10" cols="120" rows="6"
								required="required" data-message="Daily Bread Summary is required">{{attributes.dailyBreadSummary}}</textarea>
						</div>
						<div class="form-item span11">
							<label>Daily Bread Url:</label>					
							<input type="text" id="txtDailyBreadUrl" name="txtDailyBreadUrl" 
								value="{{attributes.dailyBreadUrl}}"
								class="input-xxlarge"
								required="required" data-message="Daily Bread Url is required"/>
						</div>
						<div class="form-item span11">
							<label>Daily Bread Published Date:</label>					
							<input type="text" 
								id="txtDailyBreadPublishedDate" name="txtDailyBreadPublishedDate" 
								value="{{attributes.formattedDatePublished}}"
								rel="{{attributes.actualDatePublished}}"
								class="input-medium" 
								required="required" data-message="Daily Bread Published Date is required"/>
							<span class="input-medium uneditable-input help-inline">{{attributes.displayDatePublished}}</span>
						</div>
						<div class="form-item span11">
							<label>Daily Bread Bible:</label>					
							<span class="uneditable-input help-inline">Book of:&nbsp;</span>
							<select id="selDailyBreadBook" name="selDailyBreadBook" 
								required="required" data-message="Daily Bible Book is required">
								<option value="dummy1">dummy1</option>
								<option value="dummy2">dummy2</option>
								<option value="dummy3">dummy3</option>
								<option value="dummy4">dummy4</option>
							</select>
							<span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
							<span class="uneditable-input help-inline">Chapter:&nbsp;</span>
							<input type="text" class="input-mini"
								value="{{attributes.dailyBreadBookChapter}}"
								id="txtDailyBreadBookChapter" name="txtDailyBreadBookChapter"
								required="required" data-message="Daily Bible Book Chapter is required" />
							<span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
							<span class="uneditable-input help-inline">Verse:&nbsp;</span>
							<input type="text" class="input-mini"
								value="{{attributes.dailyBreadBookVerse1}}"
								id="txtDailyBreadBookVerse1" name="txtDailyBreadBookVerse1"
								required="required" data-message="Daily Bible Book Verse 1 is required" />
							<span class="uneditable-input help-inline">&nbsp;-&nbsp;</span>
							<input type="text" class="input-mini"
								value="{{attributes.dailyBreadBookVerse2}}"
								id="txtDailyBreadBookVerse2" name="txtDailyBreadBookVerse2"
								required="required" data-message="Daily Bible Book Verse 2 is required" />
							<div>
								<textarea type="text" id="txtDailyBreadBookContent" name="txtDailyBreadBookContent" 
									class="span10" cols="120" rows="6"
									required="required" data-message="Daily Bread Book Content is required">{{attributes.dailyBreadBookContent}}</textarea>
							</div>
						</div>
						<div class="form-item hasHtmlArea span11">
							<label>Daily Bread Content:</label>
							<textarea id="txtDailyBreadContent" name="txtDailyBreadContent" 
								class="htmlarea span10" rows="45" cols="150"
								required="required" data-message="Daily Bread Content is required">{{attributes.dailyBreadContent}}</textarea>
						</div>
					</div>
				</div>
			</div>
			<div class="span12">
				<div class="well well-small buncisButtonContainer">
					<div class="pull-right">						
						<a href="#" id="btnSaveDailyBread" class="btn btn-primary">Save</a>
						<a href="#" id="btnClose" class="close-view-area btn btn-inverse">Close</a>
					</div>
				</div>
			</div>
		</script>
		
		<script type="text/template" id="confirm-delete-popup-template">
			<div class="modal-header">
				<h3>Modal header</h3>
			</div>
			<div class="modal-body popup-content-small">
				<p>Are you sure you want to delete daily bread <strong>{{attributes.dailyBreadTitle}}</strong>?</p>
			</div>
			<div class="buttonContainer modal-footer">				
				<a href="#" id="delete-confirm" class="btn btn-primary">Yes</a>
				<a href="#" id="delete-cancel" class="popup-button-close btn btn-inverse">No</a>
			</div>
		</script>
	</div>
</asp:Content>

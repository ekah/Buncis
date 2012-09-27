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
					<a href="#" id="aAddDailyBread" class="btn btn-warning">
						<i class="icon-plus"></i>&nbsp;<span>Add Daily Bread</span>
					</a>
				</div>
				<div class="clearfix"></div>
				<ul id="dailyBread-list-container" class="list-item-container"></ul>
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
							<label>Daily Bread Url:</label>
							<span id="txtDailyBreadUrl" name="txtDailyBreadUrl" class="span10 uneditable-input">{{attributes.dailyBreadUrl}}</span>
						</div>
						<div class="form-item span11">
							<label>Daily Bread Summary:</label>					
							<textarea type="text" id="txtDailyBreadSummary" name="txtDailyBreadSummary" 
								class="span10" cols="120" rows="6"
								required="required" data-message="Daily Bread Summary is required">{{attributes.dailyBreadSummary}}</textarea>
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
							<div class="form-inline">
								<span class="">Book of:&nbsp;</span>
								<select id="selDailyBreadBook" name="selDailyBreadBook" 
									required="required" data-message="Daily Bible Book is required">
									<optgroup label="Old Testament (Perjanjian Lama)">
										<option value="Genesis">Genesis (Kejadian)</option>
										<option value="Exodus">Exodus (Keluaran)</option>
										<option value="Leviticus">Leviticus (Imamat)</option>
										<option value="Numbers">Numbers (Bilangan)</option>
										<option value="Deuteronomy">Deuteronomy (Ulangan)</option>
										<option value="Joshua">Joshua (Yosua)</option>
										<option value="Judges">Judges (Hakim Hakim)</option>
										<option value="Ruth">Ruth (Rut)</option>
										<option value="1 Samuel">1 Samuel (1 Samuel)</option>
										<option value="2 Samuel">2 Samuel (2 Samuel)</option>
										<option value="1 Kings">1 Kings (1 Raja Raja)</option>
										<option value="2 Kings">2 Kings (2 Raja Raja)</option>
										<option value="1 Chronicles">1 Chronicles (1 Tawarikh)</option>
										<option value="2 Chronicles">2 Chronicles (2 Tawarikh)</option>
										<option value="Ezra">Ezra (Ezra)</option>
										<option value="Nehemiah">Nehemiah (Nehemia)</option>
										<option value="Esther">Esther (Ester)</option>
										<option value="Job">Job (Ayub)</option>
										<option value="Psalm">Psalm (Mazmur)</option>
										<option value="Proverbs">Proverbs (Amsal)</option>
										<option value="Ecclesiastes">Ecclesiastes (Pengkhotbah)</option>
										<option value="Song of Solomon">Song of Solomon (Kidung Agung)</option>
										<option value="Isaiah">Isaiah (Yesaya)</option>
										<option value="Jeremiah">Jeremiah (Yeremia)</option>
										<option value="Lamentations">Lamentations (Ratapan)</option>
										<option value="Ezekiel">Ezekiel (Yehezkiel)</option>
										<option value="Daniel">Daniel (Daniel)</option>
										<option value="Hosea">Hosea (Hosea)</option>
										<option value="Joel">Joel (Yoel)</option>
										<option value="Amos">Amos (Amos)</option>
										<option value="Obadiah">Obadiah (Obaja)</option>
										<option value="Jonah">Jonah (Yunus)</option>
										<option value="Micah">Micah (Mikha)</option>
										<option value="Nahum">Nahum (Nahum)</option>
										<option value="Habakkuk">Habakkuk (Habakuk)</option>
										<option value="Zephaniah">Zephaniah (Zafanya)</option>
										<option value="Haggai">Haggai (Hagai)</option>
										<option value="Zechariah">Zechariah (Zakharia)</option>
										<option value="Malachi">Malachi (Maleakhi)</option>
									</optgroup>
									<optgroup label="New Testament (Perjanjian Baru)">
										<option value="Matthew">Matthew (Matius)</option>
										<option value="Mark">Mark (Markus)</option>
										<option value="Luke">Luke (Lukas)</option>
										<option value="John">John (Yohanes)</option>
										<option value="Acts">Acts (Kisah Para Rasul)</option>
										<option value="Romans">Romans (Roma)</option>
										<option value="1 Corinthians">1 Corinthians (1 Korintus)</option>
										<option value="2 Corinthians">2 Corinthians (2 Korintus)</option>
										<option value="Galatians">Galatians (Galatia)</option>
										<option value="Ephesians">Ephesians (Efesus)</option>
										<option value="Philippians">Philippians (Filipi)</option>
										<option value="Colossians">Colossians (Kolose)</option>
										<option value="1 Thessalonians">1 Thessalonians (1 Tesalonika)</option>
										<option value="2 Thessalonians">2 Thessalonians (2 Tesalonika)</option>
										<option value="1 Timothy">1 Timothy (1 Timotius)</option>
										<option value="2 Timothy">2 Timothy (2 Timotius)</option>
										<option value="Titus">Titus (Titus)</option>
										<option value="Philemon">Philemon (Filemon)</option>
										<option value="Hebrews">Hebrews (Ibrani)</option>
										<option value="James">James (Yakobus)</option>
										<option value="1 Peter">1 Peter (1 Petrus)</option>
										<option value="2 Peter">2 Peter (2 Petrus)</option>
										<option value="1 John">1 John (1 Yohanes)</option>
										<option value="2 John">2 John (2 Yohanes)</option>
										<option value="3 John">3 John (3 Yohanes)</option>
										<option value="Jude">Jude (Yudas)</option>
										<option value="Revelation">Revelation (Wahyu)</option>
									</optgroup>
								</select>
								<span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
								<span class="">Chapter:&nbsp;</span>
								<input type="text" class="span1"
									value="{{attributes.dailyBreadBookChapter}}"
									id="txtDailyBreadBookChapter" name="txtDailyBreadBookChapter"
									required="required" data-message="Daily Bible Book Chapter is required" />
								<span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
								<span class="">Verse:&nbsp;</span>
								<input type="text" class="span1"
									value="{{attributes.dailyBreadBookVerse1}}"
									id="txtDailyBreadBookVerse1" name="txtDailyBreadBookVerse1"
									required="required" data-message="Daily Bible Book Verse 1 is required" />
								<span class="">&nbsp;-&nbsp;</span>
								<input type="text" class="span1"
									value="{{attributes.dailyBreadBookVerse2}}"
									id="txtDailyBreadBookVerse2" name="txtDailyBreadBookVerse2"
									required="required" data-message="Daily Bible Book Verse 2 is required" />
							</div>
							<p></p>
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

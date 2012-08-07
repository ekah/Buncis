<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.News.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script src="/Scripts/bunx/_act_news.js" type="text/javascript"></script>   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceholderMain" runat="server">
	 <div class="buncisContentHeader">
        <h3>News</h3>
    </div>
    <div class="buncisContentBody">
        <div class="actionContent">
            <a href="javascript:void(0);" id="aAddNews" class="button-action addNews">
                <span class="icon-plus">Add News</span>
            </a>
        </div>
        <div class="innerContent">
			<div class="news-list-wrapper">				
				<ul class="newsItem-container">						
					<script type="text/template" id="news-item-template">
						<li rel="{{id}}">
							<div>
								<div class="left" style="width: 80%">
									<div class="news-title">{{attributes.newsTitle}}</div>
									<div class="news-teaser">{{attributes.newsTeaser}}</div>
									<div class="news-dates">
										<span>Published: {{attributes.datePublished}}</span>
										<br/>
										<span>Expired: {{attributes.dateExpired}}</span>
									</div>
								</div>
								<div class="left" style="width:20%">								
									<div class="list-action">
										<a href="javascript:;" class="action-delete">Delete</a>
										<a href="javascript:;" class="action-edit">Edit</a>						
										<div class="clearFloats"></div>
									</div>	
								</div>
							</div>
							<div class="clearFloats"></div>
						</li>
					</script>
				</ul>
			</div>
        </div>
    </div>
    <div style="display:none">
		<script type="text/template" id="news-edit-popup-template">
			<div class="popup-button-wrapper buttonContainer">
				<a href="javascript:;" id="btnClose" class="button-whiteOnRed popup-button-close">Close</a>
				<a href="javascript:;" id="btnSaveNews" class="button-whiteOnGreen">Save</a>                
			</div>
			<div id="news-wizard" class="swMain">					
				<ul class="news-tabs">
					<li><a href="#news-tab1" class="tabStart">Section 1: News Information</a></li>
					<li><a href="#news-tab2">Section 2: News Content</a></li>
				</ul>
				<div id="news-tab1" class="news-tab1">
					<div class="form-item">
						<label>News Title</label>
						<input type="text" id="txtNewsTitle" name="txtNewsTitle"
							data-message="News Title is required" required='required' class="x-long" 
							value="{{attributes.newsTitle}}" />
					</div>
					<div class="form-item">
						<label>News Teaser</label>
						<textarea id="txtNewsTeaser" name="txtNewsTeaser" required="required"
							data-message="News Teaser is required" required" required='required'
							style="width:700px; height: 100px;">{{attributes.newsTeaser}}</textarea>
					</div>
					<div class="form-item">
						<label>Friendly URL</label>
						<input type="text" required="required" id="txtNewsUrl" 
							class="medium" name="txtNewsUrl" required" required='required'
							data-message="News Url is required" value="{{attributes.friendlyUrl}}" />
					</div>
					<div class="left">
						<div class="form-item">
							<label>Date Published</label>
							<input type="text" id="txtDatePublished" name="txtDatePublished" 
								required="required" data-message="Date Published is required" 
								value="{{attributes.tDatePublished}}" rel="{{attributes.eDatePublished}}" />
						</div>							
					</div>
					<div class="left">							
						<div class="form-item">
							<label>Date Expired</label>
							<input type="text" id="txtDateExpired" name="txtDateExpired" 
								required="required" data-message="Date Expired  is required" 
								value="{{attributes.tDateExpired}}" rel="{{attributes.eDateExpired}}" />
						</div>							
					</div>		
					<div class="newsDate left" style="width: 100px; height: 40px; border: solid 1px black; padding: 10px;">
						Click here to adjust dates
					</div>	
					<div class="clearFloats"></div>						
				</div>
				<div id="news-tab2" class="news-tab2">
					<div class="form-item">
						<label>News Content</label>
						<textarea id="txtNewsContent" 
							name="txtNewsContent"
							class="htmlarea"
							style="width: 870px; height: 350px" 
							required="required"
							data-message="News Content is required">{{attributes.newsContent}}
						</textarea>
					</div>
				</div>
			</div>
		</script>
        <div id="news-edit-popup">
			
        </div>
    </div>    
</asp:Content>

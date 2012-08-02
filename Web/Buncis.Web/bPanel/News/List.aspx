<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Buncis.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Buncis.Web.bPanel.News.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceholderHead" runat="server">
	<script type="text/javascript">
   	
        (function (news) {
            news._elems = {
                clientId: <%= CurrentProfile.ClientId %>,
                detailPopup: '#news-detail-popup',
                editPopup: '#news-edit-popup',
                newsWizards: '#news-wizard',
				txtNewsTitle: '#txtNewsTitle',
                txtNewsContent: '#txtNewsContent',
				txtNewsTeaser: '#txtNewsTeaser',
				txtNewsUrl: '#txtNewsUrl',
				txtDateExpired: '#txtDateExpired',
				txtDatePublished: '#txtDatePublished',
                newsTabs: '#news-tabs',
                newsFormElements: '.form-item :input',
				newsDate: '.newsDate',
				btnSaveNews: '#btnSaveNews',
				btnAddNews: '#aAddNews'
            };
        }(window._news = window._news || {}));

    </script>
    <!--<script src="/Scripts/bunx/ember/handlebars-1.0.0.beta.6.js" type="text/javascript"></script>-->
	<script src="/Scripts/bunx/ember/ember-0.9.8.1.js" type="text/javascript"></script>    
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
				<script type="text/x-handlebars">
				  <ul>
					{{#each News.newsController.newsList}}
						<li>
						{{#view News.NewsListView contentBinding="this"}}							
							<div class="news-title">{{content.newsTitle}}</div>
							<div class="news-teaser">{{content.newsTeaser}}</div>
							<div class="news-dates">
								<span>Published: {{content.datePublished}}</span><br/><span>Expired: {{content.dateExpired}}</span>
							</div>
							<div class="list-action">
								<a href="javascript:;" {{action "delete" on="click"}}>Delete</a>
								<a href="javascript:;" {{action "edit" on="click"}}>Edit</a>						
								<div class="clearFloats"></div>
							</div>							
							<div class="clearFloats"></div>
						{{/view}}
						</li>
					{{/each}}
				  </ul>    
				</script>
			</div>
        </div>
    </div>
    <div style="display:none">
        <div id="news-edit-popup">		
            <script type="text/x-handlebars" data-template-name="newsItemEditTemplate">
				<div class="popup-button-wrapper buttonContainer">
					<a href="javascript:;" id="btnClose" class="button-whiteOnRed popup-button-close">Close</a>
					<a href="javascript:;" id="btnSaveNews" class="button-whiteOnGreen" {{action "save" on="click"}}>Save</a>                
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
                                data-message="News Title is required" required='required'
                                {{bindAttr value="newsItemEdited.newsTitle"}} class="x-long" />
                        </div>
                        <div class="form-item">
                            <label>News Teaser</label>
                            <textarea id="txtNewsTeaser" name="txtNewsTeaser" required="required"
                                data-message="News Teaser is required" required" required='required'
                                style="width:700px; height: 100px;">{{unbound newsItemEdited.newsTeaser}}</textarea>
                        </div>
                        <div class="form-item">
                            <label>Friendly URL</label>
                            <input type="text" required="required" id="txtNewsUrl" 
								class="medium" name="txtNewsUrl" required" required='required'
                                data-message="News Url is required" {{bindAttr value="newsItemEdited.friendlyUrl"}} />
                        </div>
                        <div class="left">
                            <div class="form-item">
                                <label>Date Published</label>
                                <input type="text" id="txtDatePublished" name="txtDatePublished" required="required" 
                                    data-message="Date Published is required" {{bindAttr value="newsItemEdited.tDatePublished"}}/>                           
                            </div>							
                        </div>
                        <div class="left">							
							<div class="form-item">
								<label>Date Expired</label>
								<input type="text" id="txtDateExpired" name="txtDateExpired" required="required" 
									data-message="Date Expired  is required" {{bindAttr value="newsItemEdited.tDateExpired"}}/>
							</div>							
						</div>		
						<div class="newsDate left" style="width: 100px; height: 40px; border: solid 1px black; padding: 10px;">Click here to adjust dates</div>	
						<div class="clearFloats"></div>						
                    </div>
                    <div id="news-tab2" class="news-tab2">
                        <div class="form-item">
                            <label>News Content</label>
                            <textarea id="txtNewsContent" name="txtNewsContent"
                                class="htmlarea"
                                style="width: 870px; height: 350px" 
                                required="required"
                                data-message="News Content is required">
								{{unbound newsItemEdited.newsContent}}
                            </textarea>
                        </div>
                    </div>
                </div>				
            </script>           
        </div>        
    </div>
    <script src="/Scripts/bunx/_act_news.js" type="text/javascript"></script>   
</asp:Content>
